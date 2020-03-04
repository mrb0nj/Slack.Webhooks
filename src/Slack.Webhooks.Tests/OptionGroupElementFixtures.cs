using System.Collections.Generic;
using FluentAssertions;
using Slack.Webhooks.Classes;
using Slack.Webhooks.Elements;
using Slack.Webhooks.Helpers;
using Xunit;

namespace Slack.Webhooks.Tests
{
    public class OptionGroupElementFixtures
    {
        [Fact]
        public void ShouldSerializeLabel()
        {
            // arrange
            var text = new TextObject();
            var option = new OptionGroup { Label = text };

            // act
            var textPayload = SerializationHelper.Serialize(text);
            var payload = SerializationHelper.Serialize(option);

            // assert
            payload.Should().Contain($"\"label\":{textPayload}");
        }

        [Fact]
        public void ShouldSerializeOptions()
        {
            // arrange
            var options = new List<Option> { new Option { Value = "test" } };
            var group = new OptionGroup { Options = options };

            // act
            var optionsPayload = SerializationHelper.Serialize(options);
            var payload = SerializationHelper.Serialize(group);

            // assert
            payload.Should().Contain($"\"options\":{optionsPayload}");
        }
    }
}