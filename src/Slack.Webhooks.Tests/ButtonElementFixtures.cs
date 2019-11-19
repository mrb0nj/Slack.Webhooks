using FluentAssertions;
using Slack.Webhooks.Elements;
using Xunit;

namespace Slack.Webhooks.Tests
{
    public class ButtonElementFixtures
    {
        [Fact]
        public void ShouldSerializeType()
        {
            // arrange
            var button = new Button();

            // act
            var payload = SlackClient.SerializeObject(button);

            // assert
            payload.Should().Contain("\"type\":\"button\"");
        }

        [Fact]
        public void ShouldSerializeText()
        {
            // arrange
            var button = new Button { Text = new TextObject { Text = "Test Text" }};

            // act
            var payload = SlackClient.SerializeObject(button);

            // assert
            payload.Should().Contain("\"text\":{\"type\":\"plain_text\"");
        }

        [Fact]
        public void ShouldSerializeActionId()
        {
            // arrange
            var button = new Button { ActionId = "Action123" };

            // act
            var payload = SlackClient.SerializeObject(button);

            // assert
            payload.Should().Contain("\"action_id\":\"Action123\"");
        }

        [Fact]
        public void ShouldSerializeUrl()
        {
            // arrange
            var button = new Button { Url = "http://someurl.com" };

            // act
            var payload = SlackClient.SerializeObject(button);

            // assert
            payload.Should().Contain("\"url\":\"http://someurl.com\"");
        }

        [Fact]
        public void ShouldSerializeValue()
        {
            // arrange
            var button = new Button { Value = "Value123" };

            // act
            var payload = SlackClient.SerializeObject(button);

            // assert
            payload.Should().Contain("\"value\":\"Value123\"");
        }

        [Fact]
        public void ShouldSerializeStyle()
        {
            // arrange
            var button = new Button { Style = "Style123" };

            // act
            var payload = SlackClient.SerializeObject(button);

            // assert
            payload.Should().Contain("\"style\":\"Style123\"");
        }

        [Fact]
        public void ShouldSerializeConfirm()
        {
            // arrange
            var confirm = new Confirmation();
            var button = new Button { Confirm = confirm };

            // act
            var confirmPayload = SlackClient.SerializeObject(confirm);
            var payload = SlackClient.SerializeObject(button);

            // assert
            payload.Should().Contain($"\"confirm\":{confirmPayload}");
        }
    }
}