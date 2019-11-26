using System.Collections.Generic;
using FluentAssertions;
using Slack.Webhooks.Elements;
using Xunit;

namespace Slack.Webhooks.Tests
{
    public class MultiSelectUsersElementFixtures
    {
        [Fact]
        public void ShouldSerializeInitialUsers()
        {
            // arrange
            var options = new List<string> { "User123", "User321" };
            var select = new MultiSelectUsers { InitialUsers = options };

            // act
            var optionsPayload = SlackClient.SerializeObject(options);
            var payload = SlackClient.SerializeObject(select);

            // assert
            payload.Should().Contain($"\"initial_users\":{optionsPayload}");
        }
    }

    public class MultiSelectConversationsElementFixtures
    {
        [Fact]
        public void ShouldSerializeInitialConversations()
        {
            // arrange
            var options = new List<string> { "Convo123", "Convo321" };
            var select = new MultiSelectConversations { InitialConversations = options };

            // act
            var optionsPayload = SlackClient.SerializeObject(options);
            var payload = SlackClient.SerializeObject(select);

            // assert
            payload.Should().Contain($"\"initial_conversations\":{optionsPayload}");
        }
    }

    public class MultiSelectChannelsElementFixtures
    {
        [Fact]
        public void ShouldSerializeInitialChannels()
        {
            // arrange
            var options = new List<string> { "Convo123", "Convo321" };
            var select = new MultiSelectChannels { InitialChannels = options };

            // act
            var optionsPayload = SlackClient.SerializeObject(options);
            var payload = SlackClient.SerializeObject(select);

            // assert
            payload.Should().Contain($"\"initial_channels\":{optionsPayload}");
        }
    }
    
}