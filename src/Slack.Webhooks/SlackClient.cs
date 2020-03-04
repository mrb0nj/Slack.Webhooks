using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Slack.Webhooks.Chat;
using Slack.Webhooks.Classes;
using Slack.Webhooks.Helpers;
using Slack.Webhooks.Interfaces;
using Slack.Webhooks.Messages;
using Slack.Webhooks.Webhook;

namespace Slack.Webhooks
{
    public class SlackClient : IDisposable
    {
        private readonly ClientConfiguration _configuration;
        public int TimeoutMs => (int)_configuration.HttpClient.Timeout.TotalMilliseconds;

        #region Api
        public WebhookClient Webhook { get; private set; }
        public ChatClient Chat { get; private set; }
        #endregion

        public SlackClient(string webhookUrl = null, int timeout = 100, HttpClient httpClient = null)
        {
            if (!Uri.TryCreate(webhookUrl, UriKind.Absolute, out var webhookUri))
                throw new ArgumentException("Please enter a valid webhook url");

            _configuration = new ClientConfiguration
            {
                HttpClient = httpClient ?? new HttpClient { Timeout = TimeSpan.FromSeconds(timeout) },
                WebhookUri = webhookUri
            };

            Configure();
        }

        public SlackClient(ClientConfiguration configuration)
        {
            _configuration = configuration;
            Configure();
        }

        private void Configure()
        {
            Webhook = new Webhook.WebhookClient(_configuration);
            Chat = new ChatClient(_configuration);
        }

        public void Dispose()
        {
            _configuration.HttpClient.Dispose();
        }
    }
}
