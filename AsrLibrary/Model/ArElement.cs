using System.Xml.Linq;
using ASR.Model.Identification;

namespace ASR.Model
{
    /// <inheritdoc />
    /// <summary>
    /// An element that can be defined stand-alone, i.e. without being part of another
    /// element (except for packages of course)
    /// </summary>
    public class ArElement : Identifiable
    {
        public ArElement(XElement node) : base(node)
        {
        }

        public static ArElement FromXElement(XElement node)
        {
            return new ArElement(node);
        }
    }
}