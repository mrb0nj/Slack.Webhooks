using System;
using System.Collections.Generic;

#if NET40
using System.Threading.Tasks;
using RestSharp;
#endif

namespace Slack.Webhooks
{
	public interface ISlackClient
	{
		bool Post(SlackMessage slackMessage);
		bool PostToChannels(SlackMessage message, IEnumerable<string> channels);
#if NET40
		Task<IRestResponse> PostAsync(SlackMessage slackMessage);
		IEnumerable<Task<IRestResponse>> PostToChannelsAsync(SlackMessage message, IEnumerable<string> channels);
#endif
	}
}
