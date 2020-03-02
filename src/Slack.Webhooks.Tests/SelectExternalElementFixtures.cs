using System.Collections.Generic;
using FluentAssertions;
using Slack.Webhooks.Api;
using Slack.Webhooks.Elements;
using Xunit;

namespace Slack.Webhooks.Tests
{
    public class SelectExternalElementFixtures
    {
        [Fact]
        public void ShouldSerializeMinQueryLength()
        {
            // arrange
            var select = new SelectExternal { MinQueryLength = 5 };

            // act
            var payload = ApiBase.SerializeObject(select);

            // assert
            payload.Should().Contain($"\"min_query_length\":5");
        }

        [Fact]
        public void ShouldSerializeInitialOption()
        {
            // arrange
            var option = new Option { Value = "Value123" };
            var select = new SelectExternal { InitialOption = option };

            // act
            var optionsPayload = ApiBase.SerializeObject(option);
            var payload = ApiBase.SerializeObject(select);

            // assert
            payload.Should().Contain($"\"initial_option\":{optionsPayload}");
        }
    }
}