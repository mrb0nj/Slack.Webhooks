using System.Collections.Generic;
using FluentAssertions;
using Slack.Webhooks.Api;
using Slack.Webhooks.Elements;
using Xunit;

namespace Slack.Webhooks.Tests
{
    public class RadioButtonElementFixtures
    {
        [Fact]
        public void ShouldSerializeType()
        {
            // arrange
            var radio = new RadioButtons();

            // act
            var payload = ApiBase.SerializeObject(radio);

            // assert
            payload.Should().Contain("\"type\":\"radio_buttons\"");
        }


        [Fact]
        public void ShouldSerializeActionId()
        {
            // arrange
            var radio = new RadioButtons { ActionId = "Action123" };

            // act
            var payload = ApiBase.SerializeObject(radio);

            // assert
            payload.Should().Contain("\"action_id\":\"Action123\"");
        }


        [Fact]
        public void ShouldSerializeConfirm()
        {
            // arrange
            var confirm = new Confirmation();
            var radio = new RadioButtons { Confirm = confirm };

            // act
            var confirmPayload = ApiBase.SerializeObject(confirm);
            var payload = ApiBase.SerializeObject(radio);

            // assert
            payload.Should().Contain($"\"confirm\":{confirmPayload}");
        }

        [Fact]
        public void ShouldSerializeOptions()
        {
            // arrange
            var options = new List<Option> { new Option { Value = "Value123" } };
            var radio = new RadioButtons { Options = options };

            // act
            var optionsPayload = ApiBase.SerializeObject(options);
            var payload = ApiBase.SerializeObject(radio);

            // assert
            payload.Should().Contain($"\"options\":{optionsPayload}");
        }

        [Fact]
        public void ShouldSerializeInitialOption()
        {
            // arrange
            var option = new Option { Value = "Value123" };
            var radio = new RadioButtons { InitialOption = option };

            // act
            var optionsPayload = ApiBase.SerializeObject(option);
            var payload = ApiBase.SerializeObject(radio);

            // assert
            payload.Should().Contain($"\"initial_option\":{optionsPayload}");
        }

    }
}