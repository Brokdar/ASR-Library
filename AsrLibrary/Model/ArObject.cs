using System;
using System.Xml.Linq;

namespace ASR.Model
{
    /// <summary>
    /// Implicit base class of all classes in meta-model
    /// </summary>
    public abstract class ArObject
    {
        /// <summary>
        /// Checksum calculated by the user’s tool environment for an ArObject. 
        /// May be used in an own tool environment to determine if an ArObject has changed. 
        /// The checksum has no semantic meaning for an AUTOSAR model and there is 
        /// no requirement for AUTOSAR tools to manage the checksum
        /// </summary>
        /// <tag>xml.name=S</tag>
        public string Checksum { get; protected set; }

        /// <summary>
        /// Timestamp calculated by the user’s tool environment for an ArObject. May be used in an
        /// own tool environment to determine the last change of an ArObject. The timestamp has no
        /// semantic meaning for an AUTOSAR model and there is no requirement for AUTOSAR tools to
        /// manage the timestamp.
        /// </summary>
        /// <tag>xml.name=T</tag>
        public DateTime? TimeStamp { get; protected set; }

        protected ArObject(XElement node)
        {
            if (node == null) throw new ArgumentNullException();

            var timestamp = node.Attribute("T");
            if (timestamp != null)
                TimeStamp = DateTime.Parse(timestamp.Value);

            var checksum = node.Attribute("S");
            if (checksum != null)
                Checksum = checksum.Value;
        }
    }
}