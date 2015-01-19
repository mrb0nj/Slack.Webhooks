using System;
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
        public void SlackClient_should_throw_exception_if_hostname_is_invalid()
        {
            Assert.Throws<ArgumentException>(() => new SlackClient("https://google.com"));
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

    }
}
