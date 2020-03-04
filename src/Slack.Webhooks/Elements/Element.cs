using Slack.Webhooks.Classes;
using Slack.Webhooks.Message;

namespace Slack.Webhooks.Elements
{
    public class Element
    {
        /// <summary>
        /// The type of element represented by <see cref="ElementType"/>.
        /// </summary>
        public ElementType Type { get; set; }

        protected Element(ElementType elementType)
        {
            Type = elementType;
        }

        public bool ShouldSerializeType()
        {
            return Type != ElementType.Unknown;
        }
    }
}