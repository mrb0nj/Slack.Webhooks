using System.Collections.Generic;
using FluentAssertions;
using Slack.Webhooks.Blocks;
using Slack.Webhooks.Classes;
using Slack.Webhooks.Elements;
using Slack.Webhooks.Helpers;
using Slack.Webhooks.Interfaces;
using Xunit;

namespace Slack.Webhooks.Tests
{
    public class ContextBlockFixtures
    {
        [Fact]
        public void ShouldBeAbleToContainImageElements()
        {
            // arrange
            var context = new ContextBlock
            {
                Elements = new List<IContextElement>() { new Blocks.ImageBlock() }
            };

            // act
            var payload = SerializationHelper.Serialize(context);

            // assert
            payload.Should().Contain("\"elements\":["); // bleeugh
        }

        [Fact]
        public void ShouldBeAbleToContainTextElements()
        {
            // arrange
            var context = new ContextBlock
            {
                Elements = new List<IContextElement>() { new TextObject() }
            };

            // act
            var payload = SerializationHelper.Serialize(context);

            // assert
            payload.Should().Contain("\"elements\":["); // bleeugh
        }
    }
}