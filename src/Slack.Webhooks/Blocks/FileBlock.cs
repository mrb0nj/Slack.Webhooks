using Slack.Webhooks.Classes;
using Slack.Webhooks.Message;

namespace Slack.Webhooks.Blocks
{
    /// <summary>
    /// Displays a remote file.
    /// </summary>
    public class FileBlock : BlockBase
    {
        /// <summary>
        /// The external unique ID for this file.
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// At the moment, <see cref="Source"/> will always be "remote" for a remote file.
        /// </summary>
        public string Source { get; set; } = "remote";

        /// <summary>
        /// Create a new <see cref="FileBlock"/> instance.
        /// </summary>
        public FileBlock() : base(BlockType.File)
        {
        }
    }
}