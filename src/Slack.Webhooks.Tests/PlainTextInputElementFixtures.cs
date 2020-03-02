using FluentAssertions;
using Slack.Webhooks.Api;
using Slack.Webhooks.Elements;
using Xunit;

namespace Slack.Webhooks.Tests
{
    public class PlainTextInputElementFixtures
    {
        [Fact]
        public void ShouldSerializeType()
        {
            // arrange
            var input = new PlainTextInput();

            // act
            var payload = ApiBase.SerializeObject(input);

            // assert
            payload.Should().Contain("\"type\":\"plain_text_input\"");
        }

        [Fact]
        public void ShouldSerializeActionId()
        {
            // arrange
            var input = new PlainTextInput { ActionId = "Action123" };

            // act
            var payload = ApiBase.SerializeObject(input);

            // assert
            payload.Should().Contain("\"action_id\":\"Action123\"");
        }

        [Fact]
        public void ShouldSerializePlaceholder()
        {
            // arrange
            var text = new TextObject();
            var input = new PlainTextInput { Placeholder = text };

            // act
            var textPayload = ApiBase.SerializeObject(text);
            var payload = ApiBase.SerializeObject(input);

            // assert
            payload.Should().Contain($"\"placeholder\":{textPayload}");
        }

        [Fact]
        public void ShouldSerializeInitialValue()
        {
            // arrange
            var input = new PlainTextInput { InitialValue = "Value123" };

            // act
            var payload = ApiBase.SerializeObject(input);

            // assert
            payload.Should().Contain("\"initial_value\":\"Value123\"");
        }

        [Fact]
        public void ShouldSerializeMultiLine()
        {
            // arrange
            var input = new PlainTextInput { MultiLine = true };

            // act
            var payload = ApiBase.SerializeObject(input);

            // assert
            payload.Should().Contain("\"multi_line\":true");
        }

        [Fact]
        public void ShouldSerializeMinLength()
        {
            // arrange
            var input = new PlainTextInput { MinLength = 10 };

            // act
            var payload = ApiBase.SerializeObject(input);

            // assert
            payload.Should().Contain("\"min_length\":10");
        }

        [Fact]
        public void ShouldSerializeMaxLength()
        {
            // arrange
            var input = new PlainTextInput { MaxLength = 10 };

            // act
            var payload = ApiBase.SerializeObject(input);

            // assert
            payload.Should().Contain("\"max_length\":10");
        }
    }
}