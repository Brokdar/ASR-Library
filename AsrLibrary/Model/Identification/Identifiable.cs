using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ASR.Model.Documentation;

namespace ASR.Model.Identification
{
    /// <inheritdoc cref="ArObject" />
    /// <summary>
    /// Instances of this class can be referred to by their identifier (within the namespace
    /// borders). In addition to this, Identifiables are objects which contribute significantly to
    /// the overall structure of an AUTOSAR description. In particular, Identifiables might
    /// contain Identifiables.
    /// </summary>
    public abstract class Identifiable : ArObject, IMultiReferable
    {
        private readonly List<MultiLanguageParagraph> _longName = new List<MultiLanguageParagraph>();
        private readonly List<MultiLanguageParagraph> _description = new List<MultiLanguageParagraph>();

        /// <inheritdoc/>
        public string ShortName { get; private set; }

        /// <inheritdoc/>
        public IReadOnlyCollection<MultiLanguageParagraph> LongName => _longName;

        /// <summary>
        /// This represents a general but brief (one paragraph) description what the object 
        /// in question is about. It is only one paragraph! Desc is intended to be collected 
        /// into overview tables. This property helps a human reader to identify the object in question.
        /// </summary>
        public IReadOnlyCollection<MultiLanguageParagraph> Description => _description;

        /// <summary>
        /// The category is a keyword that specializes the semantics of the Identifiable. 
        /// It affects the expected existence of attributes and the applicability of constraints.
        /// </summary>
        public string Category { get; private set; }

        /// <summary>
        /// The purpose of this attribute is to provide a globally unique identifier for 
        /// an instance of a meta-class. The values of this attribute should be globally 
        /// unique strings prefixed by the type of identifier. For example, to include 
        /// a DCE UUID as defined by The Open Group, the UUID would be preceded by "DCE:". 
        /// The values of this attribute may be used to support merging of different AUTOSAR models.
        /// </summary>
        public string Uuid { get; private set; }

        protected Identifiable(XElement node) : base(node)
        {
            ParseAttributes(node);
            ParseElements(node);
        }

        private void ParseAttributes(XElement node)
        {
            ExtractUuid(node);
        }

        private void ParseElements(XContainer node)
        {
            foreach (var element in node.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "SHORT-NAME":
                        ExtractShortName(element);
                        break;
                    case "LONG-NAME":
                        ExtractLongName(element);
                        break;
                    case "DESC":
                        ExtractDescription(element);
                        break;
                    case "CATEGORY":
                        ExtractCategory(element);
                        break;
                    default:
                        return;
                }
            }
        }

        private void ExtractShortName(XElement node)
        {
            ShortName = node.Value;
        }

        private void ExtractLongName(XContainer node)
        {
            var elements = GetElementsWithName(node, "L-4");
            if (elements != null)
                AddMultiLanguageParagraphToContainer(_longName, elements);
        }

        private void ExtractDescription(XContainer node)
        {
            var elements = GetElementsWithName(node, "L-2");
            if (elements != null)
                AddMultiLanguageParagraphToContainer(_description, elements);
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

        private void ExtractCategory(XElement node)
        {
            Category = node.Value;
        }

        private void ExtractUuid(XElement node)
        {
            var attribute = node?.Attribute("UUID");
            if (attribute != null)
                Uuid = attribute.Value;
        }
    }
}