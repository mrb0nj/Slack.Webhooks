using System.Collections.Generic;
using FluentAssertions;
using Slack.Webhooks.Classes;
using Slack.Webhooks.Elements;
using Slack.Webhooks.Helpers;
using Xunit;

namespace Slack.Webhooks.Tests
{
    public class MultiSelectExternalElementFixtures
    {
        [Fact]
        public void ShouldSerializeMinQueryLength()
        {
            // arrange
            var select = new MultiSelectExternal { MinQueryLength = 5 };

            // act
            var payload = SerializationHelper.Serialize(select);

            // assert
            payload.Should().Contain($"\"min_query_length\":5");
        }

        [Fact]
        public void ShouldSerializeInitialOptions()
        {
            // arrange
            var options = new List<Option> { new Option { Value = "Value123" } };
            var select = new MultiSelectExternal { InitialOptions = options };

            // act
            var optionsPayload = SerializationHelper.Serialize(options);
            var payload = SerializationHelper.Serialize(select);

            // assert
            payload.Should().Contain($"\"initial_options\":{optionsPayload}");
        }
    }
}