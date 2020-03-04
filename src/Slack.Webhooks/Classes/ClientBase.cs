using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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

        protected async Task<T> PostAsync<T>(Uri uri, object payload, bool requireAuthToken = true, bool configureAwait = true) where T : class
        {
            using (var request = new HttpRequestMessage(HttpMethod.Post, uri))
            {
                if (requireAuthToken)
                    request.Headers.Authorization = AuthenticationHeaderValue.Parse($"Bearer {Configuration.AuthToken}");

                var json = SerializationHelper.Serialize(payload);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await Configuration.HttpClient.SendAsync(request).ConfigureAwait(configureAwait);
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(configureAwait);

                return typeof(T) == typeof(string) ? (T)Convert.ChangeType(content, typeof(T)) : SerializationHelper.Deserialize<T>(content);
            }
        }

        protected async Task<T> GetAsync<T>(Uri uri, object payload, bool configureAwait = true) where T : class
        {
            var builder = new UriBuilder(uri) {Query = await GetQueryStringAsync(uri, payload)};
            using (var request = new HttpRequestMessage(HttpMethod.Get, builder.Uri))
            {
                var response = await Configuration.HttpClient.SendAsync(request).ConfigureAwait(configureAwait);
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(configureAwait);

                return typeof(T) == typeof(string) ? (T)Convert.ChangeType(content, typeof(T)) : SerializationHelper.Deserialize<T>(content);
            }
        }

        private async Task<string> GetQueryStringAsync(Uri uri, object payload)
        {
            var dictionary = SerializationHelper.ToDictionary(payload);
            dictionary.Add("token", Configuration.AuthToken);
            
            var existingQuery = HttpUtility.ParseQueryString(uri.Query);
            foreach (string key in existingQuery) dictionary.Add(key, existingQuery[key]);
            
            return await new FormUrlEncodedContent(dictionary).ReadAsStringAsync();
        }
    }
}