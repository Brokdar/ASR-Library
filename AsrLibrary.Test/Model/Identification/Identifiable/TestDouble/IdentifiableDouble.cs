using System.Xml.Linq;

namespace AsrLibrary.Test.Model.Identification.Identifiable.TestDouble
{
    public class IdentifiableDouble : ASR.Model.Identification.Identifiable
    {
        public IdentifiableDouble(XElement node) : base(node)
        {
        }
    }
}