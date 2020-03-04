using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Slack.Webhooks.Helpers
{
    public static class SerializationHelper
    {
        private static readonly DefaultContractResolver Resolver = new DefaultContractResolver { NamingStrategy = new SnakeCaseNamingStrategy() };
        private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = Resolver,
            NullValueHandling = NullValueHandling.Ignore
        };

        /// <summary>
        /// Deserialize SlackMessage from a JSON string
        /// </summary>
        /// <param name="json">string containing serialized JSON</param>
        /// <returns>SlackMessage</returns>
        public static T Deserialize<T>(string json) where T : class
        {
            return JsonConvert.DeserializeObject<T>(json, SerializerSettings);
        }

        /// <summary>
        /// Serialize SlackMessage to a JSON string
        /// </summary>
        /// <param name="obj">Instance of an object to serialize</param>
        /// <returns>string containing serialized JSON</returns>
        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, SerializerSettings);
        }
    }
}