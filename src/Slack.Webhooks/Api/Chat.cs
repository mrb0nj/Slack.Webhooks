using System;
using System.Threading.Tasks;

namespace Slack.Webhooks.Api
{
    public class Chat : ApiBase
    {
        public Chat(SlackConfiguration configuration) : base(configuration)
        {
        }

        public SlackResponse PostMessage(SlackMessage message)
        {
            var uri = new Uri("https://slack.com/api/chat.postMessage");
            return PostAsync<SlackResponse>(uri, message).GetAwaiter().GetResult();
        }

        public async Task<SlackResponse> PostMessageAsync(SlackMessage message)
        {
            var uri = new Uri("https://slack.com/api/chat.postMessage");
            return await PostAsync<SlackResponse>(uri, message);
        }


    }
}