using System;
using System.Threading.Tasks;
using Slack.Webhooks.Classes;
using Slack.Webhooks.Interfaces;

namespace Slack.Webhooks.Chat
{
    public class ChatClient : ClientBase, IChatClient
    {
        public ChatClient(ClientConfiguration configuration) : base(configuration)
        {
        }

        public PostMessageResponse PostMessage(ChatMessage message)
        {
            var uri = new Uri("https://slack.com/api/chat.postMessage");
            return PostAsync<PostMessageResponse>(uri, message).GetAwaiter().GetResult();
        }

        public async Task<PostMessageResponse> PostMessageAsync(ChatMessage message)
        {
            var uri = new Uri("https://slack.com/api/chat.postMessage");
            return await PostAsync<PostMessageResponse>(uri, message);
        }
    }
}