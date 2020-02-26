# Slack.Webhooks ![Continuous Stuff](https://github.com/mrb0nj/Slack.Webhooks/workflows/Continuous%20Stuff/badge.svg?branch=master) [![NuGet Version](http://img.shields.io/nuget/v/Slack.Webhooks.svg?style=flat)](https://www.nuget.org/packages/Slack.Webhooks/)

Even simpler integration with Slack's Incoming/Outgoing webhooks API for .net

### IMPORTANT

On Feb 19th 2020 Slack will end support for TLS version 1.0 and 1.1. This means you may (depending on your .NET version) need to force the use of TLS1.2.

If you receive an error stating that "The underlying connection was closed:" it's quite possibly a TLS issue. You can work around this by setting the default TLS version using the following:

```csharp
System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
```

### Change Log

#### v1.1.2

- Fix SlackMessage.Clone does not clone all properties

#### v1.1.0

- Support Slack's Block Kit with SlackMessage.Blocks property
- Support Thread replies with SlackMessage.ThreadId property
- Changed the whole Emoji setup. SlackMessage.Emoji is now a string and Emoji.\* are constants. This shouldn't cause problems in the most part!
- Allow HttpClient to be injected into SlackClient.
- SlackClient implements IDisposable to match the contained HttpClient instance even though this isn't the recommended usage. SlackClient, like HttpClient, there should only be a single instance of this class within the lifecycle of your application, for more information on why see: https://aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/

### v1.0.0 BREAKING CHANGES

We no longer use RestSharp in favour of HttpClient - this however means that
.NET 4.0 and below are no longer supported.

Also, the PostAsync method signature has changed. The return type is now `Task<bool>`
in place of `Task<IRestResponse>` which was tied directly to RestSharp.

## Outgoing Webhooks

[Blog Post](http://nerdfury.me/2015/04/07/slack-outgoing-webhooks/)

## Incoming Webhooks

Requirements:

1. You must first enable the Webhooks integration for your Slack Account to get the Token. You can enable it here: https://slack.com/services/new/incoming-webhook
2. Slack.Webhooks depends on JSON.net
3. Compatible with .NET 4.5+ and .NET Core. If you need .NET 3.5/4 you can use an older release, but this may be out of date.

Download:

Package is hosted on [Nuget](https://www.nuget.org/packages/Slack.Webhooks/) and can be installed from the package manager:

```
PM> Install-Package Slack.Webhooks
```

For older .NET framework support:

```
PM> Install-Package Slack.Webhooks -Version 0.1.8
```

Then, create a SlackClient with your Webhook URL.

```csharp
var slackClient = new SlackClient("[YOUR_WEBHOOK_URL]");
```

Create a new SlackMessage

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

You can also provide a list of `Block` objects in `SlackMessage.Blocks` to create more interactive content:

`Blocks.Divider`

```csharp
slackMessage.Blocks = new List<Block>
    {
        new Blocks.Divider()
    };
```

`Blocks.Image`

```csharp
slackMessage.Blocks = new List<Block>
    {
        new Blocks.Image
            {
                AltText = "Sexy Skyline",
                ImageUrl = "https://placekitten.com/500/500",
                Title = new TextObject("Hello, this is text")
            }
    };
```

`Blocks.Context`

```csharp
slackMessage.Blocks = new List<Block>
    {
        new Blocks.Context
            {
                Elements = new List<Interfaces.IContextElement>
                {
                    new TextObject("_markdown_")
                        {
                            Type = TextObject.TextType.Markdown
                        },
                    new Elements.Image
                        {
                            ImageUrl = "https://placekitten.com/200/300", AltText = "Random Kitten"
                        }
                }
            }
    };
```

`Blocks.Section`

```csharp
slackMessage.Blocks = new List<Block>
    {
        new Blocks.Section
            {
                Text = new TextObject("_markdown_")
                        {
                            Type = TextObject.TextType.Markdown
                        },
                Fields = new List<TextObject>
                {
                    new TextObject { Text = "Field 1" },
                    new TextObject { Text = "Field 2" },
                    new TextObject { Text = "Field 3" }
                }
            }
    };
```

`Blocks.Section` with `Accessory`

```csharp
var confirmation = new Confirmation
    {
        Confirm = new TextObject("This OK?"),
        Text = new TextObject("This is the Text"),
        Deny = new TextObject("This is the Deny Text"),
        Title = new TextObject("Title")
    };

var options = new List<Option>
    {
        new Option
            {
                Text = new TextObject("OPtion1"),
                Value = "option1"
            },
        new Option
            {
                Text = new TextObject("OPtion2"),
                Value = "option2"
            },
        new Option
            {
                Text = new TextObject("OPtion3"),
                Value = "option3"
            },
    };

var optionGroups = new List<OptionGroup>
    {
        new OptionGroup
            {
                Label = new TextObject("Label 1"),
                Options = options
            },
        new OptionGroup
            {
                Label = new TextObject("Label 2"),
                Options = options
            }
    };


Elements.Element element;
element = new Button
    {
        Text = new TextObject { Text = "Button Text" },
        ActionId = "Button1_Click",
    };

element = new Elements.Overflow
    {
        Confirm = confirmation,
        Options = options
    };

element = new Elements.DatePicker
    {
        Placeholder = new TextObject("Select a date")
    };

element = new Elements.SelectUsers
    {
        Placeholder = new TextObject("Select a user..."),
        Confirm = confirmation
    };

element = new Elements.SelectChannels
    {
        Placeholder = new TextObject("Select a channel"),
        Confirm = confirmation
    };

element = new Elements.SelectConversations
    {
        Placeholder = new TextObject("Select a conversation"),
        Confirm = confirmation
    };

element = new Elements.SelectStatic
    {
        Options = options,
        Placeholder = new TextObject("Options Placeholder")
    };

element = new Elements.SelectStatic
    {
        OptionGroups = optionGroups,
        Placeholder = new TextObject("OptionGroup placeholder")
    };

element = new Elements.MultiSelectUsers
    {
        Placeholder = new TextObject("Select a user..."),
        Confirm = confirmation
    };

element = new Elements.MultiSelectChannels
    {
        Placeholder = new TextObject("Select a channel")
    };

element = new Elements.MultiSelectConversations
    {
        Placeholder = new TextObject("Select a conversation")
    };

element = new Elements.MultiSelectStatic
    {
        Options = options,
        Placeholder = new TextObject("Options Placeholder")
    };

element = new Elements.MultiSelectStatic
    {
        OptionGroups = optionGroups,
        Placeholder = new TextObject("OptionGroup placeholder")
    };

slackMessage.Blocks = new List<Block>
    {
        new Blocks.Section
            {
                Text = new TextObject("_markdown_")
                        {
                            Type = TextObject.TextType.Markdown
                        },
                Accessory = element
            }
    };
```

And Post it to Slack

```csharp
slackClient.Post(slackMessage);
```
