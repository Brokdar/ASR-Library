namespace ASR.Model.Documentation
{
    /// <summary>
    /// This is the content of a multilingual paragraph in an overview item
    /// </summary>
    public class MultiLanguageParagraph
    {
        /// <summary>
        /// The language of the written text
        /// </summary>
        public string Language { get; }
        /// <summary>
        /// Represents the text in the particular language
        /// </summary>
        public string Text { get; }

        public MultiLanguageParagraph(string language, string text)
        {
            Language = language;
            Text = text;
        }
    }
}