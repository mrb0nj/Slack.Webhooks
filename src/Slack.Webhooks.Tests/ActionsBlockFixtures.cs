using System.Collections.Generic;
using FluentAssertions;
using Slack.Webhooks.Api;
using Slack.Webhooks.Blocks;
using Slack.Webhooks.Elements;
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
            var actions = new Actions { Elements = elementList };

            // act
            var elementListPayload = ApiBase.SerializeObject(elementList);
            var payload = ApiBase.SerializeObject(actions);

            // assert
            payload.Should().Contain($"\"elements\":{elementListPayload}");
        }
    }
}