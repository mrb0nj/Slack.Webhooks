using System.Threading.Tasks;
using Slack.Webhooks.Chat;
using Slack.Webhooks.Messages;

namespace Slack.Webhooks.Interfaces
{
    public interface IChatClient
    {
        DeleteResponse Delete(DeleteRequest request);
        Task<DeleteResponse> DeleteAsync(DeleteRequest request);
        PermalinkResponse GetPermalink(PermalinkRequest request);
        Task<PermalinkResponse> GetPermalinkAsync(PermalinkRequest request);
        PostEphemeralResponse PostEphemeral(PostEphemeralMessage message);
        Task<PostEphemeralResponse> PostEphemeralAsync(PostEphemeralMessage message);
        PostMessageResponse PostMessage(PostMessage message);
        Task<PostMessageResponse> PostMessageAsync(PostMessage message);
    }
}