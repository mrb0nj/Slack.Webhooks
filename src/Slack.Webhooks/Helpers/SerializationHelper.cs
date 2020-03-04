using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        
        public static IDictionary<string, string> ToDictionary(object obj)
        {
            if (obj == null)
            {
                return null;
            }

            var token = obj as JToken;
            if (token == null)
            {
                return ToDictionary(JObject.FromObject(obj, JsonSerializer.Create(SerializerSettings)));
            }

            if (token.HasValues)
            {
                var contentData = new Dictionary<string, string>();
                foreach (var child in token.Children().ToList())
                {
                    var childContent = ToDictionary(child);
                    if (childContent != null)
                    {
                        contentData = contentData.Concat(childContent)
                            .ToDictionary(k => k.Key, v => v.Value);
                    }
                }

                return contentData;
            }

            var jValue = token as JValue;
            if (jValue?.Value == null)
            {
                return null;
            }

            var value = jValue?.Type == JTokenType.Date ?
                jValue?.ToString("o", CultureInfo.InvariantCulture) :
                jValue?.ToString(CultureInfo.InvariantCulture);

            return new Dictionary<string, string> { { token.Path, value } };
        }
    }
}