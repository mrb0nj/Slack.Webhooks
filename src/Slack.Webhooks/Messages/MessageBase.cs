using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Slack.Webhooks.Classes;
using Slack.Webhooks.Helpers;
using Slack.Webhooks.Message;
using BlockBase = Slack.Webhooks.Blocks.BlockBase;

namespace Slack.Webhooks.Messages
{
    /// <summary>
    /// Slack Message
    /// </summary>
    public class MessageBase
    {
        /// <summary>
        /// This is the text that will be posted to the channel
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Set response to visible to all 'in_channel' or visible to the requester 'ephermeral'
        /// </summary>
        public string ResponseType { get; set; }
        /// <summary>
        /// Used only when creating messages in response to a button action invocation. When set to true, the inciting message will be replaced by this message you're providing. When false, the message you're providing is considered a brand new message.
        /// </summary>
        public bool ReplaceOriginal { get; set; }
        /// <summary>
        /// Used only when creating messages in response to a button action invocation. When set to true, the inciting message will be deleted and if a message is provided, it will be posted as a brand new message.
        /// </summary>
        public bool DeleteOriginal { get; set; }
        /// <summary>
        /// Optional override of destination channel
        /// </summary>
        public string Channel { get; set; }
        /// <summary>
        /// Optional override of the username that is displayed
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Optional <see cref="Emoji"/> displayed with the message
        /// </summary>
        public string IconEmoji { get; set; }
        /// <summary>
        /// Optional <see cref="Uri"/> for icon displayed with the message
        /// </summary>
        public Uri IconUrl { get; set; }
        /// <summary>
        /// Optional override markdown mode. Default: true
        /// </summary>
        [JsonProperty(PropertyName = "mrkdwn")]
        public bool Markdown { get; set; } = true;
        /// <summary>
        /// Enable linkification of channel and usernames
        /// </summary>
        public bool LinkNames { get; set; }
        /// <summary>
        /// Set the message <see cref="ParseMode"/>
        /// </summary>
        public ParseMode Parse { get; set; }
        /// <summary>
        /// Parent message threadId (thread_ts)
        /// </summary>
        [JsonProperty("thread_ts")]
        public string ThreadId { get; set; }
        /// <summary>
        /// Optional attachment collection
        /// </summary>
        public List<Attachment> Attachments { get; set; }

        /// <summary>
        /// Optional collection of <see cref="Slack.Webhooks.Blocks.BlockBase"/>
        /// </summary>
        /// <seealso cref="Slack.Webhooks.Blocks.ActionsBlock" />
        /// <seealso cref="Slack.Webhooks.Blocks.ContextBlock" />
        /// <seealso cref="Slack.Webhooks.Blocks.DividerBlock" />
        /// <seealso cref="Slack.Webhooks.Blocks.FileBlock" />
        /// <seealso cref="Slack.Webhooks.Blocks.ImageBlock" />
        /// <seealso cref="Slack.Webhooks.Blocks.InputBlock" />
        /// <seealso cref="Slack.Webhooks.Blocks.SectionBlock" />
        public List<BlockBase> Blocks { get; set; }

        /// <summary>
        /// Conditional serialization of IconEmoji
        /// Overidden by the presence of IconUrl
        /// </summary>
        /// <returns>false when IconUrl is present otherwise true.</returns>
        public bool ShouldSerializeIconEmoji()
        {
            return IconUrl == null && IconEmoji != Emoji.None;
        }

        /// <summary>
        /// Serialize SlackMessage to a JSON string
        /// </summary>
        /// <returns>JSON formatted string</returns>
        public string AsJson()
        {
            return SerializationHelper.Serialize(this);
        }
    }
}
