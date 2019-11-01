using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Slack.Webhooks
{
    public class SlackClient : ISlackClient, IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly Uri _webhookUri;
        private const string POST_SUCCESS = "ok";
        private int _timeout = 100;

        /// <summary>
        /// Returns the current Timeout value.
        /// </summary>
        internal int TimeoutMs { get { return _timeout * 1000; } }

        public SlackClient(string webhookUrl, int timeout = 100, HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient();
            if (!Uri.TryCreate(webhookUrl, UriKind.Absolute, out _webhookUri))
                throw new ArgumentException("Please enter a valid webhook url");
            _timeout = timeout;
        }
        
        public virtual bool Post(SlackMessage slackMessage)
        {
            var result = PostAsync(slackMessage).GetAwaiter().GetResult();
            return result;
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
            using (var request = new HttpRequestMessage(HttpMethod.Post, _webhookUri))
            {
                request.Content = new StringContent(slackMessage.AsJson(), System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();
                return content.Equals(POST_SUCCESS, StringComparison.OrdinalIgnoreCase);
            }
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
