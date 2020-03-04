using System;
using System.Net.Http;

namespace Slack.Webhooks.Classes
{
    public class ClientConfiguration
    {
        public Uri WebhookUri { get; set; }
        public string AuthToken { get; set; }
        public HttpClient HttpClient { get; set; }
    }
}