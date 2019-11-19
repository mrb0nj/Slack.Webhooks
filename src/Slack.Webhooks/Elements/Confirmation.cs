namespace Slack.Webhooks.Elements
{
    /// <summary>
    /// An object that defines a dialog that provides a confirmation step to any interactive element. This dialog will ask the user to confirm their action by offering a confirm and deny buttons.
    /// </summary>
    public class Confirmation
    {
        /// <summary>
        /// A <see cref="TextObject.TextType.PlainText"/>-only <see cref="TextObject"/> that defines the dialog's title. Maximum length for this field is 100 characters.
        /// </summary>
        public TextObject Title { get; set; }
        /// <summary>
        /// A <see cref="TextObject"/> that defines the explanatory text that appears in the confirm dialog. Maximum length for the <see cref="TextObject.Text"/> in this field is 300 characters.
        /// </summary>
        public TextObject Text { get; set; }
        /// <summary>
        /// A <see cref="TextObject.TextType.PlainText"/>-only <see cref="TextObject"/> to define the text of the button that confirms the action. Maximum length for the <see cref="TextObject.Text"/> in this field is 30 characters.
        /// </summary>
        public TextObject Confirm { get; set; }
        /// <summary>
        /// A <see cref="TextObject.TextType.PlainText"/>-only <see cref="TextObject"/> to define the text of the button that cancels the action. Maximum length for the <see cref="TextObject.Text"/> in this field is 30 characters.
        /// </summary>
        public TextObject Deny { get; set; }
    }
}