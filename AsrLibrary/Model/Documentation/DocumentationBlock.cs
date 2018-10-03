using System.Xml.Linq;

namespace ASR.Model.Documentation
{
    public class DocumentationBlock
    {
        private DocumentationBlock(XElement node)
        {
            
        }

        public static DocumentationBlock FromXElement(XElement node)
        {
            if (node == null || node.Name.LocalName != "INTRODUCTION")
                return null;

            return new DocumentationBlock(node);
        }
    }
}