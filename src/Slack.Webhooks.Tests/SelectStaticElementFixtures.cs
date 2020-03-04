using System.Collections.Generic;
using FluentAssertions;
using Slack.Webhooks.Classes;
using Slack.Webhooks.Elements;
using Slack.Webhooks.Helpers;
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
            var optionsPayload = SerializationHelper.Serialize(options);
            var payload = SerializationHelper.Serialize(select);

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
            var optionsPayload = SerializationHelper.Serialize(option);
            var payload = SerializationHelper.Serialize(select);

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
            var groupsPayload = SerializationHelper.Serialize(groups);
            var payload = SerializationHelper.Serialize(select);

            // assert
            payload.Should().Contain($"\"option_groups\":{groupsPayload}");
        }
    }
}