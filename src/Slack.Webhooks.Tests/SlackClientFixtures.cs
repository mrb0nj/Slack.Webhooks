using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Slack.Webhooks.Tests
{
    public class SlackClientFixtures
    {
        [Fact]
        public void ShouldThrowExceptionWhenUrlIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new SlackClient(string.Empty));
        }

        [Fact]
        public void ShouldThrowExceptionIfUrlIsMalformed()
        {
            Assert.Throws<ArgumentException>(() => new SlackClient("[/]dodgy_url!@.slack.com"));
        }

        [Fact]
        public void ShouldReturnTrueIfPostSucceeds()
        {
            //arrange
            const string hookUrl = "https://hooks.slack.com/mygreathook";
            var httpMessageHandler = GetMockHttpMessageHandler("OK");
            var client = new SlackClient(hookUrl, httpClient: new HttpClient(httpMessageHandler.Object, false));
            var slackMessage = GetSlackMessage();

            //act
            var result = client.Post(slackMessage);

            //assert
            Assert.True(result);
        }

        [Fact]
        public void ShouldReturnFalseIfPostFails()
        {
            //arrange
            const string hookUrl = "https://hooks.slack.com/invalidhook";
            var httpMessageHandler = GetMockHttpMessageHandler("NOK");
            var client = new SlackClient(hookUrl, httpClient: new HttpClient(httpMessageHandler.Object, false));
            var slackMessage = GetSlackMessage();

            //act
            var result = client.Post(slackMessage);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void ShouldRememberTimeout()
        {
            const string hookUrl = "https://hooks.slack.com/invalid";
            var timeoutSeconds = 2;
            var client = new SlackClient(hookUrl, timeoutSeconds);

            Assert.Equal(timeoutSeconds * 1000, client.TimeoutMs);
        }

        [Fact]
        public void ShouldReuseHttpClient()
        {
            //arrange
            const string hookUrl = "https://hooks.slack.com/invalid";
            var httpMessageHandler = GetMockHttpMessageHandler("OK");
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


        [Fact]
        public void ShouldContainSerializedMessage()
        {
            //arrange
            const string hookUrl = "https://hooks.slack.com/invalid";
            SlackMessage postedMessage = null;
            var httpMessageHandler = GetMockHttpMessageHandler(callback: (req, token) =>
            {
                var json = req.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Console.WriteLine(json);
                postedMessage = SlackClient.DeserializeObject(json);
            });

            var httpClient = new HttpClient(httpMessageHandler.Object, false);
            var client = new SlackClient(hookUrl, httpClient: httpClient);
            var slackMessage = GetSlackMessage();

            //act
            client.Post(slackMessage);

            //assert
            Assert.NotNull(postedMessage);
            Assert.Equal(slackMessage.Text, postedMessage.Text);
            Assert.Equal(slackMessage.Channel, postedMessage.Channel);
            Assert.Equal(slackMessage.Username, postedMessage.Username);
            Assert.Equal(slackMessage.IconEmoji, postedMessage.IconEmoji);
        }

        [Fact]
        public void ShouldPostToMultipleChannels()
        {
            //arrange
            const string hookUrl = "https://hooks.slack.com/invalid";
            var channelsPostedTo = new List<string>();
            var httpMessageHandler = GetMockHttpMessageHandler(callback: (req, token) =>
            {
                var json = req.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var postedMessage = SlackClient.DeserializeObject(json);
                channelsPostedTo.Add(postedMessage.Channel);
            });

            var httpClient = new HttpClient(httpMessageHandler.Object, false);
            var client = new SlackClient(hookUrl, httpClient: httpClient);
            var slackMessage = GetSlackMessage();
            var channelsToPostTo = new List<string> { "#test1", "#test2", "test3" };

            //act
            client.PostToChannels(slackMessage, channelsToPostTo);

            //assert
            Assert.Equal(channelsToPostTo.Count, channelsPostedTo.Count);
            foreach (var c in channelsToPostTo)
            {
                Assert.Contains(c, channelsPostedTo);
            }
        }

        private static Mock<HttpMessageHandler> GetMockHttpMessageHandler(string response = "OK", Action<HttpRequestMessage, CancellationToken> callback = null)
        {
            callback = callback ?? new Action<HttpRequestMessage, CancellationToken>(delegate (HttpRequestMessage m, CancellationToken t) { });

            var httpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            httpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Content = new StringContent(response)
                })
                .Callback<HttpRequestMessage, CancellationToken>(callback)
                .Verifiable();
            return httpMessageHandler;
        }

        private static SlackMessage GetSlackMessage(
            string text = "Test Message",
            string channel = "#test",
            string username = "testbot",
            string iconEmoji = Emoji.Ghost)
        {
            return new SlackMessage
            {
                Text = text,
                Channel = channel,
                Username = username,
                IconEmoji = iconEmoji
            };
        }

    }
}
