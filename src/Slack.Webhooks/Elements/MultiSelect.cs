using System.Collections.Generic;
using Slack.Webhooks.Blocks;
using Slack.Webhooks.Classes;
using Slack.Webhooks.Interfaces;
using Slack.Webhooks.Message;

namespace Slack.Webhooks.Elements
{
    /// <summary>
    /// Works with <see cref="SectionBlock"/> and <see cref="InputBlock"/> blocks.
    /// 
    /// This is the simplest form of select menu, with a static list of options passed in when defining the element.
    /// </summary>
    public class MultiSelectStatic : Select, IInputElement
    {
        /// <summary>
        ///	An array of <see cref="Option"/> objects. 
        /// Maximum number of options is 100. 
        /// If <see cref="OptionGroups"/> is specified, this field should not be.
        /// </summary>
        public List<Option> Options { get; set; }
        /// <summary>
        ///	An array of <see cref="OptionGroups"/> objects. 
        /// Maximum number of options is 100. 
        /// If <see cref="Option"/> is specified, this field should not be.
        /// </summary>
        public List<OptionGroup> OptionGroups { get; set; }
        /// <summary>
        ///	An array of <see cref="Option"/> objects that exactly match one or 
        /// more of the options within <see cref="Options"/> or <see cref="OptionGroups"/>. 
        /// These options will be selected when the menu initially loads.
        /// </summary>
        public List<Option> InitialOptions { get; set; }

        public MultiSelectStatic() : base(ElementType.MultiSelectStatic)
        {
        }
    }

    /// <summary>
    /// Works with <see cref="SectionBlock"/> and <see cref="InputBlock"/> blocks.
    /// 
    /// This menu will load its options from an external data source, allowing for a dynamic list of options.
    /// 
    /// Setup
    /// To use this menu type, you'll need to configure your app first:
    /// 
    /// Goto your app's settings page and choose the Interactive Components feature menu.
    /// Add a URL to the Options Load URL under Select Menus.
    /// Save changes.
    /// Each time a menu of this type is opened or the user starts typing in the typeahead field, we'll send a request to your specified URL. Your app should return an HTTP 200 OK response, along with an application/json post body with an object containing either an options array, or an option_groups array.
    /// </summary>
    public class MultiSelectExternal : Select, IInputElement
    {
        /// <summary>
        /// When the typeahead field is used, a request will be sent on every 
        /// character change. If you prefer fewer requests or more fully ideated queries, 
        /// use the <see cref="MinQueryLength"/> attribute to tell Slack the fewest 
        /// number of typed characters required before dispatch.
        /// </summary>
        public int MinQueryLength { get; set; }
        /// <summary>
        ///	An array of <see cref="Option"/> objects that exactly match one or 
        /// more of the options within <see cref="Options"/> or <see cref="OptionGroups"/>. 
        /// These options will be selected when the menu initially loads.
        /// </summary>
        public IList<Option> InitialOptions { get; set; }

        public MultiSelectExternal() : base(ElementType.MultiSelectExternal)
        {
        }
    }
    
    /// <summary>
    /// Works with <see cref="SectionBlock"/> and <see cref="InputBlock"/> blocks.
    /// 
    /// This multi-select menu will populate its options with a list of Slack users visible to the current user in the active workspace.
    /// </summary>
    public class MultiSelectUsers : Select, IInputElement
    {
        /// <summary>
        /// An array of user IDs of any valid users to be pre-selected when the menu loads.
        /// </summary>
        public IList<string> InitialUsers { get; set; }
        
        public MultiSelectUsers() : base(ElementType.MultiSelectUsers)
        {
        }
    }

    /// <summary>
    /// Works with <see cref="SectionBlock"/> and <see cref="InputBlock"/> blocks.
    /// 
    /// This multi-select menu will populate its options with a list of public and private channels, DMs, and MPIMs visible to the current user in the active workspace.
    /// </summary>
    public class MultiSelectConversations : Select, IInputElement
    {
        /// <summary>
        /// An array of one or more IDs of any valid conversations to be pre-selected when the menu loads.
        /// </summary>
        public IList<string> InitialConversations { get; set; }
        
        public MultiSelectConversations() : base(ElementType.MultiSelectConversations)
        {
        }
    }

    /// <summary>
    /// Works with <see cref="SectionBlock"/> and <see cref="InputBlock"/> blocks.
    /// 
    /// This multi-select menu will populate its options with a list of public channels visible to the current user in the active workspace.
    /// </summary>
    public class MultiSelectChannels : Select, IInputElement
    {
        /// <summary>
        /// An array of one or more IDs of any valid public channel to be pre-selected when the menu loads.
        /// </summary>
        public IList<string> InitialChannels { get; set; }
        
        public MultiSelectChannels() : base(ElementType.MultiSelectChannels)
        {
        }
    }
}