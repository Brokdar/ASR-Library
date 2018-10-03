using System.Xml.Linq;
using ASR.Model.Identification;

namespace AsrLibrary.Tests.ArIdentifiable.TestDouble
{
    public class ArIdentifiableDouble : Identifiable
    {
        public ArIdentifiableDouble(XElement node) : base(node)
        {
        }
    }
}