using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Slack.Webhooks.Api
{
    public class ApiBase
    {
        protected readonly SlackConfiguration configuration;

        private static readonly DefaultContractResolver _resolver = new DefaultContractResolver { NamingStrategy = new SnakeCaseNamingStrategy() };
        private static readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            ContractResolver = _resolver,
            NullValueHandling = NullValueHandling.Ignore
        };

        public ApiBase(SlackConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected async Task<T> PostAsync<T>(Uri uri, object payload, bool requireAuthToken = true) where T : class
        {
            using (var request = new HttpRequestMessage(HttpMethod.Post, uri))
            {
                if (requireAuthToken)
                    request.Headers.Authorization = AuthenticationHeaderValue.Parse($"Bearer {configuration.AuthToken}");

                var json = SerializeObject(payload);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await configuration.HttpClient.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();

                return typeof(T) == typeof(string) ? (T)Convert.ChangeType(content, typeof(T)) : DeserializeObject<T>(content);
            }
        }

        /// <summary>
        /// Deserialize SlackMessage from a JSON string
        /// </summary>
        /// <param name="json">string containing serialized JSON</param>
        /// <returns>SlackMessage</returns>
        public static T DeserializeObject<T>(string json) where T : class
        {
            return JsonConvert.DeserializeObject<T>(json, _serializerSettings);
        }

        /// <summary>
        /// Serialize SlackMessage to a JSON string
        /// </summary>
        /// <param name="json">An instance of SlackMessage</param>
        /// <returns>string containing serialized JSON</returns>
        public static string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj, _serializerSettings);
        }

    }
}