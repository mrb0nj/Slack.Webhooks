using Newtonsoft.Json;

namespace Slack.Webhooks.Chat
{
    public class DeleteRequest
    {
        public string Channel { get; set; }
        [JsonProperty(PropertyName = "ts")]
        public string ThreadId { get; set; }
    }
}