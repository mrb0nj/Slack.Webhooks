using System.Collections.Generic;
using FluentAssertions;
using Newtonsoft.Json;
using Slack.Webhooks.Blocks;
using Slack.Webhooks.Classes;
using Slack.Webhooks.Helpers;
using Xunit;

namespace Slack.Webhooks.Tests
{
    public class BlockFixtures
    {
        [Theory]
        [MemberData(nameof(GetData))]
        public void ShouldHaveBlockTypeAndBlockId(BlockBase blockBase, string expectedType, string expectedBlockId)
        {
            // arrange/act
            var payload = SerializationHelper.Serialize(blockBase);

            // assert
            payload.Should().Contain($"\"type\":\"{expectedType}\"");
            payload.Should().Contain($"\"block_id\":\"{expectedBlockId}\"");
        }

        public static IEnumerable<object[]> GetData()
        {
            return new List<object[]>
            {
                new object[] { new DividerBlock {BlockId = "0001"}, "divider", "0001" },
                new object[] { new ImageBlock {BlockId = "0002"}, "image", "0002" },
                new object[] { new SectionBlock {BlockId = "0003"}, "section", "0003" },
                new object[] { new ContextBlock {BlockId = "0004"}, "context", "0004" },
                new object[] { new FileBlock {BlockId = "0005"}, "file", "0005" },
                new object[] { new ActionsBlock {BlockId = "0006"}, "actions", "0006" },
                new object[] { new InputBlock {BlockId = "0007"}, "input", "0007" }
            };
        }
    }
}