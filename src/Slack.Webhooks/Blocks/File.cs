namespace Slack.Webhooks.Blocks
{
    /// <summary>
    /// Displays a remote file.
    /// </summary>
    public class File : Block
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
        /// Create a new <see cref="File"/> instance.
        /// </summary>
        public File() : base(BlockType.File)
        {
        }
    }
}