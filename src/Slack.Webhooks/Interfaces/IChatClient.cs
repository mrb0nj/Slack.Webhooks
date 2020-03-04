using System.Threading.Tasks;
using Slack.Webhooks.Chat;
using Slack.Webhooks.Messages;

namespace Slack.Webhooks.Interfaces
{
    public interface IChatClient
    {
        PostMessageResponse PostMessage(ChatMessage message);
        Task<PostMessageResponse> PostMessageAsync(ChatMessage message);
    }
}