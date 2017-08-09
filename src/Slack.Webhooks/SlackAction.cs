using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Slack.Webhooks
{
    /// <summary>
    /// Slack attachment action. An attachment can have zero or more actions.
    /// </summary>
    public class SlackAction
    {
        private const string _type = "button";
        public string Name { get; set; }
        public string Type { get { return _type; } }
        public string Text { get; set; }
        public string Value { get; set; }
        public SlackConfirmAction Confirm { get; set; }
    }
}
