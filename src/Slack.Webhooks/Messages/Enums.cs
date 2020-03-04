using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Slack.Webhooks.Message
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ParseMode
    {
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "full")]
        Full
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ActionDataSource
    {
        [EnumMember(Value = "static")]
        Static,
        [EnumMember(Value = "users")]
        Users,
        [EnumMember(Value = "channels")]
        Channels,
        [EnumMember(Value = "conversations")]
        Conversations,
        [EnumMember(Value = "external")]
        External
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ActionStyle
    {
        [EnumMember(Value = "default")]
        Default,
        [EnumMember(Value = "primary")]
        Primary,
        [EnumMember(Value = "danger")]
        Danger
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ActionType
    {
        [EnumMember(Value = "button")]
        Button,
        [EnumMember(Value = "select")]
        Select
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum BlockType
    {
        [EnumMember(Value = "divider")]
        Divider = 1,
        [EnumMember(Value = "image")]
        Image = 2,
        [EnumMember(Value = "text")]
        Text = 3,
        [EnumMember(Value = "section")]
        Section = 4,
        [EnumMember(Value = "context")]
        Context = 5,
        [EnumMember(Value = "file")]
        File = 6,
        [EnumMember(Value = "actions")]
        Actions = 7,
        [EnumMember(Value = "input")]
        Input = 8
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ElementType
    {
        Unknown = 0,
        [EnumMember(Value = "button")]
        Button = 1,
        [EnumMember(Value = "datepicker")]
        DatePicker = 2,
        [EnumMember(Value = "image")]
        Image = 3,
        [EnumMember(Value = "multi_static_select")]
        MultiSelectStatic = 4,
        [EnumMember(Value = "multi_external_select")]
        MultiSelectExternal = 5,
        [EnumMember(Value = "multi_users_select")]
        MultiSelectUsers = 6,
        [EnumMember(Value = "multi_conversations_select")]
        MultiSelectConversations = 7,
        [EnumMember(Value = "multi_channels_select")]
        MultiSelectChannels = 8,
        [EnumMember(Value = "overflow")]
        Overflow = 9,
        [EnumMember(Value = "plain_text_input")]
        PlainTextInput = 10,
        [EnumMember(Value = "radio_buttons")]
        RadioButtons = 11,
        [EnumMember(Value = "static_select")]
        SelectStatic = 12,
        [EnumMember(Value = "external_select")]
        SelectExternal = 13,
        [EnumMember(Value = "users_select")]
        SelectUsers = 14,
        [EnumMember(Value = "conversations_select")]
        SelectConversations = 15,
        [EnumMember(Value = "channels_select")]
        SelectChannels = 16,
    }
}
