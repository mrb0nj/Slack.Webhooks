using System.Collections.Generic;
using Slack.Webhooks.Classes;
using Slack.Webhooks.Elements;
using Slack.Webhooks.Message;

namespace Slack.Webhooks.Blocks
{
    /// <summary>
    /// A <see cref="SectionBlock"/> is one of the most flexible blocks available - it can be used as a simple text block, 
    /// in combination with text fields, or side-by-side with any of the available block elements.
    /// </summary>
    public class SectionBlock : BlockBase
    {
        /// <summary>
        /// The <see cref="Text"/> for the block, in the form of a <see cref="TextObject"/>. Maximum length for the text in this field is 3000 characters.
        /// </summary>
        public TextObject Text { get; set; }
        /// <summary>
        /// An array of <see cref="TextObject"/>s. Any text objects included with <see cref="Fields"/> will be rendered in a compact 
        /// format that allows for 2 columns of side-by-side text. Maximum number of items is 10. 
        /// Maximum length for the text in each item is 2000 characters.
        /// </summary>
        public IList<TextObject> Fields { get; set; }
        /// <summary>
        /// One of the available <see cref="Element"/> objects.
        /// </summary>
        public Element Accessory { get; set; }

        /// <summary>
        /// Create a new <see cref="SectionBlock"/> instance.
        /// </summary>
        public SectionBlock() : base(BlockType.Section)
        {
            
        }
    }
}
