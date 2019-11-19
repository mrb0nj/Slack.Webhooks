using System.Collections.Generic;
using Slack.Webhooks.Interfaces;

namespace Slack.Webhooks.Blocks
{
    /// <summary>
    /// A block that is used to hold interactive <see cref="Interfaces.IActionElement"/>s.
    /// </summary>
    public class Actions : Block
    {
        /// <summary>
        /// An array of interactive element objects - <see cref="Elements.Button"/>, <see cref="Elements.Select"/> menus, <see cref="Elements.Overflow"/> menus, or <see cref="Elements.DatePicker"/>. 
        /// There is a maximum of 5 elements in each action block.
        /// </summary>
        /// <seealso cref="Interfaces.IActionElement"/>
        /// <seealso cref="Elements.Button"/>
        /// <seealso cref="Elements.SelectUsers"/>
        /// <seealso cref="Elements.SelectChannels"/>
        /// <seealso cref="Elements.SelectConversations"/>
        /// <seealso cref="Elements.SelectStatic"/>
        /// <seealso cref="Elements.SelectExternal"/>
        /// <seealso cref="Elements.Overflow"/>
        /// <seealso cref="Elements.DatePicker"/>
        public IList<IActionElement> Elements { get; set; }

        /// <summary>
        /// Create a new <see cref="Actions"/> instance.
        /// </summary>
        public Actions() : base(BlockType.Actions)
        {
        }
    }
}