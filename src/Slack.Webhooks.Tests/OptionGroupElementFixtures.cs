using System.Collections.Generic;
using FluentAssertions;
using Slack.Webhooks.Elements;
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
            var textPayload = SlackClient.SerializeObject(text);
            var payload = SlackClient.SerializeObject(option);

            // assert
            payload.Should().Contain($"\"label\":{textPayload}");
        }

        [Fact]
        public void ShouldSerializeOptions()
        {
            // arrange
            var options = new List<Option> { new Option { Value = "test" }};
            var group = new OptionGroup { Options = options };

            // act
            var optionsPayload = SlackClient.SerializeObject(options);
            var payload = SlackClient.SerializeObject(group);

            // assert
            payload.Should().Contain($"\"options\":{optionsPayload}");
        }
    }
}