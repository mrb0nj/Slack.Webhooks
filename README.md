Slack.Webhooks [![Build status](https://ci.appveyor.com/api/projects/status/08qvvm46ouxwujmq/branch/master?svg=true)](https://ci.appveyor.com/project/nerdfury/slack/branch/master) [![Build status](https://ci.appveyor.com/api/projects/status/08qvvm46ouxwujmq?svg=true)](https://ci.appveyor.com/project/nerdfury/slack)
==============

Even simpler integration with Slack's Incoming webhook API for .net

Usage
-----

Requirements:

1. You must first enable the Webhooks integration for your Slack Account to get the Token. You can enable it here: https://slack.com/services/new/incoming-webhook
2. Slack.Webhooks depends on RestSharp

Then, create a SlackClient with your TeamName and Token

```csharp
var slackClient = new SlackClient("https://hooks.slack.com/services/[YOUR_WEBHOOK_URL]");
```

Create a  new SlackMessage
```csharp
var slackMessage = new SlackMessage
{
    Channel = "#random",
    Text = "Your message",
    IconEmoji = Emoji.Ghost,
    Username = "nerdfury"
};
```

And Post it to Slack

```csharp
slackClient.Post(slackMessage);
```
