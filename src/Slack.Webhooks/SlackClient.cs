﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Extensions;
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
            if (!Uri.TryCreate(webhookUrl, UriKind.Absolute, out _webhookUri))
                throw new ArgumentException("Please enter a valid Slack webhook url");
           
            if (_webhookUri.Host != VALID_HOST)
                throw new ArgumentException("Please enter a valid Slack webhook url");

            var baseUrl = _webhookUri.GetLeftPart(UriPartial.Authority);
            _restClient = new RestClient(baseUrl);
        }

        private void SetPropertyConvention(JsConfigScope scope)
        {
            var assembly = Assembly.GetAssembly(typeof(JsConfig));
            var jsConfig = assembly.GetType("ServiceStack.Text.JsConfig");
            var conventionEnum = assembly.GetType("ServiceStack.Text.JsonPropertyConvention") ??
                           assembly.GetType("ServiceStack.Text.PropertyConvention");
            var propertyConvention = jsConfig.GetProperty("PropertyConvention");
            
            var lenient = conventionEnum.GetField("Lenient");

            var enumValue = Enum.ToObject(conventionEnum, (int) lenient.GetValue(conventionEnum));
            propertyConvention.SetValue(scope, enumValue, null);
        }

        public virtual bool Post(SlackMessage slackMessage)
        {
            var request = new RestRequest(_webhookUri.PathAndQuery, Method.POST);
            using (var scope = JsConfig.BeginScope())
            {
                scope.EmitLowercaseUnderscoreNames = true;
                scope.IncludeNullValues = false;
                SetPropertyConvention(scope);
                
                request.AddParameter("payload", JsonSerializer.SerializeToString(slackMessage));

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

	    public Task<IRestResponse> PostAsync(SlackMessage slackMessage)
	    {
		    var request = new RestRequest(_webhookUri.PathAndQuery, Method.POST);

		    request.AddParameter("payload", JsonSerializer.SerializeToString(slackMessage));

		    return ExecuteTaskAsync(request);
	    }

	    public void PostToChannels(SlackMessage message, IEnumerable<string> channels)
		{
			var tasks = channels.DefaultIfEmpty(message.Channel)
				.Select(message.Clone)
				.Select(PostAsync).ToArray();

			Task.WaitAll(tasks);
		}

	    private Task<IRestResponse> ExecuteTaskAsync(IRestRequest request)
		{
			var taskCompletionSource = new TaskCompletionSource<IRestResponse>();
			try
			{
				_restClient.ExecuteAsync(request, (response, _) =>
				{
					if (response.ErrorException != null)
						taskCompletionSource.TrySetException(response.ErrorException);
					else if (response.ResponseStatus != ResponseStatus.Completed)
						taskCompletionSource.TrySetException(response.ResponseStatus.ToWebException());
					else
						taskCompletionSource.TrySetResult(response);
				});
			}
			catch (Exception ex)
			{
				taskCompletionSource.TrySetException(ex);
			}
			return taskCompletionSource.Task;
		}
    }
}
