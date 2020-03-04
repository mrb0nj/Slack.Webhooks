using System.Collections.Generic;
using FluentAssertions;
using Slack.Webhooks.Blocks;
using Slack.Webhooks.Classes;
using Slack.Webhooks.Elements;
using Slack.Webhooks.Helpers;
using Xunit;

namespace Slack.Webhooks.Tests
{
    public class SectionBlockFixtures
    {
        [Fact]
        public void ShouldSerializeText()
        {
            // arrange
            var textObject = new TextObject { Text = "This is text" };
            var section = new SectionBlock { Text = textObject };

            // act
            var textPayload = SerializationHelper.Serialize(textObject);
            var payload = SerializationHelper.Serialize(section);

            // assert
            payload.Should().Contain($"\"text\":{textPayload}");
        }

        [Fact]
        public void ShouldSerializeFields()
        {
            // arrange
            var fieldsList = new List<TextObject> { new TextObject { Text = "This is text" } };
            var section = new SectionBlock { Fields = fieldsList };

            // act
            var fieldsPayload = SerializationHelper.Serialize(fieldsList);
            var payload = SerializationHelper.Serialize(section);

            // assert
            payload.Should().Contain($"\"fields\":{fieldsPayload}");
        }

        [Fact]
        public void ShouldSerializeAccessory()
        {
            // arrange
            var button = new Button();
            var section = new SectionBlock { Accessory = button };

            // act
            var accessoryPayload = SerializationHelper.Serialize(button);
            var payload = SerializationHelper.Serialize(section);

            // assert
            payload.Should().Contain($"\"accessory\":{accessoryPayload}");
        }
    }
}