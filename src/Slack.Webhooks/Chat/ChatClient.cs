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

        public DeleteResponse Delete(DeleteRequest request)
        {
            var uri = new Uri("https://slack.com/api/chat.delete");
            return PostAsync<DeleteResponse>(uri, request, configureAwait: false).Result;
        }

        public Task<DeleteResponse> DeleteAsync(DeleteRequest request)
        {
            var uri = new Uri("https://slack.com/api/chat.delete");
            return PostAsync<DeleteResponse>(uri, request);
        }

        public PermalinkResponse Permalink(PermalinkRequest request)
        {
            var uri = new Uri("https://slack.com/api/chat.getPermalink");
            return GetAsync<PermalinkResponse>(uri, request, configureAwait: false).Result;
        }

        public Task<PermalinkResponse> PermalinkAsync(PermalinkRequest request)
        {
            var uri = new Uri("https://slack.com/api/chat.getPermalink");
            return GetAsync<PermalinkResponse>(uri, request);
        }

        public PostMessageResponse PostMessage(PostMessage message)
        {
            var uri = new Uri("https://slack.com/api/chat.postMessage");
            return PostAsync<PostMessageResponse>(uri, message, configureAwait: false).Result;
        }

        public async Task<PostMessageResponse> PostMessageAsync(PostMessage message)
        {
            var uri = new Uri("https://slack.com/api/chat.postMessage");
            return await PostAsync<PostMessageResponse>(uri, message);
        }
    }
}