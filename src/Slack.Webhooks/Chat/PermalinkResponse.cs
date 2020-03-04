using Slack.Webhooks.Classes;

namespace Slack.Webhooks.Chat
{
    public class PermalinkResponse: ResponseBase
    {
        public string Channel { get; set; }
        public string Permalink { get; set; }
    }
}