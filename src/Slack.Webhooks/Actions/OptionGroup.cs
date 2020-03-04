using System.Collections.Generic;

namespace Slack.Webhooks.Action
{
    public class OptionGroup
    {
        public string Text { get; set; }
        public List<Option> Options { get; set; }
    }
}