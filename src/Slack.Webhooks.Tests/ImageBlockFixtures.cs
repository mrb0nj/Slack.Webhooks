using FluentAssertions;
using Slack.Webhooks.Blocks;
using Slack.Webhooks.Elements;
using Xunit;

namespace Slack.Webhooks.Tests
{
    public class ImageBlockFixtures
    {
        [Fact]
        public void ShouldContainImageUrl()
        {
            // arrange
            var image = new Blocks.Image { ImageUrl = "http://someimage" };

            // act
            var payload = SlackClient.SerializeObject(image);

            // assert
            payload.Should().Contain("\"image_url\":\"http://someimage\"");
        }

        [Fact]
        public void ShouldContainAltText()
        {
            // arrange
            var image = new Blocks.Image { AltText = "The Text" };

            // act
            var payload = SlackClient.SerializeObject(image);

            // assert
            payload.Should().Contain("\"alt_text\":\"The Text\"");
        }

        [Fact]
        public void ShouldContainTitle()
        {
            // arrange
            var image = new Blocks.Image { Title = new TextObject { Text = "The Title"} };

            // act
            var payload = SlackClient.SerializeObject(image);

            // assert
            payload.Should().Contain("\"text\":\"The Title\"");
        }

        
    }
}