using System;
using System.Net;
using FakeItEasy;
using RestSharp;
using Xunit;

namespace Slack.Webhooks.Tests
{
    public class SlackClientTests
    {
        [Fact]
        public void Client_created_with_team_and_slack_token()
        {
            //arrange
            const string token = "A_TOKEN";
            const string teamName = "test_team";

            //arrange
            var client = new SlackClient(teamName, token);

            //assert
            Assert.Equal(teamName, client.TeamName);
            Assert.Equal(token, client.Token);
        }

        [Fact]
        public void Client_can_post_message()
        {
            //arrange
            const string token = "A_TOKEN";
            const string teamName = "my_team";
            var restClient = A.Fake<RestClient>();
            var client = new SlackClient(teamName, token, restClient);
            A.CallTo(() => restClient.Execute(A<IRestRequest>.Ignored))
                .Returns(new RestResponse {StatusCode = HttpStatusCode.OK});

            //act
            var slackMessage = new SlackMessage
            {
                Text = "Test Message",
                Channel = "#test",
                Username = "testbot",
                IconEmoji = Emoji.Ghost
            };
            var result = client.Post(slackMessage);

            //assert
            Assert.True(result);
        }

        [Fact]
        public void Client_returns_false_if_post_failed()
        {
            //arrange
            const string token = "A_TOKEN";
            const string teamName = "my_team";
            var restClient = A.Fake<RestClient>();
            var client = new SlackClient(teamName, token, restClient);
            A.CallTo(() => restClient.Execute(A<IRestRequest>.Ignored))
                .Returns(new RestResponse { StatusCode = HttpStatusCode.BadRequest });

            //act
            var slackMessage = new SlackMessage
            {
                Text = "Test Message",
                Channel = "#test",
                Username = "testbot",
                IconEmoji = Emoji.Ghost
            };
            var result = client.Post(slackMessage);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void Client_returns_false_if_post_throws_exception()
        {
            //arrange
            const string token = "A_TOKEN";
            const string teamName = "my_team";
            var restClient = A.Fake<RestClient>();
            var client = new SlackClient(teamName, token, restClient);
            A.CallTo(() => restClient.Execute(A<IRestRequest>.Ignored))
                .Throws(new Exception());

            //act
            var slackMessage = new SlackMessage
            {
                Text = "Test Message",
                Channel = "#test",
                Username = "testbot",
                IconEmoji = Emoji.Ghost
            };
            var result = client.Post(slackMessage);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void Client_posts_payload_to_slack()
        {
            //arrange
            const string token = "A_TOKEN";
            const string teamName = "my_team";
            var restClient = A.Fake<RestClient>();
            var client = new SlackClient(teamName, token, restClient);

            //act
            var slackMessage = new SlackMessage
            {
                Text = "Test Message",
                Channel = "#test",
                Username = "testbot",
                IconEmoji = Emoji.Ghost
            };
            client.Post(slackMessage);

            //assert
            A.CallTo(
                () =>
                    restClient.Execute(
                        A<IRestRequest>.That.Matches(req => req.Parameters.Exists(p => p.Name == "payload")))).MustHaveHappened();
        }

        [Fact]
        public void Client_creates_a_rest_client_if_one_is_not_injected()
        {
            //arrange/act
            var client = new SlackClient("my_team", "A_TOKEN");

            //assert
            Assert.NotNull(client.RestClient);
            Assert.Equal("https://my_team.slack.com", client.RestClient.BaseUrl);
        }
    }
}
