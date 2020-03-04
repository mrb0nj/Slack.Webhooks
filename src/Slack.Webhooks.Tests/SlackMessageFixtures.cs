using System;
using System.Collections.Generic;
using Slack.Webhooks.Blocks;
using Slack.Webhooks.Classes;
using Slack.Webhooks.Message;
using Slack.Webhooks.Messages;
using Slack.Webhooks.Webhook;
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

        private static WebhookMessage GetSlackMessage()
        {
            return new WebhookMessage
            {
                Text = $"Test {nameof(MessageBase.Text)}",
                ResponseType = $"Test {nameof(MessageBase.ResponseType)}",
                ReplaceOriginal = true,
                DeleteOriginal = true,
                Channel = $"Test {nameof(MessageBase.Channel)}",
                Username = $"Test {nameof(MessageBase.Username)}",
                IconEmoji = Emoji.Cactus,
                IconUrl = new Uri("http://test.com/icon.jpg"),
                Markdown = true,
                LinkNames = true,
                Parse = ParseMode.Full,
                ThreadId = $"Test {nameof(MessageBase.ThreadId)}",
                Attachments = new List<Attachment>{ new Attachment() },
                Blocks = new List<BlockBase>{ new ContextBlock() }
            };
        }
    }
}