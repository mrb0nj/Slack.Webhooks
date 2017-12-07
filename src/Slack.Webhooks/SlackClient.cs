using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Threading.Tasks;

namespace Slack.Webhooks
{
    public class SlackClient : ISlackClient
    {
        private readonly Uri _webhookUri;
        private const string POST_SUCCESS = "ok";
        private int _timeout = 100;

        /// <summary>
        /// Returns the current Timeout value.
        /// </summary>
        internal int TimeoutMs { get { return _timeout * 1000; } }

        public SlackClient(string webhookUrl, int timeout = 100)
        {
            if (!Uri.TryCreate(webhookUrl, UriKind.Absolute, out _webhookUri))
                throw new ArgumentException("Please enter a valid webhook url");
            _timeout = timeout;
        }
        
        public virtual bool Post(SlackMessage slackMessage)
        {
            var result = PostAsync(slackMessage);
            return result.Result;
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
                                .Select(PostAsync);
        }

        public async Task<bool> PostAsync(SlackMessage slackMessage)
        {
            var payload = SerializePayload(slackMessage);
            using (var httpClient = new HttpClient { Timeout = new TimeSpan(0, 0, _timeout) })
            using (var response = await httpClient.PostAsync(_webhookUri.OriginalString, new StringContent(payload)).ConfigureAwait(false))
            {
                var content = await response.Content.ReadAsStringAsync();
                return content.Equals(POST_SUCCESS, StringComparison.OrdinalIgnoreCase);
            }
        }
        
        private static string SerializePayload(SlackMessage slackMessage)
        {
            var resolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };

            return JsonConvert.SerializeObject(slackMessage, new JsonSerializerSettings
            {
                ContractResolver = resolver,
                NullValueHandling = NullValueHandling.Ignore
            });
        }
    }
}
