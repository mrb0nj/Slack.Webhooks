using Newtonsoft.Json;
using Slack.Webhooks.Classes;

namespace Slack.Webhooks.Chat
{
    public class PostEphemeralResponse : ResponseBase
    {
        [JsonProperty(PropertyName = "thread_ts")]
        public string ThreadId { get; set; }
    }
}