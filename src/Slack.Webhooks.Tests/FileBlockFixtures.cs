using FluentAssertions;
using Slack.Webhooks.Blocks;
using Slack.Webhooks.Classes;
using Slack.Webhooks.Helpers;
using Xunit;

namespace Slack.Webhooks.Tests
{
    public class FileBlockFixtures
    {
        [Fact]
        public void ShouldHaveExternalId()
        {
            // arrange
            var file = new FileBlock { ExternalId = "AB_1234" };

            // act
            var payload = SerializationHelper.Serialize(file);

            // assert
            payload.Should().Contain("\"external_id\":\"AB_1234\"");
        }

        [Fact]
        public void ShouldHaveRemoteSourceByDefault()
        {
            // arrange
            var file = new FileBlock();

            // act
            var payload = SerializationHelper.Serialize(file);

            // assert
            file.Source.Should().Be("remote");
            payload.Should().Contain("\"source\":\"remote\"");
        }
    }
}