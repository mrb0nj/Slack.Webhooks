using System.Collections.Generic;

namespace Slack.Webhooks.Elements
{
    /// <summary>
    /// Provides a way to group options in a <see cref="Elements.Select"/>  menu or multi-select menu.
    /// </summary>
    /// <seealso cref="Elements.SelectUsers"/>
    /// <seealso cref="Elements.SelectChannels"/>
    /// <seealso cref="Elements.SelectConversations"/>
    /// <seealso cref="Elements.SelectStatic"/>
    /// <seealso cref="Elements.SelectExternal"/>
    /// <seealso cref="Elements.MultiSelectUsers"/>
    /// <seealso cref="Elements.MultiSelectChannels"/>
    /// <seealso cref="Elements.MultiSelectConversations"/>
    /// <seealso cref="Elements.MultiSelectStatic"/>
    /// <seealso cref="Elements.MultiSelectExternal"/>
    public class OptionGroup
    {
        /// <summary>
        /// A <see cref="TextObject.TextType.PlainText"/> only <see cref="TextObject"/> that defines the label shown above this group of options. Maximum length for the <see cref="TextObject.Text"/> in this field is 75 characters.
        /// </summary>
        public TextObject Label { get; set; }
        /// <summary>
        /// An array of <see cref="Option"/> objects that belong to this specific group. Maximum of 100 items.
        /// </summary>
        public IList<Option> Options { get; set; }
    }
}