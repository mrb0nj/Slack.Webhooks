using System.Collections.Generic;
using Slack.Webhooks.Interfaces;

namespace Slack.Webhooks.Elements
{
    /// <summary>
    /// Works with <see cref="Blocks.Section"/> and <see cref="Blocks.Actions"/> blocks.
    /// 
    /// This is like a cross between a button and a select menu - when a user clicks on this overflow button, they will be presented with a list of options to choose from. Unlike the select menu, there is no typeahead field, and the button always appears with an ellipsis ("…") rather than customisable text.
    /// 
    /// As such, it is usually used if you want a more compact layout than a select menu, or to supply a list of less visually important actions after a row of buttons. You can also specify simple URL links as overflow menu options, instead of actions.
    /// 
    /// To use interactive components like this, you will need to make some changes to prepare your app. Read our guide to enabling interactivity.
    /// https://api.slack.com/interactivity/handling
    /// </summary>
    public class Overflow : Element, IActionElement
    {
        /// <summary>
        /// An identifier for the action triggered when a menu option is selected. 
        /// You can use this when you receive an interaction payload to identify the source of the action. 
        /// Should be unique among all other <see cref="ActionId"/>s used elsewhere by your app. 
        /// Maximum length for this field is 255 characters.
        /// </summary>
        public string ActionId { get; set; }
        /// <summary>
        /// An array of <see cref="Option"/> objects to display in the menu. Maximum number of options is 5, minimum is 2.
        /// </summary>
        public IList<Option> Options { get; set; }
        /// <summary>
        /// A <see cref="Confirmation"/> object that defines an optional confirmation dialog that appears after a menu item is selected.
        /// </summary>
        public Confirmation Confirm { get; set; }
        public Overflow() : base(ElementType.Overflow)
        {
            
        }
    }
}