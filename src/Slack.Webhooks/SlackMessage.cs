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
        public string IconEmoji { get; set; }
		/// <summary>
		/// Optional emoji url displayed with the message
		/// </summary>
		public string IconUrl { get; set; }
        /// <summary>
        /// Optional override markdown mode. Default: true
        /// </summary>
        public bool Mrkdwn
        {
            get { return _markdown; }
            set { _markdown = value; }
        }
        /// <summary>
        /// Optional attachment collection
        /// </summary>
        public IList<SlackAttachment> Attachments { get; set; }
    }
}
