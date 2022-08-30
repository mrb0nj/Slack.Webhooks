using Newtonsoft.Json;
using Slack.Webhooks.Interfaces;

namespace Slack.Webhooks.Elements
{
    /// <summary>
    /// Works with <see cref="Blocks.Section"/>, <see cref="Blocks.Actions"/> and <see cref="Blocks.Input"/> blocks.
    /// 
    /// A plain-text input, similar to the HTML &lt;input&gt; tag, creates a field where a user can enter freeform data. It can appear as a single-line field or a larger textarea using the <see cref="MultiLine"/>> flag.
    /// 
    /// Plain-text input elements are currently only available in modals. To use them, you will need to make some changes to prepare your app. Read about preparing your app for modals.
    /// https://api.slack.com/surfaces/modals/using#preparing_for_modals
    /// </summary>
    public class PlainTextInput : Element, IInputElement
    {
        /// <summary>
        /// An identifier for the action triggered when a menu option is selected. 
        /// You can use this when you receive an interaction payload to identify the source of the action. 
        /// Should be unique among all other <see cref="ActionId"/>s used elsewhere by your app. 
        /// Maximum length for this field is 255 characters.
        /// </summary>
        public string ActionId { get; set; }
        /// <summary>
        /// A <see cref="TextObject.TextType.PlainText"/> only <see cref="TextObject"/> that defines the placeholder text shown in the plain-text input. 
        /// Maximum length for the <see cref="TextObject.Text"/> in this field is 150 characters.
        /// </summary>
        public TextObject Placeholder { get; set; }
        /// <summary>
        /// The initial value in the plain-text input when it is loaded.
        /// </summary>
        public string InitialValue { get; set; }
        /// <summary>
        /// Indicates whether the input will be a single line (false) or a larger textarea (true). Defaults to false.
        /// </summary>
        [JsonProperty("multiline")]
        public bool MultiLine { get; set; }
        /// <summary>
        /// The minimum length of input that the user must provide. If the user provides less, they will receive an error. Maximum value is 3000.
        /// </summary>
        public int MinLength { get; set; }
        /// <summary>
        /// The maximum length of input that the user can provide. If the user provides more, they will receive an error.
        /// </summary>
        public int MaxLength { get; set; }
        
        public PlainTextInput() : base(ElementType.PlainTextInput)
        {
        }
    }
}