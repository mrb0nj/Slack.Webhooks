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
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Optional override of destination channel
        /// </summary>
        [JsonProperty("channel")]
        public string Channel { get; set; }

        /// <summary>
        /// Optional override of the username that is displayed
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// Optional emoji displayed with the message
        /// </summary>
        [JsonProperty("icon_emoji")]
        public string IconEmoji { get; set; }

        /// <summary>
        /// Optional url for icon displayed with the message
        /// </summary>
        [JsonProperty("icon_url")]
        public Uri IconUrl { get; set; }

        /// <summary>
        /// Optional override markdown mode. Default: true
        /// </summary>
        [JsonIgnore]
        public bool Mrkdwn
        {
            get { return _markdown; }
            set { _markdown = value; }
        }

        /// <summary>
        /// Enable linkification of channel and usernames
        /// </summary>
        [JsonProperty("link_names"), JsonIgnore()]
        public bool LinkNames { get; set; }

        /// <summary>
        /// Parse mode <see cref="ParseMode"/>
        /// </summary>
        [JsonProperty("parse")]
        public string Parse { get; set; }

        /// <summary>
        /// Optional attachment collection
        /// </summary>
        [JsonProperty("attachments")]
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
    }
}
