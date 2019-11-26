using System.Collections.Generic;

namespace Slack.Webhooks.Elements
{
    /// <summary>
    /// Works with <see cref="Blocks.Section"/>, <see cref="Blocks.Actions"/> and <see cref="Blocks.Input"/> blocks.
    /// 
    /// A radio button group that allows a user to choose one item from a list of possible options.
    /// 
    /// Radio buttons are only supported in the following app surfaces: Home tabs
    /// https://api.slack.com/surfaces/tabs
    /// 
    /// To use interactive components like this, you will need to make some changes to prepare your app. Read our guide to enabling interactivity.
    /// https://api.slack.com/interactivity/handling
    /// </summary>
    public class RadioButtons : Element
    {
        /// <summary>
        /// An identifier for the action triggered when a menu option is selected. 
        /// You can use this when you receive an interaction payload to identify the source of the action. 
        /// Should be unique among all other <see cref="ActionId"/>s used elsewhere by your app. 
        /// Maximum length for this field is 255 characters.
        /// </summary>
        public string ActionId { get; set; }
        /// <summary>
        /// An array of <see cref="Option"/> objects.
        /// </summary>
        public IList<Option> Options { get; set; }
        /// <summary>
        /// An <see cref="Option"/> object that exactly matches one of the options within <see cref="Options"/>. This option will be selected when the radio button group initially loads.
        /// </summary>
        public Option InitialOption { get; set; }
        /// <summary>
        /// A <see cref="Confirmation"/> object that defines an optional confirmation dialog that appears after clicking one of the radio buttons in this element.
        /// </summary>
        public Confirmation Confirm { get; set; }

        public RadioButtons() : base(ElementType.RadioButtons)
        {
            
        }
    }
}