using System.Collections.Generic;
using Slack.Webhooks.Interfaces;

namespace Slack.Webhooks.Blocks
{
    /// <summary>
    /// Displays message context, which can include both images and text.
    /// </summary>
    public class Context : Block
    {
        /// <summary>
        /// 	An array of <see cref="Elements.Image"/> elements and <see cref="Elements.TextObject"/>s. Maximum number of items is 10.
        /// </summary>
        public List<IContextElement> Elements { get; set; }

        /// <summary>
        /// Create a new <see cref="Context"/> instance.
        /// </summary>
        public Context() : base(BlockType.Context)
        {
        }
    }
}