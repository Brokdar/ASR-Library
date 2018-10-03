using System.Xml.Linq;
using ASR.Model.Documentation;

namespace ASR.Model.AdministrationData
{
    /// <inheritdoc />
    /// <summary>
    /// This meta-class represents the ability to record what has changed in a document in
    /// comparison to its predecessor.
    /// </summary>
    public class Modification : ArObject
    {
        /// <summary>
        /// This property denotes the one particular change which was performed on the object.
        /// </summary>
        public MultiLanguageParagraph Change { get; private set; }

        /// <summary>
        /// This property represents the rationale for the particular change.
        /// </summary>
        public MultiLanguageParagraph Reason { get; private set; }

        private Modification(XElement node) : base(node)
        {
        }

        public Modification FromXElement(XElement node)
        {
            if (node == null || node.Name.LocalName != "MODIFICATION")
                return null;

            return new Modification(node);
        }
    }
}