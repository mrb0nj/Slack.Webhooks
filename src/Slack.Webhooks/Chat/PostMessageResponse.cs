using Newtonsoft.Json;
using Slack.Webhooks.Classes;

namespace Slack.Webhooks.Chat
{
    public class PostMessageResponse : ResponseBase
    {
        [JsonProperty(PropertyName = "channel")]
        public string Channel { get; set; }
        
        [JsonProperty(PropertyName = "ts")]
        public string ThreadId { get; set; }
        
        [JsonProperty(PropertyName = "message")]
        public MessageResponse Message { get; set; }
    }
}