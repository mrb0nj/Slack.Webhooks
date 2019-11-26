using FluentAssertions;
using Slack.Webhooks.Elements;
using Xunit;

namespace Slack.Webhooks.Tests
{
    public class OptionElementFixtures
    {
        [Fact]
        public void ShouldSerializePlaceholder()
        {
            // arrange
            var text = new TextObject();
            var option = new Option { Text = text };

            // act
            var textPayload = SlackClient.SerializeObject(text);
            var payload = SlackClient.SerializeObject(option);

            // assert
            payload.Should().Contain($"\"text\":{textPayload}");
        }

        [Fact]
        public void ShouldSerializeValue()
        {
            // arrange
            var option = new Option { Value = "Value123" };

            // act
            var payload = SlackClient.SerializeObject(option);

            // assert
            payload.Should().Contain("\"value\":\"Value123\"");
        }

        [Fact]
        public void ShouldSerializeUrl()
        {
            // arrange
            var option = new Option { Url = "http://someurl.com" };

            // act
            var payload = SlackClient.SerializeObject(option);

            // assert
            payload.Should().Contain("\"url\":\"http://someurl.com\"");
        }
    }
}