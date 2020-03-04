using System.Collections.Generic;
using System.Threading.Tasks;
using Slack.Webhooks.Webhook;

namespace Slack.Webhooks.Interfaces
{
    public interface IWebhookClient
    {
        bool Post(WebhookMessage webhookMessage);
        bool PostToChannels(WebhookMessage webhookMessage, IEnumerable<string> channels);
        IEnumerable<Task<bool>> PostToChannelsAsync(WebhookMessage webhookMessage, IEnumerable<string> channels);
    }
}
