using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Slack.Webhooks.Interfaces;
using System.Runtime.Serialization;

namespace Slack.Webhooks.Elements
{
    /// <summary>
    /// An object containing some text, formatted either as <see cref="TextType.PlainText"/> or using <see cref="TextType.Markdown"/>, 
    /// our proprietary textual markup that's just different enough from Markdown to frustrate you.
    /// </summary>
    public class TextObject : IContextElement
    {
        
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TextType
        {
            [EnumMember(Value = "plain_text")]
            PlainText,

            [EnumMember(Value = "mrkdwn")]
            Markdown
        }

        /// <summary>
        /// The formatting to use for this text object. Can be one of <see cref="TextType.PlainText"/> or <see cref="TextType.Markdown"/>.
        /// </summary>
        public TextType Type { get; set; }
        /// <summary>
        /// The text for the block. This field accepts any of the standard text formatting markup when type is <see cref="TextType.Markdown"/>.
        /// 
        /// https://api.slack.com/messaging/composing/formatting
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Indicates whether emojis in a text field should be escaped into the colon emoji format. This field is only usable when type is <see cref="TextType.PlainText"/>.
        /// </summary>
        public bool Emoji { get; set; }
        /// <summary>
        /// When set to false (as is default) URLs will be auto-converted into links, conversation names will be link-ified, and certain mentions will be automatically parsed. 
        /// https://api.slack.com/messaging/composing/formatting#automatic-parsing
        /// 
        /// Using a value of true will skip any preprocessing of this nature, although you can still include manual parsing strings. This field is only usable when type is <see cref="TextType.Markdown"/>.
        /// https://api.slack.com/messaging/composing/formatting#advanced
        /// </summary>
        public bool Verbatim { get; set; }

        /// <summary>
        /// Create a new instance of <see cref="TextObject"/>.
        /// </summary>
        public TextObject()
        {
        }

        /// <summary>
        /// Create a new instance of <see cref="TextObject"/> with an initial Text.
        /// </summary>
        public TextObject(string text)
        {
            Text = text;
        }

        public bool ShouldSerializeEmoji()
        {
            return Type == TextType.PlainText;
        }

        public bool ShouldSerializeVerbatim()
        {
            return Type == TextType.Markdown;
        }
    }
}
