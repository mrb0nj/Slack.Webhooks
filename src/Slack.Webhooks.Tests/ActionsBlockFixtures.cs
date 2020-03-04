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
    public class ActionsBlockFixtures
    {
        [Fact]
        public void ShouldSerializeActionElements()
        {
            // arrange 
            var elementList = new List<IActionElement>
            {
                new Button(),
                new SelectChannels(),
                new SelectConversations(),
                new SelectExternal(),
                new SelectStatic(),
                new SelectUsers(),
                new Overflow(),
                new DatePicker()
            };
            var actions = new ActionsBlock { Elements = elementList };

            // act
            var elementListPayload = SerializationHelper.Serialize(elementList);
            var payload = SerializationHelper.Serialize(actions);

            // assert
            payload.Should().Contain($"\"elements\":{elementListPayload}");
        }
    }
}