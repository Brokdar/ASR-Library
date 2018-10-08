using System.Xml.Linq;
using Xunit;

namespace AsrLibrary.Test.Model.Documentation.DocumentationBlock
{
    public class DefaultDocumentationBlock
    {
        private const string EmptyNode = "<DOC></DOC>";

        [Fact]
        public void Exists()
        {
            var node = XElement.Parse(EmptyNode);

            var doc = ASR.Model.Documentation.DocumentationBlock.FromXElement(node);

            Assert.NotNull(doc);
        }

        [Fact]
        public void IsArObject()
        {
            var node = XElement.Parse(EmptyNode);

            var doc = ASR.Model.Documentation.DocumentationBlock.FromXElement(node);

            Assert.IsAssignableFrom<ASR.Model.ArObject>(doc);
        }

        [Fact]
        public void HasEmptyParagraphs()
        {
            var node = XElement.Parse(EmptyNode);

            var doc = ASR.Model.Documentation.DocumentationBlock.FromXElement(node);

            Assert.Empty(doc.Paragraphs);
        }
    }
}