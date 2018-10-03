using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ASR.Model.Documentation
{
    /// <inheritdoc />
    /// <summary>
    /// This class represents a documentation block. It is made of basic text structure
    /// elements which can be displayed in a table cell.
    /// </summary>
    public class DocumentationBlock : ArObject
    {
        private readonly List<MultiLanguageParagraph> _paragraphs = new List<MultiLanguageParagraph>();
        /// <summary>
        /// This is one particular paragraph.
        /// </summary>
        public IReadOnlyCollection<MultiLanguageParagraph> Paragraphs => _paragraphs;

        private DocumentationBlock(XElement node) : base(node)
        {
            Parse(node);
        }

        private void Parse(XContainer node)
        {
            var p = node.Element("P");
            if (p == null)
                return;

            var texts = GetElementsWithName(p, "L-1");
            AddMultiLanguageParagraphToContainer(_paragraphs, texts);
        }

        private static IEnumerable<XElement> GetElementsWithName(XContainer node, string name)
        {
            return node.Elements().Where(e => e.Name.LocalName == name);
        }

        private static void AddMultiLanguageParagraphToContainer(ICollection<MultiLanguageParagraph> list, IEnumerable<XElement> elements)
        {
            foreach (var element in elements)
            {
                var language = element.FirstAttribute.Value;
                list.Add(new MultiLanguageParagraph(language, element.Value));
            }
        }

        public static DocumentationBlock FromXElement(XElement node)
        {
            if (node == null)
                return null;

            return new DocumentationBlock(node);
        }
    }
}