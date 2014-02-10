namespace Slack.Webhooks
{
    public class SlackMessage
    {
        public string Text { get; set; }
        public string Channel { get; set; }
        public string Username { get; set; }
        public string IconEmoji { get; set; }
    }
}