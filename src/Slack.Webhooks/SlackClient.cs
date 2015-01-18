using System;
using System.Net;
using RestSharp;
using ServiceStack;
using ServiceStack.Text;

namespace Slack.Webhooks
{
    public class SlackClient
    {
        private readonly RestClient restClient;

        public SlackClient(string webserviceUrl)
        {
            JsConfig.EmitLowercaseUnderscoreNames = true;
            JsConfig.IncludeNullValues = false;
            JsConfig.PropertyConvention = JsonPropertyConvention.Lenient;
           
            if (!webserviceUrl.Contains("slack.com"))
                throw new ArgumentException("Please enter a correct Slack webservice url hook");

            restClient = new RestClient(webserviceUrl);
        }

        public bool Post(SlackMessage slackMessage)
        {
            var request = new RestRequest("/", Method.POST);
            request.AddParameter("payload", slackMessage.ToJson());
            try
            {
                var response = restClient.Execute(request);
                return response.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}