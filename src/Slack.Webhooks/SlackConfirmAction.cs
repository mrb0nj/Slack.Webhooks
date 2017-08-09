using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Slack.Webhooks
{
    public class SlackConfirmAction
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string OkText { get; set; }
        public string DismissText { get; set; }
    }
}
