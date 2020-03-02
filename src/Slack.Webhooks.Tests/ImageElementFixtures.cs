using FluentAssertions;
using Slack.Webhooks.Api;
using Slack.Webhooks.Elements;
using Xunit;

namespace Slack.Webhooks.Tests
{
    public class ImageElementFixtures
    {
        [Fact]
        public void ShouldSerializeType()
        {
            // arrange
            var image = new Image();

            // act
            var payload = ApiBase.SerializeObject(image);

            // assert
            payload.Should().Contain("\"type\":\"image\"");
        }

        [Fact]
        public void ShouldSerializeImageUrl()
        {
            // arrange
            var image = new Image { ImageUrl = "http://someurl.com" };

            // act
            var payload = ApiBase.SerializeObject(image);

            // assert
            payload.Should().Contain("\"image_url\":\"http://someurl.com\"");
        }

        [Fact]
        public void ShouldSerializeAltText()
        {
            // arrange
            var image = new Image { AltText = "Alternate Text" };

            // act
            var payload = ApiBase.SerializeObject(image);

            // assert
            payload.Should().Contain("\"alt_text\":\"Alternate Text\"");
        }
    }
}