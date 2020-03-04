using Slack.Webhooks.Messages;

namespace Slack.Webhooks.Chat
{
    public class ChatMessage : MessageBase
    {
        public bool AsUser { get; set; }
        public bool UnfurlLinks { get; set; }
        public bool UnfurlMedia { get; set; }

        public bool ShouldSerializeAsUser()
        {
            return !string.IsNullOrWhiteSpace(Username);
        }
    }
}