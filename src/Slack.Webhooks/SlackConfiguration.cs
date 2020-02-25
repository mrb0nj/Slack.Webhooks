using System.Net.Http;
using Newtonsoft.Json;

namespace Slack.Webhooks
{
    public class SlackConfiguration
    {
        public System.Uri WebhookUri { get; set; }
        public string AuthToken { get; set; }
        public HttpClient HttpClient { get; set; }
    }
}