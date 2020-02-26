using System.Collections.Generic;
using FluentAssertions;
using Slack.Webhooks.Api;
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
            var textPayload = ApiBase.SerializeObject(text);
            var payload = ApiBase.SerializeObject(option);

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
            var optionsPayload = ApiBase.SerializeObject(options);
            var payload = ApiBase.SerializeObject(group);

            // assert
            payload.Should().Contain($"\"options\":{optionsPayload}");
        }
    }
}