using System.Threading.Tasks;
using Slack.Webhooks.Chat;
using Slack.Webhooks.Messages;

namespace Slack.Webhooks.Interfaces
{
    public interface IChatClient
    {
        DeleteResponse Delete(DeleteRequest request);
        Task<DeleteResponse> DeleteAsync(DeleteRequest request);
        
        
        PostMessageResponse PostMessage(ChatMessage message);
        Task<PostMessageResponse> PostMessageAsync(ChatMessage message);
    }
}