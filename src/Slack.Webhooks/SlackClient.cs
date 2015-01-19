using System;
using System.Net;
using RestSharp;
using ServiceStack.Text;

namespace Slack.Webhooks
{
    public class SlackClient
    {
        private readonly RestClient _restClient;
        private readonly Uri _webhookUri;

        private const string VALID_HOST = "hooks.slack.com";
        private const string POST_SUCCESS = "ok";

        public SlackClient(string webhookUrl)
        {
            JsConfig.EmitLowercaseUnderscoreNames = true;
            JsConfig.IncludeNullValues = false;
            JsConfig.PropertyConvention = JsonPropertyConvention.Lenient;

            if (!Uri.TryCreate(webhookUrl, UriKind.Absolute, out _webhookUri))
                throw new ArgumentException("Please enter a valid Slack webhook url");
           
            if (_webhookUri.Host != VALID_HOST)
                throw new ArgumentException("Please enter a valid Slack webhook url");

            var baseUrl = _webhookUri.GetLeftPart(UriPartial.Authority);
            _restClient = new RestClient(baseUrl);
        }

        public bool Post(SlackMessage slackMessage)
        {
            var request = new RestRequest(_webhookUri.PathAndQuery, Method.POST);
            request.AddParameter("payload", slackMessage.ToJson());
            try
            {
                var response = _restClient.Execute(request);
                return response.StatusCode == HttpStatusCode.OK && response.Content == POST_SUCCESS;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}