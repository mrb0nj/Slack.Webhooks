using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Slack.Webhooks
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
    public enum SlackActionDataSource
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
    public enum SlackActionStyle
    {
        [EnumMember(Value = "default")]
        Default,
        [EnumMember(Value = "primary")]
        Primary,
        [EnumMember(Value = "danger")]
        Danger
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum SlackActionType
    {
        [EnumMember(Value = "button")]
        Button,
        [EnumMember(Value = "select")]
        Select
    }
}
