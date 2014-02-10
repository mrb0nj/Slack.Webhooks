using System;
using System.Net;
using RestSharp;
using ServiceStack;
using ServiceStack.Text;

namespace Slack.Webhooks
{
    public class SlackClient
    {
        private const string Resource = "/services/hooks/incoming-webhook";
        public string TeamName { get; set; }
        public string Token { get; set; }

        public RestClient RestClient { get; set; }

        public SlackClient(string teamName, string token, RestClient restClient = null)
        {
            JsConfig.EmitLowercaseUnderscoreNames = true;
            JsConfig.IncludeNullValues = false;
            JsConfig.PropertyConvention = PropertyConvention.Lenient;

            TeamName = teamName;
            Token = token;
            RestClient = restClient ?? new RestClient(string.Format("https://{0}.slack.com", teamName));
        }

        public bool Post(SlackMessage slackMessage)
        {
            var request = new RestRequest(Resource, Method.POST);
            request.AddParameter("payload", slackMessage.ToJson());
            request.AddParameter("token", Token, ParameterType.QueryString);
            try
            {
                var response = RestClient.Execute(request);
                return response.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}