using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Slack.Webhooks.Api
{
    public class Webhook : ApiBase
    {
        private const string POST_SUCCESS = "ok";
        public Webhook(SlackConfiguration configuration) : base(configuration)
        {
        }

        public virtual bool Post(SlackMessage slackMessage)
        {
            var result = PostWebhook(slackMessage).GetAwaiter().GetResult();
            return result;
        }

        public bool PostToChannels(SlackMessage message, IEnumerable<string> channels)
        {
            return channels.DefaultIfEmpty(message.Channel)
                    .Select(message.Clone)
                    .Select(Post).All(r => r);
        }

        public IEnumerable<Task<bool>> PostToChannelsAsync(SlackMessage message, IEnumerable<string> channels)
        {
            return channels.DefaultIfEmpty(message.Channel)
                                .Select(message.Clone)
                                .Select(PostWebhook);
        }

        public async Task<bool> PostWebhook(SlackMessage slackMessage)
        {
            var response = await PostAsync<string>(configuration.WebhookUri, slackMessage, false);
            return response.Equals(POST_SUCCESS, StringComparison.OrdinalIgnoreCase);
        }
    }
}