using FluentAssertions;
using Slack.Webhooks.Elements;
using Xunit;

namespace Slack.Webhooks.Tests
{
    public class SelectElementFixtures
    {
        [Theory]
        [InlineData(ElementType.MultiSelectStatic, "multi_static_select")]
        [InlineData(ElementType.MultiSelectExternal, "multi_external_select")]
        [InlineData(ElementType.MultiSelectUsers, "multi_users_select")]
        [InlineData(ElementType.MultiSelectConversations, "multi_conversations_select")]
        [InlineData(ElementType.MultiSelectChannels, "multi_channels_select")]
        [InlineData(ElementType.SelectStatic, "static_select")]
        [InlineData(ElementType.SelectExternal, "external_select")]
        [InlineData(ElementType.SelectUsers, "users_select")]
        [InlineData(ElementType.SelectConversations, "conversations_select")]
        [InlineData(ElementType.SelectChannels, "channels_select")]
        public void ShouldSerializeType(ElementType elementType, string expected)
        {
            // arrange
            var select = new Select(elementType);

            // act
            var payload = SlackClient.SerializeObject(select);

            // assert
            payload.Should().Contain($"\"type\":\"{expected}\"");
        }

        [Fact]
        public void ShouldSerializeActionId()
        {
            // arrange
            var button = new Select(ElementType.MultiSelectStatic) { ActionId = "Action123" };

            // act
            var payload = SlackClient.SerializeObject(button);

            // assert
            payload.Should().Contain("\"action_id\":\"Action123\"");
        }

        [Fact]
        public void ShouldSerializePlaceholder()
        {
            // arrange
            var text = new TextObject();
            var button = new Select(ElementType.MultiSelectStatic) { Placeholder = text };

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
            var button = new Select(ElementType.MultiSelectStatic) { Confirm = confirm };

            // act
            var confirmPayload = SlackClient.SerializeObject(confirm);
            var payload = SlackClient.SerializeObject(button);

            // assert
            payload.Should().Contain($"\"confirm\":{confirmPayload}");
        }
    }
}