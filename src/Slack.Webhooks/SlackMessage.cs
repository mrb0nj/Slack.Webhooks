using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Slack.Webhooks
{
    /// <summary>
    /// Slack Message
    /// </summary>
    public class SlackMessage
    {
        private bool _markdown = true;
        /// <summary>
        /// This is the text that will be posted to the channel
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Set response to visible to all 'in_channel' or visible to the requester 'ephermeral'
        /// </summary>
        public string ResponseType { get; set; }
        /// <summary>
        /// Optional override of destination channel
        /// </summary>
        public string Channel { get; set; }
        /// <summary>
        /// Optional override of the username that is displayed
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Optional emoji displayed with the message
        /// </summary>
        public Emoji IconEmoji { get; set; }
        /// <summary>
        /// Optional url for icon displayed with the message
        /// </summary>
        public Uri IconUrl { get; set; }
        /// <summary>
        /// Optional override markdown mode. Default: true
        /// </summary>
        [JsonProperty(PropertyName = "mrkdwn")]
        public bool Markdown
        {
            get { return _markdown; }
            set { _markdown = value; }
        }
        /// <summary>
        /// Optional override markdown mode. Default: true
        /// </summary>
        [Obsolete("Mrkdwn has been deprecated, please use 'Markdown' instead.")]
        [JsonIgnore]
        public bool Mrkdwn
        {
            get { return _markdown; }
            set { _markdown = value; }
        }
        /// <summary>
        /// Enable linkification of channel and usernames
        /// </summary>
        public bool LinkNames { get; set; }
        /// <summary>
        /// Parse mode <see cref="ParseMode"/>
        /// </summary>
        public ParseMode Parse { get; set; }
        /// <summary>
        /// Optional attachment collection
        /// </summary>
        public List<SlackAttachment> Attachments { get; set; }

        public SlackMessage Clone(string newChannel = null)
        {
            return new SlackMessage()
            {
                Attachments = Attachments,
                Text = Text,
                IconEmoji = IconEmoji,
                IconUrl = IconUrl,
                Username = Username,
                Channel = newChannel ?? Channel
            };
        }

        /// <summary>
        /// Conditional serialization of IconEmoji
        /// Overidden by the presence of IconUrl
        /// </summary>
        /// <returns>false when IconUrl is present otherwise true.</returns>
        public bool ShouldSerializeIconEmoji()
        {
            return IconUrl == null && IconEmoji != Emoji.None;
        }
    }
}
