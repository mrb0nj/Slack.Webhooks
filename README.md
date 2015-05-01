Slack.Webhooks [![Build status](https://ci.appveyor.com/api/projects/status/08qvvm46ouxwujmq/branch/master?svg=true)](https://ci.appveyor.com/project/nerdfury/slack/branch/master) [![NuGet Version](http://img.shields.io/nuget/v/Slack.Webhooks.svg?style=flat)](https://www.nuget.org/packages/Nancy/) [![NuGet Downloads](http://img.shields.io/nuget/dt/Slack.Webhooks.svg?style=flat)](https://www.nuget.org/packages/Nancy/)
==============

Even simpler integration with Slack's Incoming/Outgoing webhooks API for .net

Outgoing Webhooks
---

http://nerdfury.redrabbits.co.uk/2015/04/07/slack-outgoing-webhooks/

Incoming Webhooks
---

Requirements:

1. You must first enable the Webhooks integration for your Slack Account to get the Token. You can enable it here: https://slack.com/services/new/incoming-webhook
2. Slack.Webhooks depends on RestSharp

Download:

Package is hosted on [Nuget](https://www.nuget.org/packages/Slack.Webhooks/) and can be installed from the package manager:

```
PM> Install-Package Slack.Webhooks
```

Then, create a SlackClient with your Webhook URL.

```csharp
var slackClient = new SlackClient("[YOUR_WEBHOOK_URL]");
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

By default the text can contain Markdown but this default behaviour can be disabled:

```csharp
slackMessage.Mrkdwn = false;
```

More info on message formatting can be found in the [Docs](https://api.slack.com/docs/formatting)

Attachments can be added to a message:
```csharp
var slackAttachment = new SlackAttachment
    {
        Fallback = "New open task [Urgent]: <http://url_to_task|Test out Slack message attachments>",
        Text = "New open task [Urgent]: <http://url_to_task|Test out Slack message attachments>",
        Color = "#D00000",
        Fields =
            new List<SlackField>
                {
                    new SlackField
                        {
                            Title = "Notes",
                            Value = "This is much easier than I thought it would be."
                        }
                }
    };
slackMessage.Attachments = new List<SlackAttachment> {slackAttachment};
```

Please see the [Docs](https://api.slack.com/docs/attachments) for further info on attachments.

And Post it to Slack

```csharp
slackClient.Post(slackMessage);
```
