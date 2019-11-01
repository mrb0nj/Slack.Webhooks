using Moq;
using Moq.Protected;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Slack.Webhooks.Tests
{
    public class SlackClientTests
    {
        [Fact]
        public void SlackClient_should_throw_exception_if_slack_url_not_given()
        {
            Assert.Throws<ArgumentException>(() => new SlackClient(string.Empty));
        }

        [Fact]
        public void SlackClient_should_throw_exception_if_valid_url_not_given()
        {
            Assert.Throws<ArgumentException>(() => new SlackClient("[/]dodgy_url!@.slack.com"));
        }

        [Fact]
        public void SlackClient_returns_false_if_post_fails()
        {
            //arrange
            const string webserviceurl = "https://hooks.slack.com/invalid";
            var client = new SlackClient(webserviceurl);

            //act
            SlackMessage slackMessage = GetSlackMessage();
            var result = client.Post(slackMessage);

            //assert
            Assert.False(result);
        }

        

        [Fact]
        public void SlackClient_should_remember_timeout()
        {
            const string webserviceurl = "https://hooks.slack.com/invalid";
            var timeoutSeconds = 2;
            var client = new SlackClient(webserviceurl, timeoutSeconds);

            Assert.Equal(timeoutSeconds * 1000, client.TimeoutMs);
        }

        [Fact]
        public void SlackClient_should_reuse_httpclient()
        {
            //arrange
            const string hookUrl = "https://hooks.slack.com/invalid";
            var httpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            httpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Content = new StringContent("OK")
                })
                .Verifiable();

            var httpClient = new HttpClient(httpMessageHandler.Object, false);
            var client = new SlackClient(hookUrl, httpClient: httpClient);
            var slackMessage = GetSlackMessage();

            //act

            client.Post(slackMessage);
            client.Post(slackMessage);

            //assert
            httpMessageHandler.Protected().Verify(
               "SendAsync",
               Times.Exactly(2),
               ItExpr.Is<HttpRequestMessage>(req =>
                  req.Method == HttpMethod.Post
                  && req.RequestUri == new Uri(hookUrl)
               ),
               ItExpr.IsAny<CancellationToken>()
            );
        }

        private static SlackMessage GetSlackMessage()
        {
            return new SlackMessage
            {
                Text = "Test Message",
                Channel = "#test",
                Username = "testbot",
                IconEmoji = Emoji.Ghost
            };
        }

    }
}
