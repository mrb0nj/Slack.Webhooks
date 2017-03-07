using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Slack.Webhooks.Core.ConsoleApp.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new SlackClient("https://hooks.slack.com/services/T00000000/B00000000/XXXXXXXXXXXXXXXXXXXXXXXX", 25);

            var message = new SlackMessage
            {
                Text = "Test message!",
                IconEmoji = Emoji.OkHand
            };

            Task.WaitAll(client.PostAsync(message));
        }
    }
}
