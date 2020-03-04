using Slack.Webhooks.Classes;
using Slack.Webhooks.Message;

namespace Slack.Webhooks.Blocks
{
    /// <summary>
    /// A content divider, like an &lt;hr&gt;, to split up different blocks inside of a message. The divider block is nice and neat, requiring only a <see cref="BlockBase.Type"/>.
    /// </summary>
    public class DividerBlock : BlockBase
    {
        /// <summary>
        /// Create a new <see cref="DividerBlock"/> instance.
        /// </summary>
        public DividerBlock() : base(BlockType.Divider)
        {
        }
    }
}
