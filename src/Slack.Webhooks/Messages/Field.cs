namespace Slack.Webhooks.Message
{
    /// <summary>
    /// Slack Field. Fields are displayed in a table on the message
    /// </summary>
    public class Field
    {
        /// <summary>
        /// Required Field Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Text value of the field. May contain standard message markup and must be escaped as normal. May be multi-line
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Optional flag indicating whether the `value` is short enough to be displayed side-by-side with other values
        /// </summary>
        public bool Short { get; set; }
    }
}
