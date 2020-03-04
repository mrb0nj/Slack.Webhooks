using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Slack.Webhooks.Helpers;

namespace Slack.Webhooks.Classes
{
    public class ClientBase
    {
        protected readonly ClientConfiguration Configuration;

        protected ClientBase(ClientConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        protected async Task<T> PostAsync<T>(Uri uri, object payload, bool requireAuthToken = true) where T : class
        {
            using (var request = new HttpRequestMessage(HttpMethod.Post, uri))
            {
                if (requireAuthToken)
                    request.Headers.Authorization = AuthenticationHeaderValue.Parse($"Bearer {Configuration.AuthToken}");

                var json = SerializationHelper.Serialize(payload);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await Configuration.HttpClient.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();

                return typeof(T) == typeof(string) ? (T)Convert.ChangeType(content, typeof(T)) : SerializationHelper.Deserialize<T>(content);
            }
        }
    }
}