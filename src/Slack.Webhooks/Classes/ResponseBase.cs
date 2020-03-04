using Newtonsoft.Json;

namespace Slack.Webhooks.Classes
{
    public class ResponseBase
    {
        [JsonProperty(PropertyName = "ok")]
        public bool Ok { get; set; }

        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }
        
        [JsonProperty(PropertyName = "warning")]
        public string Warning { get; set; }
    }
}