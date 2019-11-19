using FluentAssertions;
using Slack.Webhooks.Elements;
using Xunit;

namespace Slack.Webhooks.Tests
{
    public class DatePickerElementFixtures
    {
        [Fact]
        public void ShouldSerializeType()
        {
            // arrange
            var button = new DatePicker();

            // act
            var payload = SlackClient.SerializeObject(button);

            // assert
            payload.Should().Contain("\"type\":\"datepicker\"");
        }

        [Fact]
        public void ShouldSerializeActionId()
        {
            // arrange
            var button = new DatePicker { ActionId = "Action123" };

            // act
            var payload = SlackClient.SerializeObject(button);

            // assert
            payload.Should().Contain("\"action_id\":\"Action123\"");
        }

        [Fact]
        public void ShouldSerializeInitialDate()
        {
            // arrange
            var button = new DatePicker { InitialDate = "2019-11-01" };

            // act
            var payload = SlackClient.SerializeObject(button);

            // assert
            payload.Should().Contain("\"initial_date\":\"2019-11-01\"");
        }

        [Fact]
        public void ShouldSerializePlaceholder()
        {
            // arrange
            var text = new TextObject();
            var button = new DatePicker { Placeholder = text };

            // act
            var textPayload = SlackClient.SerializeObject(text);
            var payload = SlackClient.SerializeObject(button);

            // assert
            payload.Should().Contain($"\"placeholder\":{textPayload}");
        }

        [Fact]
        public void ShouldSerializeConfirm()
        {
            // arrange
            var confirm = new Confirmation();
            var button = new DatePicker { Confirm = confirm };

            // act
            var confirmPayload = SlackClient.SerializeObject(confirm);
            var payload = SlackClient.SerializeObject(button);

            // assert
            payload.Should().Contain($"\"confirm\":{confirmPayload}");
        }
    }
}