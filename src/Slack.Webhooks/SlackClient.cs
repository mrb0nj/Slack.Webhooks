using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Slack.Webhooks
{

    /// <summary>
    /// Default ISlackClient implementation
    /// </summary>
    public class SlackClient : ISlackClient
    {
        private readonly HttpClient _httpClient;
        private readonly Uri _webhookUri;
        private JsonSerializerSettings _jsonSettings;

        private const string VALID_HOST = "hooks.slack.com";
        private const string POST_SUCCESS = "ok";

        public double TimeoutMs => _httpClient.Timeout.TotalMilliseconds;

        public SlackClient(string webhookUrl, double timeoutSeconds = 100)
        {
            if (!Uri.TryCreate(webhookUrl, UriKind.Absolute, out _webhookUri))
            {
                throw new ArgumentException("Please enter a valid Slack webhook url");
            }

            if (_webhookUri.Host != VALID_HOST)
            {
                throw new ArgumentException("Please enter a valid Slack webhook url");
            }

            _httpClient = new HttpClient();
            _httpClient.BaseAddress = _webhookUri;
            _httpClient.Timeout = TimeSpan.FromSeconds(timeoutSeconds);

            _jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };
        }

        /// <summary>
        /// Post a message 
        /// </summary>
        /// <param name="message">Message to be posted</param>
        /// <returns>True if successful, false otherwise.</returns>
        public virtual async Task<bool> PostToChannelAsync(SlackMessage slackMessage)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(slackMessage, _jsonSettings), Encoding.UTF8, "application/json");
            try
            {
                var response = await _httpClient.PostAsync(_webhookUri.PathAndQuery, stringContent);
                var responseContent = await response.Content.ReadAsStringAsync();
                return response.StatusCode == HttpStatusCode.OK && responseContent == POST_SUCCESS;
            }
            catch (Exception)
            {
                return false;
            }          
        }

        /// <summary>
        /// Legacy method to maintain backward compatibility.
        /// </summary>
        [Obsolete("This method is deprecated in favour of the PostToChannelAsync one.")]
        public bool Post(SlackMessage slackMessage)
        {
            return PostToChannelAsync(slackMessage).Result;
        }

        /// <summary>
        /// Syncronous version of PostToChannelAsync
        /// </summary>
        public bool PostToChannel(SlackMessage slackMessage)
        {
            return PostToChannelAsync(slackMessage).Result;
        }

        /// <summary>
        /// Post a message to multiple channels
        /// </summary>
        /// <param name="message">Message to be posted</param>
        /// <param name="channels">Collection of channel names to post message to.</param>
        /// <returns>True if successful, false otherwise.</returns>
        public async Task<bool> PostToChannelsAsync(SlackMessage message, IEnumerable<string> channels)
        {
            var channelTasks = channels
                .Select(message.Clone)
                .Select(PostToChannelAsync);

            var results = await Task.WhenAll(channelTasks);

            //return true only if all sub-results are true
            return results.All(result => result) ? true : false;
        }

        /// <summary>
        /// Syncronous version of PostToChannelsAsync
        /// </summary>
        public bool PostToChannels(SlackMessage message, IEnumerable<string> channels)
        {
            return PostToChannelsAsync(message, channels).Result;
        }
    }
}
