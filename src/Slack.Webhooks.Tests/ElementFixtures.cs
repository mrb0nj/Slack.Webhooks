using System.Collections.Generic;
using FluentAssertions;
using Slack.Webhooks.Api;
using Xunit;

namespace Slack.Webhooks.Tests
{
    public class ElementFixtures
    {
        [Theory]
        [MemberData(nameof(GetData))]
        public void ShouldHaveBlockTypeAndBlockId(Elements.Element element, string expectedType)
        {
            // arrange/act
            var payload = ApiBase.SerializeObject(element);

            // assert
            payload.Should().Contain($"\"type\":\"{expectedType}\"");
        }

        public static IEnumerable<object[]> GetData()
        {
            return new List<object[]>
            {
                new object[] { new Elements.Button(), "button"},
                new object[] { new Elements.DatePicker(), "datepicker" },
                new object[] { new Elements.Image(), "image" },
                new object[] { new Elements.MultiSelectChannels(), "multi_channels_select" },
                new object[] { new Elements.MultiSelectConversations(), "multi_conversations_select" },
                new object[] { new Elements.MultiSelectExternal(), "multi_external_select" },
                new object[] { new Elements.MultiSelectStatic(), "multi_static_select"},
                new object[] { new Elements.MultiSelectUsers(), "multi_users_select"},
                new object[] { new Elements.Overflow(), "overflow"},
                new object[] { new Elements.PlainTextInput(), "plain_text_input"},
                new object[] { new Elements.RadioButtons(), "radio_buttons"},
                new object[] { new Elements.SelectChannels(), "channels_select" },
                new object[] { new Elements.SelectConversations(), "conversations_select" },
                new object[] { new Elements.SelectExternal(), "external_select" },
                new object[] { new Elements.SelectStatic(), "static_select"},
                new object[] { new Elements.SelectUsers(), "users_select"}
            };
        }
    }
}