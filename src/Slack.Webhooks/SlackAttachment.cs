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
        public string Pretext { get; set; }
        /// <summary>
        /// Can either be one of 'good', 'warning', 'danger', or any hex color code
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// Small text used to display the author's name.
        /// </summary>
        public string AuthorName { get; set; }
        /// <summary>
        /// A valid URL that will hyperlink the AuthorName. 
        /// Will only work if author_name is present.
        /// </summary>
        public string AuthorLink { get; set; }
        /// <summary>
        /// A valid URL that displays a small 16x16px image to the left of the AuthorName.
        /// Will only work if AuthorName is present.
        /// </summary>
        public string AuthorIcon { get; set; }
        /// <summary>
        /// Optional title, displayed in bold near the top of the message attachment.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Optional link applied to the Title if present
        /// </summary>
        public string TitleLink { get; set; }
        /// <summary>
        /// A valid URL to an image file that will be displayed inside a message attachment.
        /// Currently GIF, JPEG, PNG and BMP formats are supported
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// Fields are displayed in a table on the message
        /// </summary>
        public List<SlackField> Fields { get; set; }
        /// <summary>
        /// Optional list of proporties where markdown syntax will be parsed
        /// applicable to fields, title, and pretext
        /// </summary>
        public List<string> Mrkdwn_in { get; set; }
    }
}
