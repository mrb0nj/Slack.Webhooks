using System.Collections.Generic;
using System.Threading.Tasks;

namespace Slack.Webhooks
{
    /// <summary>
    /// Describes a slack web hook client with the ability to post to channels
    /// </summary>
    public interface ISlackClient
    {
        Task<bool> PostToChannelAsync(SlackMessage slackMessage);
        Task<bool> PostToChannelsAsync(SlackMessage message, IEnumerable<string> channels);
    }
}
