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
#addin "nuget:?package=Cake.Incubator&version=5.1.0"

///////////////////////////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////////////////////////

var isGitHubAction = !string.IsNullOrWhiteSpace(EnvironmentVariable("GITHUB_ACTION"));
GitVersion gitVersion = null;


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
   NuGetRestore("src/Slack.Webhooks.sln");
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
   DotNetCorePack("src/Slack.Webhooks.sln", new DotNetCorePackSettings {
      Configuration = configuration,
      NoBuild = true,
      OutputDirectory = "./artifacts",
      ArgumentCustomization = args => args.Append($"-p:PackageVersion={gitVersion.NuGetVersionV2}")
   });

   if(IsGitHubAction)
   {
      var packageName = $"Slack.Webhooks.{gitVersion.NuGetVersionV2}";
      Information($"##[set-output name=nupkg_name;]{packageName}");
      Information($"##[set-output name=nupkg;]artifacts/{packageName}.nupkg");
   }
});

Task("DeployGPR")
   .Does(() =>
{
   if(isGitHubAction)
   {
      var settings = new NuGetSourcesSettings
                              {
                                    UserName = "mrb0nj",
                                    Password = EnvironmentVariable("GITHUB_TOKEN"),
                                    IsSensitiveSource = true,
                                    Verbosity = NuGetVerbosity.Detailed
                              };
      NugetAddSource("GPR", "https://nuget.pkg.github.com/mrb0nj/index.json", settings);
      NugetPush($"artifacts/Slack.Webhooks.{gitVersion.NuGetVersionV2}.nupkg", "GPR");
   }
   else
   {
       Information($"Skipping DeployGPR. IsGitHubAction: {isGitHubAction}");
   }
});

Task("DeployNuGet")
   .Does(() =>
{
   var eventName = EnvironmentVariable("GITHUB_EVENT_NAME");
   var ref = EnvironmentVariable("GITHUB_REF");
   var baseRef = EnvironmentVariable("GITHUB_BASE_REF");
   var isTag = eventName == "push" && ref.StartsWith("refs/tags/v") && baseRef == "refs/heads/master";
   Information($"EventName: {eventName}, Ref: {ref}, BaseRef: {baseRef}, IsTag: {isTag}");


   if(isGitHubAction)
   {
      var settings = new NugetPushSettings
      {
         Source = "https://api.nuget.org/v3/index.json",
         ApiKey = EnvironmentVariable("NUGET_APIKEY")
      };
      NugetPush($"artifacts/Slack.Webhooks.{gitVersion.NuGetVersionV2}.nupkg", settings);
   }
   else
   {
       Information($"Skipping DeployNuget. IsGitHubAction: {isGitHubAction}, IsTag: {isTag}");
   }
});

Task("Test")
   .IsDependentOn("TestFramework")
   .IsDependentOn("TestCore");

Task("TestFramework")
   .IsDependentOn("Build")
   .Does(() =>
{
   var testAssemblies = GetFiles($"./src/**/bin/{configuration}/net45/*.Tests.dll");
   XUnit2(testAssemblies, new XUnit2Settings {
         Parallelism = ParallelismOption.All,
         NoAppDomain = true
      });
});

Task("TestCore")
   .IsDependentOn("Build")
   .Does(() =>
{
   DotNetCoreTest("./src/Slack.Webhooks.Tests/Slack.Webhooks.Tests.csproj", new DotNetCoreTestSettings 
      { 
         NoBuild = true, 
         Framework = "netcoreapp2",
         Configuration = configuration
      });
});

RunTarget(target);