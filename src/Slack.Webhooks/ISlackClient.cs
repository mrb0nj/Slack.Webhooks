using System.Collections.Generic;
using System.Threading.Tasks;

namespace Slack.Webhooks
{
    public interface ISlackClient
    {
        bool Post(SlackMessage slackMessage);
        bool PostToChannels(SlackMessage message, IEnumerable<string> channels);
        IEnumerable<Task<bool>> PostToChannelsAsync(SlackMessage message, IEnumerable<string> channels);
    }
}
