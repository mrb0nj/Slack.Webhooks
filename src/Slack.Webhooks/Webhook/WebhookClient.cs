using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Slack.Webhooks.Classes;
using Slack.Webhooks.Interfaces;
using Slack.Webhooks.Messages;

namespace Slack.Webhooks.Webhook
{
    public class WebhookClient : ClientBase, IWebhookClient
    {
        private const string PostSuccess = "ok";
        public WebhookClient(ClientConfiguration configuration) : base(configuration)
        {
        }

        public virtual bool Post(WebhookMessage message)
        {
            var result = PostWebhook(message, false).Result;
            return result;
        }

        public async Task<bool> PostAsync(WebhookMessage webhookMessage)
        {
            return await PostWebhook(webhookMessage);
        }

        public bool PostToChannels(WebhookMessage message, IEnumerable<string> channels)
        {
            return channels.DefaultIfEmpty(message.Channel)
                    .Select(message.Clone)
                    .Select(Post).All(r => r);
        }

        public async Task<bool> PostToChannelsAsync(WebhookMessage message, IEnumerable<string> channels)
        {
            var tasks = channels.DefaultIfEmpty(message.Channel)
                                .Select(message.Clone)
                                .Select(PostWebhook);
            var results = await Task.WhenAll(tasks);
            return results.ToList().All(r => r);
        }

        private async Task<bool> PostWebhook(WebhookMessage message)
        {
            return await PostWebhook(message, true);
        }

        private async Task<bool> PostWebhook(WebhookMessage message, bool configureAwait)
        {
            var response = await PostAsync<string>(Configuration.WebhookUri, message, false, configureAwait);
            return response.Equals(PostSuccess, StringComparison.OrdinalIgnoreCase);
        }
    }
}