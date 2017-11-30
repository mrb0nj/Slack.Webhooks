﻿using System;
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
        public void SlackClient_should_not_throw_exception_if_validateHost_is_false()
        {
            Assert.DoesNotThrow(() => new SlackClient("https://org.ryver.com/application/webhook/abcdef123456", validateHost: false));
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

        [Fact]
        public void SlackClient_should_remember_timeout()
        {
            const string webserviceurl = "https://hooks.slack.com/invalid";
            var timeoutSeconds = 2;
            var client = new SlackClient(webserviceurl, timeoutSeconds);

            Assert.Equal(timeoutSeconds * 1000, client.TimeoutMs);
        }

    }
}
