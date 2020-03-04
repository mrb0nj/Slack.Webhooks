using Slack.Webhooks.Blocks;
using Slack.Webhooks.Classes;
using Slack.Webhooks.Interfaces;
using Slack.Webhooks.Message;

namespace Slack.Webhooks.Elements
{
    /// <summary>
    /// Works with <see cref="SectionBlock"/>, <see cref="ActionsBlock"/> and <see cref="InputBlock"/> blocks.
    /// 
    /// An element which lets users easily select a date from a calendar style UI.
    /// 
    /// To use interactive components like this, you will need to make some changes to prepare your app. Read our guide to enabling interactivity.
    /// https://api.slack.com/interactivity/handling
    /// </summary>
    public class DatePicker : Element, IActionElement, IInputElement
    {
        /// <summary>
        /// An identifier for the action triggered when a menu option is selected. 
        /// You can use this when you receive an interaction payload to identify the source of the action. 
        /// Should be unique among all other <see cref="ActionId"/>s used elsewhere by your app. 
        /// Maximum length for this field is 255 characters.
        /// </summary>
        public string ActionId { get; set; }
        /// <summary>
        /// A <see cref="TextObject.TextType.PlainText"/> only <see cref="TextObject"/> that defines the placeholder text shown on the datepicker. 
        /// Maximum length for the text in this field is 150 characters.
        /// </summary>
        public TextObject Placeholder { get; set; }
        /// <summary>
        /// The initial date that is selected when the element is loaded. This should be in the format YYYY-MM-DD.
        /// </summary>
        public string InitialDate { get; set; }
        /// <summary>
        /// A <see cref="Confirmation"/> object that defines an optional confirmation dialog that appears after a date is selected.
        /// </summary>
        public Confirmation Confirm { get; set; }

        /// <summary>
        /// Create a new <see cref="DatePicker"/> instance.
        /// </summary>
        public DatePicker() : base(ElementType.DatePicker)
        {
            
        }
    }
}