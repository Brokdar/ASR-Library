using System.Xml.Linq;

namespace ASR.Model.AdministrationData
{
    public class AdminData
    {
        private AdminData(XElement node)
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