using Slack.Webhooks.Messages;

namespace Slack.Webhooks.Webhook
{
    public class WebhookMessage : MessageBase
    {
        /// <summary>
        /// Create a clone of this <see cref="WebhookMessage"/> overriding the channel if provided
        /// </summary>
        public WebhookMessage Clone(string newChannel = null)
        {
            return new WebhookMessage
            {
                Attachments = Attachments,
                Blocks = Blocks,
                Channel = newChannel ?? Channel,
                DeleteOriginal = DeleteOriginal,
                IconEmoji = IconEmoji,
                IconUrl = IconUrl,
                LinkNames = LinkNames,
                Markdown = Markdown,
                Parse = Parse,
                ReplaceOriginal = ReplaceOriginal,
                ResponseType = ResponseType,
                Text = Text,
                Username = Username
            };
        }
    }
}