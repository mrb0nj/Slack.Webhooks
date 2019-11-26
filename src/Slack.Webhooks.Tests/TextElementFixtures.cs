using FluentAssertions;
using Slack.Webhooks.Elements;
using Xunit;

namespace Slack.Webhooks.Tests
{
    public class TextElementFixtures
    {
        [Theory]
        [InlineData(TextObject.TextType.Markdown, "mrkdwn")]
        [InlineData(TextObject.TextType.PlainText, "plain_text")]
        public void ShouldContainTextType(TextObject.TextType textType, string expected)
        {
            // arrange
            var text = new TextObject { Type = textType };

            // act
            var payload = SlackClient.SerializeObject(text);

            // assert
            payload.Should().Contain($"\"type\":\"{expected}\"");

        }

        [Fact]
        public void ShouldNotContainEmojiWhenTextTypeIsMarkdown()
        {
            // arrange
            var text = new TextObject { Type = TextObject.TextType.Markdown };

            // act
            var payload = SlackClient.SerializeObject(text);

            // assert
            payload.Should().NotContain("\"emoji\":");
        }

        [Fact]
        public void ShouldNotSerializeVerbatimWhenTextTypeIsPlainText()
        {
            // arrange
            var text = new TextObject { Type = TextObject.TextType.PlainText };

            // act
            var payload = SlackClient.SerializeObject(text);

            // assert
            payload.Should().NotContain("\"verbatim\":");
        }
    }
}