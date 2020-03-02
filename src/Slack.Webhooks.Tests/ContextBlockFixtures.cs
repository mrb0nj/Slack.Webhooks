using System.Collections.Generic;
using FluentAssertions;
using Slack.Webhooks.Api;
using Slack.Webhooks.Blocks;
using Slack.Webhooks.Elements;
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
            var context = new Context
            {
                Elements = new List<IContextElement>() { new Blocks.Image() }
            };

            // act
            var payload = ApiBase.SerializeObject(context);

            // assert
            payload.Should().Contain("\"elements\":["); // bleeugh
        }

        [Fact]
        public void ShouldBeAbleToContainTextElements()
        {
            // arrange
            var context = new Context
            {
                Elements = new List<IContextElement>() { new TextObject() }
            };

            // act
            var payload = ApiBase.SerializeObject(context);

            // assert
            payload.Should().Contain("\"elements\":["); // bleeugh
        }
    }
}