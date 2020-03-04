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
            var result = PostWebhook(message).GetAwaiter().GetResult();
            return result;
        }

        public bool PostToChannels(WebhookMessage message, IEnumerable<string> channels)
        {
            return channels.DefaultIfEmpty(message.Channel)
                    .Select(message.Clone)
                    .Select(Post).All(r => r);
        }

        public IEnumerable<Task<bool>> PostToChannelsAsync(WebhookMessage message, IEnumerable<string> channels)
        {
            return channels.DefaultIfEmpty(message.Channel)
                                .Select(message.Clone)
                                .Select(PostWebhook);
        }

        public async Task<bool> PostWebhook(WebhookMessage message)
        {
            var response = await PostAsync<string>(Configuration.WebhookUri, message, false);
            return response.Equals(PostSuccess, StringComparison.OrdinalIgnoreCase);
        }
    }
}