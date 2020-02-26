///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

///////////////////////////////////////////////////////////////////////////////
// TOOLS / ADDINS
///////////////////////////////////////////////////////////////////////////////

#tool "nuget:?package=xunit.runner.console&version=2.3.1"
#tool "nuget:?package=GitVersion.CommandLine&version=5.0.1"
#tool "nuget:?package=JetBrains.ReSharper.CommandLineTools&version=2019.2.3"
#addin "nuget:?package=Cake.Incubator&version=5.1.0"
#addin "nuget:?package=Cake.Coverlet&version=2.3.4"

///////////////////////////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////////////////////////

var isGitHubAction = !string.IsNullOrWhiteSpace(EnvironmentVariable("GITHUB_ACTION"));
var githubEventName = EnvironmentVariable("GITHUB_EVENT_NAME");
var githubRef = EnvironmentVariable("GITHUB_REF");
var githubBaseRef = EnvironmentVariable("GITHUB_BASE_REF");
var isPullRequest = githubEventName == "pull_request";
var isTag = githubEventName == "push" && githubRef.StartsWith("refs/tags/v");

Information($"EventName: {githubEventName}, Ref: {githubRef}, BaseRef: {githubBaseRef}, IsTag: {isTag}, IsGithubAction: {isGitHubAction}");

GitVersion gitVersion = null;
Task("Default")
   .IsDependentOn("Build")
   .IsDependentOn("Test")
   .IsDependentOn("Deploy");

Task("Version")
   .Does(() =>
{
   gitVersion = GitVersion(new GitVersionSettings {
      UpdateAssemblyInfo = true
   });
   Information(gitVersion.FullSemVer);
});

Task("Clean")
   .Does(() =>
{
   var settings = new DeleteDirectorySettings { Recursive = true };
   DeleteDirectories(GetDirectories($"src/**/bin/{configuration}/"), settings);
   DeleteDirectories(GetDirectories($"src/**/obj/{configuration}/"), settings);
});

Task("Restore")
   .Does(() =>
{
   NuGetRestore("src/Slack.Webhooks.sln", new NuGetRestoreSettings {
      Verbosity = NuGetVerbosity.Quiet
   });
});

Task("Build")
   .IsDependentOn("Version")
   .IsDependentOn("Clean")
   .IsDependentOn("Restore")
   .Does(() =>
{
   DotNetCoreBuild("src/Slack.Webhooks.sln", new DotNetCoreBuildSettings
   {
      Configuration = configuration
   });
});

Task("Pack")
   .IsDependentOn("Build")
   .Does(() =>
{
   var nuGetPackSettings   = new NuGetPackSettings {
      Version = gitVersion.NuGetVersionV2,
      OutputDirectory = "./artifacts"
   };

   NuGetPack("src/Slack.Webhooks/Slack.Webhooks.nuspec", nuGetPackSettings);
   
   if(isGitHubAction)
   {
      var packageName = $"Slack.Webhooks.{gitVersion.NuGetVersionV2}";
      Information($"##[set-output name=nupkg_name;]{packageName}");
      Information($"##[set-output name=nupkg;]artifacts/{packageName}.nupkg");
   }
});

Task("Deploy")
   .IsDependentOn("DeployGPR")
   .IsDependentOn("DeployNuGet");

Task("DeployGPR")
   .IsDependentOn("Pack")
   .Does(() =>
{
   if(isGitHubAction && !isPullRequest)
   {
      Information($"DeployGPR. IsGitHubAction: {isGitHubAction}, IsPullRequest: {isPullRequest}");
      var settings = new NuGetSourcesSettings
                              {
                                    UserName = "mrb0nj",
                                    Password = EnvironmentVariable("GITHUB_TOKEN"),
                                    IsSensitiveSource = true,
                                    Verbosity = NuGetVerbosity.Detailed
                              };
      NuGetAddSource("GPR", "https://nuget.pkg.github.com/mrb0nj/index.json", settings);
      NuGetPush($"artifacts/Slack.Webhooks.{gitVersion.NuGetVersionV2}.nupkg", new NuGetPushSettings {
         Source = "GPR"
      });
   }
   else
   {
       Information($"Skipping DeployGPR. IsGitHubAction: {isGitHubAction}, IsPullRequest: {isPullRequest}");
   }
});

Task("DeployNuGet")
   .IsDependentOn("Pack")
   .Does(() =>
{
   if(isGitHubAction && isTag)
   {
      Information($"DeployNuget. IsGitHubAction: {isGitHubAction}, IsTag: {isTag}");
      var settings = new NuGetPushSettings
      {
         Source = "https://api.nuget.org/v3/index.json",
         ApiKey = EnvironmentVariable("NUGET_TOKEN")
      };
      NuGetPush($"artifacts/Slack.Webhooks.{gitVersion.NuGetVersionV2}.nupkg", settings);
   }
   else
   {
       Information($"Skipping DeployNuget. IsGitHubAction: {isGitHubAction}, IsTag: {isTag}");
   }
});

Task("Test")
   .IsDependentOn("TestCore");

Task("TestCore")
   .IsDependentOn("Build")
   .Does(() =>
{
   var coverletSettings = new CoverletSettings {
        CollectCoverage = true,
        CoverletOutputFormat = CoverletOutputFormat.opencover,
        CoverletOutputDirectory = Directory(@".\artifacts\"),
        CoverletOutputName = $"coverlet-output"
    };
   DotNetCoreTest("./src/Slack.Webhooks.Tests/Slack.Webhooks.Tests.csproj", new DotNetCoreTestSettings 
      { 
         NoBuild = true, 
         Framework = "netcoreapp2",
         Configuration = configuration
      }, coverletSettings);
});

Task("ReSharper")
  .Does(() =>
{
    DupFinder("src/Slack.Webhooks.sln", new DupFinderSettings {
       OutputFile = "artifacts/dupfinder-output.xml"
    });
    InspectCode("src/Slack.Webhooks.sln", new InspectCodeSettings {
      SolutionWideAnalysis = true,
      OutputFile = "artifacts/inspectcode-output.xml",
      ThrowExceptionOnFindingViolations = true
   });
});

RunTarget(target);