using System.Collections.Generic;
using Slack.Webhooks.Classes;
using Slack.Webhooks.Interfaces;
using Slack.Webhooks.Message;

namespace Slack.Webhooks.Blocks
{
    /// <summary>
    /// Displays message context, which can include both images and text.
    /// </summary>
    public class ContextBlock : BlockBase
    {
        /// <summary>
        /// 	An array of <see cref="Elements.Image"/> elements and <see cref="Elements.TextObject"/>s. Maximum number of items is 10.
        /// </summary>
        public List<IContextElement> Elements { get; set; }

        /// <summary>
        /// Create a new <see cref="ContextBlock"/> instance.
        /// </summary>
        public ContextBlock() : base(BlockType.Context)
        {
        }
    }
}