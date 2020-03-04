using Newtonsoft.Json;
using Slack.Webhooks.Classes;

namespace Slack.Webhooks.Chat
{
    public class DeleteResponse : ResponseBase
    {
        public string Channel { get; set; }
        [JsonProperty(PropertyName = "ts")]
        public string ThreadId { get; set; }
    }
}