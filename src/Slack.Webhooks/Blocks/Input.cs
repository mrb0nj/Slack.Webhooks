using Slack.Webhooks.Elements;
using Slack.Webhooks.Interfaces;

namespace Slack.Webhooks.Blocks
{
    /// <summary>
    /// A block that collects information from users - it can hold a <see cref="Elements.PlainTextInput"/> element, 
    /// a <see cref="Elements.Select"/> menu element, a multi-select menu element, or a <see cref="Elements.DatePicker"/>.
    /// 
    /// Read our guide to using modals to learn how input blocks pass information to your app.
    /// https://api.slack.com/surfaces/modals/using#gathering_input
    /// </summary>
    /// <seealso cref="Interfaces.IInputElement"/>
    /// <seealso cref="Elements.PlainTextInput"/>
    /// <seealso cref="Elements.SelectUsers"/>
    /// <seealso cref="Elements.SelectChannels"/>
    /// <seealso cref="Elements.SelectConversations"/>
    /// <seealso cref="Elements.SelectStatic"/>
    /// <seealso cref="Elements.SelectExternal"/>
    /// <seealso cref="Elements.MultiSelectUsers"/>
    /// <seealso cref="Elements.MultiSelectChannels"/>
    /// <seealso cref="Elements.MultiSelectConversations"/>
    /// <seealso cref="Elements.MultiSelectStatic"/>
    /// <seealso cref="Elements.MultiSelectExternal"/>
    /// <seealso cref="Elements.DatePicker"/>
    public class Input : Block
    {
        /// <summary>
        /// A label that appears above an <see cref="Input"/> element in the form of a <see cref="TextObject"/> that can only be of <see cref="TextObject.TextType.PlainText"/>. 
        /// Maximum length for the text in this field is 2000 characters.
        /// </summary>
        public TextObject Label { get; set; }
        /// <summary>
        /// An optional hint that appears below an input element in a lighter grey. It must be a <see cref="TextObject"/> that can only be of <see cref="TextObject.TextType.PlainText"/>. 
        /// Maximum length for the text in this field is 2000 characters.
        /// </summary>
        public TextObject Hint { get; set; }
        /// <summary>
        /// A boolean that indicates whether the input element may be empty when a user submits the modal. Defaults to false.
        /// </summary>
        public bool Optional { get; set; }
        /// <summary>
        /// An <see cref="Elements.PlainTextInput"/> element, a <see cref="Elements.Select"/> menu element, a multi-select menu element, or a <see cref="Elements.DatePicker"/>.
        /// </summary>
        public IInputElement Element { get; set; }

        /// <summary>
        /// Create a new <see cref="Input"/> instance.
        /// </summary>
        public Input() : base(BlockType.Input)
        {
            
        }
    }
}