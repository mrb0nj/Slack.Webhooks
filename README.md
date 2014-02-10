Slack.Webhooks
==============

Even simpler integration with Slack's Incoming and Outgoing webhooks

Usage
-----

Requirements:

1. You must first enable the Webhooks integration for your Slack Account to get the Token. You can enable it here: https://imimobile.slack.com/services/new/incoming-webhook
2. Slack.Webhooks depends on RestSharp

Then, create a SlackClient with your TeamName and Token

```csharp
var slackClient = new SlackClient("your_team_name", "your_token");
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

Testing
-------

SlackClient accepts an optional 3rd parameter to Fake the RestClient. Using FakeItEasy for example:

```csharp
var restClient = A.Fake<RestClient>();
var client = new SlackClient(teamName, token, restClient);
```