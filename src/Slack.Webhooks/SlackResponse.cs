using Newtonsoft.Json;

namespace Slack.Webhooks
{
    public class SlackResponse
    {
        [JsonProperty(PropertyName = "ok")]
        public bool Ok { get; set; }
        
        [JsonProperty(PropertyName = "channel")]
        public string Channel { get; set; }
        
        [JsonProperty(PropertyName = "ts")]
        public string ThreadId { get; set; }
        
        [JsonProperty(PropertyName = "message")]
        public Message Message { get; set; }
    }

    public class Message
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        
        [JsonProperty(PropertyName = "subtype")]
        public string SubType { get; set; }
        
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
        
        [JsonProperty(PropertyName = "ts")]
        public string ThreadId { get; set; }
        
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }
        
        [JsonProperty(PropertyName = "bot_id")]
        public string BotId { get; set; }
    }
}