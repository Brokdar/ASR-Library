using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ASR.Model.AdministrationData
{
    /// <inheritdoc />
    /// <summary>
    /// This meta-class represents the ability to maintain information which
    /// relates to revision management of documents or objects.
    /// </summary>
    public class DocRevision : ArObject
    {
        private readonly List<Modification> _modifications = new List<Modification>();

        /// <summary>
        /// This specifies the date and time, when the object in question was released
        /// </summary>
        public DateTime? Date { get; private set; }

        /// <summary>
        /// This is the name of an individual or an organization who issued
        /// the current revision of the document or document fragment.
        /// </summary>
        public string IssuedBy { get; private set; }

        /// <summary>
        /// This property represents one particular modification in comparison to its predecessor.
        /// </summary>
        public IReadOnlyCollection<Modification> Modifications => _modifications;

        /// <summary>
        /// This attribute represents the version number of the object.
        /// </summary>
        public string RevisionLabel { get; private set; }

        /// <summary>
        /// The attribute state represents the current state of the current file
        /// according to the configuration management plan.
        /// </summary>
        public string State { get; private set; }

        private DocRevision(XElement node) : base(node)
        {
        }

        public static DocRevision FromXElement(XElement node)
        {
            if (node == null || node.Name.LocalName != "DOC-REVISION")
                return null;

            return new DocRevision(node);
        }
    }
}