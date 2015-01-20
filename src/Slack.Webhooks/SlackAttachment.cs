using System.Collections.Generic;

namespace Slack.Webhooks
{
    /// <summary>
    /// Slack message attachment. A message can have zero or more attachments.
    /// </summary>
    public class SlackAttachment
    {
        /// <summary>
        /// Required text summary of the attachment that is shown by clients that understand attachments but choose not to show them.
        /// </summary>
        public string Fallback { get; set; }
        /// <summary>
        /// Optional text that should appear within the attachment
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Optional text that should appear above the formatted data
        /// </summary>
        public string PreText { get; set; }
        /// <summary>
        /// Can either be one of 'good', 'warning', 'danger', or any hex color code
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// Fields are displayed in a table on the message
        /// </summary>
        public List<SlackField> Fields { get; set; }
    }
}
