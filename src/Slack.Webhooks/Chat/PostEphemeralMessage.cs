using Slack.Webhooks.Messages;

namespace Slack.Webhooks.Chat
{
    public class PostEphemeralMessage : MessageBase
    {
        public string User { get; set; }
        public bool? AsUser { get; set; }
    }
}