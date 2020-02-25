using System;
using System.Net.Http;

namespace Slack.Webhooks
{
    public class SlackConfiguration
    {
        public Uri WebhookUri { get; set; }
        public string AuthToken { get; set; }
        public HttpClient HttpClient { get; set; }
    }
}