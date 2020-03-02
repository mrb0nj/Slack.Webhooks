using System.Collections.Generic;
using FluentAssertions;
using Slack.Webhooks.Api;
using Slack.Webhooks.Elements;
using Xunit;

namespace Slack.Webhooks.Tests
{
    public class SelectStaticElementFixtures
    {
        [Fact]
        public void ShouldSerializeOptions()
        {
            // arrange
            var options = new List<Option> { new Option { Value = "Value123" } };
            var select = new SelectStatic { Options = options };

            // act
            var optionsPayload = ApiBase.SerializeObject(options);
            var payload = ApiBase.SerializeObject(select);

            // assert
            payload.Should().Contain($"\"options\":{optionsPayload}");
        }

        [Fact]
        public void ShouldSerializeInitialOption()
        {
            // arrange
            var option = new Option { Value = "Value123" };
            var select = new SelectStatic { InitialOption = option };

            // act
            var optionsPayload = ApiBase.SerializeObject(option);
            var payload = ApiBase.SerializeObject(select);

            // assert
            payload.Should().Contain($"\"initial_option\":{optionsPayload}");
        }

        [Fact]
        public void ShouldSerializeInitialOptionGroup()
        {
            // arrange
            var options = new List<Option> { new Option { Value = "Value123" } };
            var groups = new List<OptionGroup> { new OptionGroup { Options = options } };
            var select = new SelectStatic { OptionGroups = groups };

            // act
            var groupsPayload = ApiBase.SerializeObject(groups);
            var payload = ApiBase.SerializeObject(select);

            // assert
            payload.Should().Contain($"\"option_groups\":{groupsPayload}");
        }
    }
}