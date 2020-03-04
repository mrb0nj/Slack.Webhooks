using Newtonsoft.Json;

namespace Slack.Webhooks.Chat
{
    public class PermalinkRequest
    {
        public string Channel { get; set; }
        [JsonProperty(PropertyName = "message_ts")]
        public string ThreadId { get; set; }
    }
}