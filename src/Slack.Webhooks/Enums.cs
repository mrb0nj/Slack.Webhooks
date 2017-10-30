namespace Slack.Webhooks
{
    public enum SlackActionDataSource
    {
        Static,
        Users,
        Channels,
        Conversations,
        External
    }

    public enum SlackActionStyle
    {
        Default,
        Primary,
        Danger
    }

    public enum SlackActionType
    {
        Button,
        Select
    }
}
