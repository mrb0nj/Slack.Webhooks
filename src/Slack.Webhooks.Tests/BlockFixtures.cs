using System.Collections.Generic;
using FluentAssertions;
using Newtonsoft.Json;
using Slack.Webhooks.Blocks;
using Xunit;

namespace Slack.Webhooks.Tests
{
    public class BlockFixtures
    {
        [Theory]
        [MemberData(nameof(GetData))]
        public void ShouldHaveBlockTypeAndBlockId(Block block, string expectedType, string expectedBlockId)
        {
            // arrange/act
            var payload = SlackClient.SerializeObject(block);

            // assert
            payload.Should().Contain($"\"type\":\"{expectedType}\"");
            payload.Should().Contain($"\"block_id\":\"{expectedBlockId}\"");
        }

        public static IEnumerable<object[]> GetData()
        {
            return new List<object[]>
            {
                new object[] { new Divider {BlockId = "0001"}, "divider", "0001" },
                new object[] { new Image {BlockId = "0002"}, "image", "0002" },
                new object[] { new Section {BlockId = "0003"}, "section", "0003" },
                new object[] { new Context {BlockId = "0004"}, "context", "0004" },
                new object[] { new File {BlockId = "0005"}, "file", "0005" },
                new object[] { new Actions {BlockId = "0006"}, "actions", "0006" },
                new object[] { new Input {BlockId = "0007"}, "input", "0007" }
            };
        }
    }
}