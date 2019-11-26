namespace Slack.Webhooks
{
    /// <summary>
    /// Blocks are a series of components that can be combined to create visually rich and compellingly interactive messages.
    /// 
    /// Read our guide to composing rich message layouts to learn where and how to use each of these components. You can include up to 50 blocks in each message.
    /// https://api.slack.com/messaging/composing/layouts
    /// </summary>    
    /// <seealso cref="Actions" />
    /// <seealso cref="Context" />
    /// <seealso cref="Divider" />
    /// <seealso cref="File" />
    /// <seealso cref="Image" />
    /// <seealso cref="Input" />
    /// <seealso cref="Section" />
    public class Block
    {
        protected readonly BlockType _blockType;
        /// <summary>
        /// The <see cref="BlockType"/> of this instance of <see cref="Block"/>.
        /// </summary>
        public BlockType Type { get { return _blockType; } }
        /// <summary>
        /// A string acting as a unique identifier for a block. 
        /// You can use this block_id when you receive an interaction payload to identify the source of the action. 
        /// If not specified, one will be generated. Maximum length for this field is 255 characters.
        /// </summary>
        public string BlockId { get; set; }

        protected Block(BlockType blockType)
        {
            _blockType = blockType;
        }
    }
}
