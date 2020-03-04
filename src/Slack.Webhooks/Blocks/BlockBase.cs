using Slack.Webhooks.Classes;
using Slack.Webhooks.Message;

namespace Slack.Webhooks.Blocks
{
    /// <summary>
    /// Blocks are a series of components that can be combined to create visually rich and compellingly interactive messages.
    /// 
    /// Read our guide to composing rich message layouts to learn where and how to use each of these components. You can include up to 50 blocks in each message.
    /// https://api.slack.com/messaging/composing/layouts
    /// </summary>    
    /// <seealso cref="ActionsBlock" />
    /// <seealso cref="ContextBlock" />
    /// <seealso cref="DividerBlock" />
    /// <seealso cref="FileBlock" />
    /// <seealso cref="ImageBlock" />
    /// <seealso cref="InputBlock" />
    /// <seealso cref="SectionBlock" />
    public class BlockBase
    {
        protected readonly BlockType BlockType;
        /// <summary>
        /// The <see cref="Webhooks.Message.BlockType"/> of this instance of <see cref="BlockBase"/>.
        /// </summary>
        public BlockType Type { get { return BlockType; } }
        /// <summary>
        /// A string acting as a unique identifier for a block. 
        /// You can use this block_id when you receive an interaction payload to identify the source of the action. 
        /// If not specified, one will be generated. Maximum length for this field is 255 characters.
        /// </summary>
        public string BlockId { get; set; }

        protected BlockBase(BlockType blockType)
        {
            BlockType = blockType;
        }
    }
}
