using System.Collections.Generic;
using Slack.Webhooks.Blocks;
using Slack.Webhooks.Classes;
using Slack.Webhooks.Interfaces;
using Slack.Webhooks.Message;

namespace Slack.Webhooks.Elements
{
    public class Select : Element
    {
        /// <summary>
        /// An identifier for the action triggered when a menu option is selected. 
        /// You can use this when you receive an interaction payload to identify the source of the action. 
        /// Should be unique among all other <see cref="ActionId"/>s used elsewhere by your app. 
        /// Maximum length for this field is 255 characters.
        /// </summary>
        public string ActionId { get; set; }
        /// <summary>
        /// A <see cref="TextObject.TextType.PlainText"/> only <see cref="TextObject"/> that defines the placeholder text shown on the menu. 
        /// Maximum length for the text in this field is 150 characters.
        /// </summary>
        public TextObject Placeholder { get; set; }
        /// <summary>
        /// A <see cref="Confirmation"/> object that defines an optional confirmation dialog that appears before the choice(s) are submitted
        /// </summary>
        public Confirmation Confirm { get; set; }
        public Select(ElementType elementType) : base(elementType)
        {
        }
    }

    /// <summary>
    /// Works with <see cref="SectionBlock"/>, <see cref="ActionsBlock"/> and <see cref="InputBlock"/> blocks.
    /// 
    /// This is the simplest form of select menu, with a static list of options passed in when defining the element.
    /// </summary>
    public class SelectStatic : Select, IActionElement, IInputElement
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
        ///	A single <see cref="Option"/> that exactly match one 
        /// of the options within <see cref="Options"/> or <see cref="OptionGroups"/>. 
        /// This option will be selected when the menu initially loads.
        /// </summary>
        public Option InitialOption { get; set; }

        public SelectStatic() : base(ElementType.SelectStatic)
        {
        }
    }

    /// <summary>
    /// Works with <see cref="SectionBlock"/>, <see cref="ActionsBlock"/> and <see cref="InputBlock"/> blocks.
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
    public class SelectExternal : Select, IActionElement, IInputElement
    {
        /// <summary>
        /// When the typeahead field is used, a request will be sent on every 
        /// character change. If you prefer fewer requests or more fully ideated queries, 
        /// use the <see cref="MinQueryLength"/> attribute to tell Slack the fewest 
        /// number of typed characters required before dispatch.
        /// </summary>
        public int MinQueryLength { get; set; }
        /// <summary>
        ///	A single <see cref="Option"/> that exactly match one 
        /// of the options within <see cref="Options"/> or <see cref="OptionGroups"/>. 
        /// This option will be selected when the menu initially loads.
        /// </summary>
        public Option InitialOption { get; set; }

        public SelectExternal() : base(ElementType.SelectExternal)
        {
        }
    }
    
    /// <summary>
    /// Works with <see cref="SectionBlock"/>, <see cref="ActionsBlock"/> and <see cref="InputBlock"/> blocks.
    /// 
    /// This select menu will populate its options with a list of Slack users visible to the current user in the active workspace.
    /// </summary>
    public class SelectUsers : Select, IActionElement, IInputElement
    {
        /// <summary>
        /// The user ID of any valid user to be pre-selected when the menu loads.
        /// </summary>
        public string InitialUser { get; set; }
        
        public SelectUsers() : base(ElementType.SelectUsers)
        {
        }
    }

    /// <summary>
    /// Works with <see cref="SectionBlock"/>, <see cref="ActionsBlock"/> and <see cref="InputBlock"/> blocks.
    /// 
    /// This select menu will populate its options with a list of public and private channels, DMs, and MPIMs visible to the current user in the active workspace.
    /// </summary>
    public class SelectConversations : Select, IActionElement, IInputElement
    {
        /// <summary>
        /// The ID of any valid conversation to be pre-selected when the menu loads.
        /// </summary>
        public string InitialConversation { get; set; }
        
        public SelectConversations() : base(ElementType.SelectConversations)
        {
        }
    }

    /// <summary>
    /// Works with <see cref="SectionBlock"/>, <see cref="ActionsBlock"/> and <see cref="InputBlock"/> blocks.
    /// 
    /// This select menu will populate its options with a list of public channels visible to the current user in the active workspace.
    /// </summary>
    public class SelectChannels : Select, IActionElement, IInputElement
    {
        /// <summary>
        /// The ID of any valid public channel to be pre-selected when the menu loads.
        /// </summary>
        public string InitialChannel { get; set; }
        
        public SelectChannels() : base(ElementType.SelectChannels)
        {
        }
    }
}