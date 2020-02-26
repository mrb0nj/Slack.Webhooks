using System;
using System.Collections.Generic;
using Slack.Webhooks.Blocks;
using Xunit;

namespace Slack.Webhooks.Tests
{
    public class SlackMessageFixtures
    {
        [Fact]
        public void ShouldCloneAllProperties()
        {
            //arrange
            var message = GetSlackMessage();

            //act
            var clonedMessage = message.Clone();

            //assert
            Assert.Equal(message.Text, clonedMessage.Text);
            Assert.Equal(message.ResponseType, clonedMessage.ResponseType);
            Assert.Equal(message.ReplaceOriginal, clonedMessage.ReplaceOriginal);
            Assert.Equal(message.DeleteOriginal, clonedMessage.DeleteOriginal);
            Assert.Equal(message.Channel, clonedMessage.Channel);
            Assert.Equal(message.IconEmoji, clonedMessage.IconEmoji);
            Assert.Equal(message.IconUrl, clonedMessage.IconUrl);
            Assert.Equal(message.Markdown, clonedMessage.Markdown);
            Assert.Equal(message.LinkNames, clonedMessage.LinkNames);
            Assert.Equal(message.Parse, clonedMessage.Parse);
            Assert.Equal(message.Attachments, clonedMessage.Attachments);
            Assert.Equal(message.Blocks, clonedMessage.Blocks);
        }

        private static SlackMessage GetSlackMessage()
        {
            return new SlackMessage
            {
                Text = $"Test {nameof(SlackMessage.Text)}",
                ResponseType = $"Test {nameof(SlackMessage.ResponseType)}",
                ReplaceOriginal = true,
                DeleteOriginal = true,
                Channel = $"Test {nameof(SlackMessage.Channel)}",
                Username = $"Test {nameof(SlackMessage.Username)}",
                IconEmoji = Emoji.Cactus,
                IconUrl = new Uri("http://test.com/icon.jpg"),
                Markdown = true,
                LinkNames = true,
                Parse = ParseMode.Full,
                ThreadId = $"Test {nameof(SlackMessage.ThreadId)}",
                Attachments = new List<SlackAttachment>{ new SlackAttachment() },
                Blocks = new List<Block>{ new Context() }
            };
        }
    }
}