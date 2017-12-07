Slack.Webhooks [![Build status](https://ci.appveyor.com/api/projects/status/08qvvm46ouxwujmq/branch/master?svg=true)](https://ci.appveyor.com/project/nerdfury/slack/branch/master) [![NuGet Version](http://img.shields.io/nuget/v/Slack.Webhooks.svg?style=flat)](https://www.nuget.org/packages/Slack.Webhooks/)
==============

Even simpler integration with Slack's Incoming/Outgoing webhooks API for .net

*** v1.0.0 BREAKING CHANGES ***
---

We no longer use RestSharp in favour of HttpClient - this however means that
.NET 4.0 and below are no longer supported.

Also, the PostAsync method signature has changed. The return type is now ```Task<bool>```
in place of ```Task<IRestResponse>``` which was tied directly to RestSharp.

Outgoing Webhooks
---

[Blog Post](http://nerdfury.me/2015/04/07/Slack-Outgoing-Webhooks/)

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
        Text = "New open task *[Urgent]*: <http://url_to_task|Test out Slack message attachments>",
        Color = "#D00000",
        Fields =
            new List<SlackField>
                {
                    new SlackField
                        {
                            Title = "Notes",
                            Value = "This is much *easier* than I thought it would be."
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
