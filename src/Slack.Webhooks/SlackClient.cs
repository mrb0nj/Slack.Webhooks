using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Slack.Webhooks.Api;

namespace Slack.Webhooks
{
    public class SlackClient : ISlackClient, IDisposable
    {
        private readonly SlackConfiguration _configuration;
        public int TimeoutMs { get { return (int)_configuration.HttpClient.Timeout.TotalMilliseconds; } }

        #region Api
        public Webhook Webhook { get; private set; }
        public Chat Chat { get; private set; }
        #endregion

        public SlackClient(string webhookUrl = null, int timeout = 100, HttpClient httpClient = null)
        {
            Uri webhookUri;
            if (!Uri.TryCreate(webhookUrl, UriKind.Absolute, out webhookUri))
                throw new ArgumentException("Please enter a valid webhook url");

            _configuration = new SlackConfiguration
            {
                HttpClient = httpClient ?? new HttpClient { Timeout = TimeSpan.FromSeconds(timeout) },
                WebhookUri = webhookUri
            };

            Configure();
        }

        public SlackClient(SlackConfiguration configuration)
        {
            _configuration = configuration;

            Configure();
        }

        private void Configure()
        {
            Webhook = new Webhook(_configuration);
            Chat = new Chat(_configuration);
        }

        [Obsolete("Please use SlackClient.Webhook.Post(SlackMessage) instead.")]
        public virtual bool Post(SlackMessage slackMessage)
        {
            return Webhook.Post(slackMessage);
        }

        [Obsolete("Please use SlackClient.Webhook.PostToChannels(SlackMessage, IEnumerable<string>) instead.")]
        public bool PostToChannels(SlackMessage message, IEnumerable<string> channels)
        {
            return Webhook.PostToChannels(message, channels);
        }

        [Obsolete("Please use SlackClient.Webhook.PostToChannelsAsync(SlackMessage, IEnumerable<string>) instead.")]
        public IEnumerable<Task<bool>> PostToChannelsAsync(SlackMessage message, IEnumerable<string> channels)
        {
            return Webhook.PostToChannelsAsync(message, channels);
        }

        /// <summary>
        /// Deserialize SlackMessage from a JSON string
        /// </summary>
        /// <param name="json">string containing serialized JSON</param>
        /// <returns>SlackMessage</returns>
        [Obsolete("Please use ApiBase.DeserializeObject instead.")]
        public static SlackMessage DeserializeObject(string json)
        {
            return ApiBase.DeserializeObject<SlackMessage>(json);
        }

        /// <summary>
        /// Serialize SlackMessage to a JSON string
        /// </summary>
        /// <param name="json">An instance of SlackMessage</param>
        /// <returns>string containing serialized JSON</returns>
        [Obsolete("Please use ApiBase.SerializeObject instead.")]
        public static string SerializeObject(object obj)
        {
            return ApiBase.SerializeObject(obj);
        }

        public void Dispose()
        {
            _configuration.HttpClient.Dispose();
        }
    }
}
