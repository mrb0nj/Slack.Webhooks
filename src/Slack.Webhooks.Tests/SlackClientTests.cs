using System;
using Xunit;

namespace Slack.Webhooks.Tests
{
    public class SlackClientTests
    {
        [Fact]
        public void FactMethodName()
        {
            Assert.Throws<ArgumentException>(() => new SlackClient("no slack url passed in"));
        }

        [Fact]
        public void Client_returns_false_if_post_fails()
        {
            //arrange
            const string webserviceurl = "[/]dodgy_url!@.slack.com";
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
