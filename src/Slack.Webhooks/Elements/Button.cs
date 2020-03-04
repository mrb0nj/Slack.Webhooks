using Slack.Webhooks.Blocks;
using Slack.Webhooks.Classes;
using Slack.Webhooks.Interfaces;
using Slack.Webhooks.Message;

namespace Slack.Webhooks.Elements
{
    /// <summary>
    /// Works with <see cref="Blocks.Section"/> and <see cref="ActionsBlock"/> blocks.
    /// 
    /// An interactive component that inserts a button. The button can be a trigger for anything from opening a simple link to starting a complex workflow.
    /// 
    /// To use interactive components, you will need to make some changes to prepare your app. Read our guide to enabling interactivity.
    /// </summary>
    public class Button : Element, IActionElement
    {
        /// <summary>
        /// A <see cref="TextObject"/> that defines the button's text. Can only be of type: <see cref="TextObject.TextType.PlainText"/>. Maximum length for the text in this field is 75 characters.
        /// </summary>
        public TextObject Text { get; set; }
        /// <summary>
        /// An identifier for this action. You can use this when you receive an interaction payload 
        /// to identify the source of the action. Should be unique among all other action_ids used elsewhere by your app. 
        /// Maximum length for this field is 255 characters.
        ///
        /// https://api.slack.com/interactivity/handling#payloads
        /// </summary>
        public string ActionId { get; set; }
        /// <summary>
        /// A URL to load in the user's browser when the button is clicked. 
        /// Maximum length for this field is 3000 characters. 
        /// If you're using url, you'll still receive an interaction payload and will need to send an acknowledgement response.
        ///
        /// https://api.slack.com/interactivity/handling#payloads
        /// https://api.slack.com/interactivity/handling#acknowledgment_response
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// The value to send along with the interaction payload. Maximum length for this field is 2000 characters.
        ///
        /// https://api.slack.com/interactivity/handling#payloads
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Decorates buttons with alternative visual color schemes. Use this option with restraint.
        /// 
        /// "primary" gives buttons a green outline and text, ideal for affirmation or confirmation actions. "primary" should only be used for one button within a set.
        /// 
        /// "danger" gives buttons a red outline and text, and should be used when the action is destructive. Use "danger" even more sparingly than "primary".
        /// 
        /// If you don't include this field, the default button style will be used.
        /// </summary>
        public string Style { get; set; }
        /// <summary>
        /// A <see cref="Confirmation"/> object that defines an optional confirmation dialog after the button is clicked.
        /// </summary>
        public Confirmation Confirm { get; set; }

        /// <summary>
        /// Create a new <see cref="Button"/> instance.
        /// </summary>
        public Button() : base(ElementType.Button)
        {
        }
    }
}