using FluentAssertions;
using Slack.Webhooks.Elements;
using Xunit;

namespace Slack.Webhooks.Tests
{
    public class ConfirmationElementFixtures
    {
        [Fact]
        public void ShouldSerializeTitle()
        {
            // arrange
            var confirm = new Confirmation { Title = new TextObject { Text = "Title Test"} };

            // act
            var payload = SlackClient.SerializeObject(confirm);

            // assert
            payload.Should().Contain("\"title\":{");
            payload.Should().Contain("\"text\":\"Title Test\"");
        }

        [Fact]
        public void ShouldSerializeText()
        {
            // arrange
            var confirm = new Confirmation { Text = new TextObject { Text = "Title Test"} };

            // act
            var payload = SlackClient.SerializeObject(confirm);

            // assert
            payload.Should().Contain("\"text\":{");
            payload.Should().Contain("\"text\":\"Title Test\"");
        }

        [Fact]
        public void ShouldSerializeConfirm()
        {
            // arrange
            var confirm = new Confirmation { Confirm = new TextObject { Text = "Title Test"} };

            // act
            var payload = SlackClient.SerializeObject(confirm);

            // assert
            payload.Should().Contain("\"confirm\":{");
            payload.Should().Contain("\"text\":\"Title Test\"");
        }

        [Fact]
        public void ShouldSerializeDeny()
        {
            // arrange
            var confirm = new Confirmation { Deny = new TextObject { Text = "Title Test"} };

            // act
            var payload = SlackClient.SerializeObject(confirm);

            // assert
            payload.Should().Contain("\"deny\":{");
            payload.Should().Contain("\"text\":\"Title Test\"");
        }
    }
}