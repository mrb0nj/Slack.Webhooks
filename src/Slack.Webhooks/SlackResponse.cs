namespace Slack.Webhooks
{
    public class SlackResponse
    {
        public bool ok { get; set; }
        public string channel { get; set; }
        public string ts { get; set; }
        public Message message { get; set; }
    }

    public class Message
    {
        public string type { get; set; }
        public string subtype { get; set; }
        public string text { get; set; }
        public string ts { get; set; }
        public string username { get; set; }
        public string bot_id { get; set; }
    }
}