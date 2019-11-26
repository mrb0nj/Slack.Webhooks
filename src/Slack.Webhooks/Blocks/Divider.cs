namespace Slack.Webhooks.Blocks
{
    /// <summary>
    /// A content divider, like an &lt;hr&gt;, to split up different blocks inside of a message. The divider block is nice and neat, requiring only a <see cref="Block.Type"/>.
    /// </summary>
    public class Divider : Block
    {
        /// <summary>
        /// Create a new <see cref="Divider"/> instance.
        /// </summary>
        public Divider() : base(BlockType.Divider)
        {
        }
    }
}
