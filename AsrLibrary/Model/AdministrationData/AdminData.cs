using System.Collections.Generic;
using System.Xml.Linq;
using ASR.Model.Documentation;
using ASR.Model.SpecialData;

namespace ASR.Model.AdministrationData
{
    /// <inheritdoc />
    /// <summary>
    /// AdminData represents the ability to express administrative information for an
    /// element. This administration information is to be treated as meta-data such as
    /// revision id or state of the file.
    /// </summary>
    public class AdminData : ArObject
    {
        private readonly List<Sdg> _sdgs = new List<Sdg>();
        private readonly List<DocRevision> _docRevisions = new List<DocRevision>();

        /// <summary>
        /// This attribute specifies the master language of the document or the document fragment.
        /// The master language is the one in which the document is maintained and from which
        /// the other languages are derived from. In particular in case of inconsistencies,
        /// the information in the master language is priority.
        /// </summary>
        /// 
        public string Language { get; private set; }
        /// <summary>
        /// This property specifies the languages which are provided in the document.
        /// Therefore it should only be specified in the top level admin data.
        /// For each language provided in the document there is one entry.
        /// The content of each entry can be used for illustration of the language.
        /// The used language itself depends on the language attribute in the entry.
        /// </summary>
        public MultiLanguageParagraph UsedLanguage { get; private set; }

        /// <summary>
        /// This property allows to keep special data which is not represented by the standard model.
        /// It can be utilized to keep e.g. tool specific data.
        /// </summary>
        public IReadOnlyCollection<Sdg> Sdgs => _sdgs;

        /// <summary>
        /// This allows to denote information about the current revision of the object.
        /// Note that information about previous revisions can also be logged here.
        /// The entries shall be sorted descendant by date in order to reflect the history.
        /// Therefore the most recent entry representing the current version is denoted first.
        /// </summary>
        public IReadOnlyCollection<DocRevision> DocRevisions => _docRevisions;

        private AdminData(XElement node) : base(node)
        {

        }

        public static AdminData FromXElement(XElement node)
        {
            if (node == null || node.Name.LocalName != "ADMIN-DATA")
                return null;

            return new AdminData(node);
        }
    }
}