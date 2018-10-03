using System.Linq;
using System.Xml.Linq;
using Xunit;

namespace AsrLibrary.Test.Model.Documentation.DocumentationBlock
{
    public class CreateDocumentationBlockFromXElement
    {
        private const string DocumentationNode =
            "../../Model/Documentation/DocumentationBlock/ExampleData/00_DocumentationBlock.xml";

        [Fact]
        public void GivenParagraphsInDescription_ThenReturnedDocumentationBlockContainsParagraphs()
        {
            var node = XElement.Load(DocumentationNode);

            var doc = ASR.Model.Documentation.DocumentationBlock.FromXElement(node);

            Assert.NotEmpty(doc.Paragraphs);
            Assert.Equal(2, doc.Paragraphs.Count);
            Assert.Equal("EN", doc.Paragraphs.First().Language);
            Assert.Equal("FR", doc.Paragraphs.Last().Language);
        }
    }
}