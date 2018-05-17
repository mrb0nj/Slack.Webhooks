using System.Collections.Generic;
using Slack.Webhooks.Action;

namespace Slack.Webhooks
{
    /// <summary>
    /// Slack attachment action. An attachment can have zero or more actions.
    /// </summary>
    public class SlackAction
    {
        private SlackActionType _type = SlackActionType.Button;
        private SlackActionStyle _style = SlackActionStyle.Default;
        private SlackActionDataSource _dataSource = SlackActionDataSource.Static;

        /// <summary>
        /// Provide a string to give this specific action a name.   
        /// The name will be returned to your Action URL along with 
        /// the message's callback_id when this action is invoked. 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Provide button when this action is a message button or 
        /// provide select when the action is a message menu.
        /// </summary>
        /// <see cref="SlackActionType"/>
        public SlackActionType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        /// <summary>
        /// The user-facing label for the message button or menu 
        /// representing this action. Cannot contain markup. Best 
        /// to keep these short and decisive. Use a maximum of 30 
        /// characters or so for best results across form factors.
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Provide a string identifying this specific action. 
        /// It will be sent to your Action URL along with the name 
        /// and attachment's callback_id. If providing multiple 
        /// actions with the same name, value can be strategically 
        /// used to differentiate intent. Your value may contain 
        /// up to 2000 characters.
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Provide a string identifying the URL for a link button. 
        /// Unlike message buttons, link buttons don't dispatch actions 
        /// to your interactive components request URL.
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Used only with message buttons, this decorates buttons 
        /// with extra visual importance, which is especially useful 
        /// when providing logical default action or highlighting a 
        /// destructive activity.
        /// </summary>
        /// <see cref="SlackActionStyle"/>
        public SlackActionStyle Style
        {
            get { return _style; }
            set { _style = value; }
        }
        /// <summary>
        /// Accepts static, users, channels, conversations, or external. 
        /// Our clever default behavior is default, which means the menu's 
        /// options are provided directly in the posted message under options.
        /// </summary>
        /// <see cref="SlackActionDataSource"/>
        public SlackActionDataSource DataSource
        {
            get { return _dataSource; }
            set { _dataSource = value; }
        }
        /// <summary>
        /// Used only with message menus. The individual options to appear in 
        /// this menu, provided as an array of option fields. Required when 
        /// data_source is static or otherwise unspecified. A maximum of 100 
        /// options can be provided in each menu.
        /// </summary>
        public List<Option> Options { get; set; }
        /// <summary>
        /// Used only with message menus. An alternate, semi-hierarchal way to 
        /// list available options. Provide an array of option group definitions. 
        /// This replaces and supersedes the options array.
        /// </summary>
        public List<OptionGroup> OptionGroups { get; set; }
        /// <summary>
        /// If provided, the first element of this array will be set as the 
        /// pre-selected option for this menu. Any additional elements will be ignored. 
        /// </summary>
        public List<Option> SelectedOptions { get; set; }
        /// <summary>
        /// Only applies when data_source is set to external. If present, Slack will 
        /// wait till the specified number of characters are entered before sending 
        /// a request to your app's external suggestions API endpoint. Defaults to 1.
        /// </summary>
        public int MinQueryLength { get; set; }
        /// <summary>
        /// Protect users from destructive actions or particularly distinguished decisions 
        /// by asking them to confirm their button click one more time. 
        /// Use confirmation dialogs with care.
        /// </summary>
        public Confirm Confirm { get; set; }
    }
}
