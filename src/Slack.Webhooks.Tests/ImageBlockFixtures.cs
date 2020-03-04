using FluentAssertions;
using Slack.Webhooks.Blocks;
using Slack.Webhooks.Classes;
using Slack.Webhooks.Elements;
using Slack.Webhooks.Helpers;
using Xunit;

namespace Slack.Webhooks.Tests
{
    public class ImageBlockFixtures
    {
        [Fact]
        public void ShouldContainImageUrl()
        {
            // arrange
            var image = new Blocks.ImageBlock { ImageUrl = "http://someimage" };

            // act
            var payload = SerializationHelper.Serialize(image);

            // assert
            payload.Should().Contain("\"image_url\":\"http://someimage\"");
        }

        [Fact]
        public void ShouldContainAltText()
        {
            // arrange
            var image = new Blocks.ImageBlock { AltText = "The Text" };

            // act
            var payload = SerializationHelper.Serialize(image);

            // assert
            payload.Should().Contain("\"alt_text\":\"The Text\"");
        }

        [Fact]
        public void ShouldContainTitle()
        {
            // arrange
            var image = new Blocks.ImageBlock { Title = new TextObject { Text = "The Title" } };

            // act
            var payload = SerializationHelper.Serialize(image);

            // assert
            payload.Should().Contain("\"text\":\"The Title\"");
        }


    }
}