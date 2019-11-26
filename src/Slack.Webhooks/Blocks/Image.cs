using Slack.Webhooks.Elements;
using Slack.Webhooks.Interfaces;

namespace Slack.Webhooks.Blocks
{
    /// <summary>
    /// A simple image block, designed to make those cat photos really pop.
    /// </summary>
    public class Image : Block, IContextElement
    {
        /// <summary>
        /// The URL of the image to be displayed. Maximum length for this field is 3000 characters.
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// A plain-text summary of the image. This should not contain any markup. Maximum length for this field is 2000 characters.
        /// </summary>
        public string AltText { get; set; }
        /// <summary>
        /// An optional title for the image in the form of a <see cref="TextObject"/> that can only be of <see cref="TextObject.TextType.PlainText"/>. 
        /// Maximum length for the text in this field is 2000 characters.
        /// </summary>
        public TextObject Title { get; set; }

        /// <summary>
        /// Create a new <see cref="Image" instance.
        /// </summary>
        public Image() : base(BlockType.Image)
        {

        }
    }
}
