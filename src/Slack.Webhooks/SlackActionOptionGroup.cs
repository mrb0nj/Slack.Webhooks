using System.Collections.Generic;

namespace Slack.Webhooks
{
    public class SlackActionOptionGroup
    {
        public string Text { get; set; }
        public List<SlackActionOption> Options { get; set; }
    }
}