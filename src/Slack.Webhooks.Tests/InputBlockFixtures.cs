using System.Collections.Generic;
using FluentAssertions;
using Slack.Webhooks.Api;
using Slack.Webhooks.Blocks;
using Slack.Webhooks.Elements;
using Slack.Webhooks.Interfaces;
using Xunit;

namespace Slack.Webhooks.Tests
{
    public class InputBlockFixtures
    {
        [Fact]
        public void ShouldSerializeLabel()
        {
            // arrange
            var textObject = new TextObject { Text = "Test label" };
            var input = new Input { Label = textObject };

            // act
            var textPayload = ApiBase.SerializeObject(textObject);
            var payload = ApiBase.SerializeObject(input);

            // assert
            payload.Should().Contain($"\"label\":{textPayload}");
        }

        [Fact]
        public void ShouldSerializeHint()
        {
            // arrange
            var textObject = new TextObject { Text = "Test hint" };
            var input = new Input { Hint = textObject };

            // act
            var textPayload = ApiBase.SerializeObject(textObject);
            var payload = ApiBase.SerializeObject(input);

            // assert
            payload.Should().Contain($"\"hint\":{textPayload}");
        }

        [Fact]
        public void ShouldSerializeOptional()
        {
            // arrange
            var input = new Input { Optional = true };

            // act
            var payload = ApiBase.SerializeObject(input);

            // assert
            payload.Should().Contain("\"optional\":true");
        }

        [Theory]
        [MemberData(nameof(GetInputElementData))]
        public void ShouldSerializeInputElementTypes(object element)
        {
            // arrange
            var input = new Input { Element = (IInputElement)element };

            // act
            var elementPayload = ApiBase.SerializeObject(element);
            var payload = ApiBase.SerializeObject(input);

            // arrange
            payload.Should().Contain($"\"element\":{elementPayload}");
        }

        public static IEnumerable<object[]> GetInputElementData()
        {
            return new List<object[]>
            {
                new object[] { new PlainTextInput() },
                new object[] { new SelectChannels() },
                new object[] { new SelectUsers() },
                new object[] { new SelectConversations() },
                new object[] { new SelectStatic() },
                new object[] { new SelectExternal() },
                new object[] { new MultiSelectChannels() },
                new object[] { new MultiSelectUsers() },
                new object[] { new MultiSelectConversations() },
                new object[] { new MultiSelectStatic() },
                new object[] { new MultiSelectExternal() },
                new object[] { new DatePicker() }
            };
        }
    }
}