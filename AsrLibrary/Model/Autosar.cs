using System.Collections.Generic;
using System.Xml.Linq;
using ASR.Model.AdministrationData;
using ASR.Model.Documentation;

namespace ASR.Model
{
    public class Autosar
    {
        private readonly List<ArPackage> _packages = new List<ArPackage>();

        public IReadOnlyCollection<ArPackage> Packages => _packages;
        public DocumentationBlock Introduction { get; private set; }
        public AdminData AdminData { get; private set; }

        private Autosar(XContainer node)
        {
            foreach (var element in node.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case "AR-PACKAGES":
                        ExtractPackages(element);
                        break;
                    case "INTRODUCTION":
                        ExtractIntroduction(element);
                        break;
                    case "ADMIN-DATA":
                        ExtractAdminData(element);
                        break;
                }
            }
        }

        private void ExtractPackages(XContainer node)
        {
            foreach (var element in node.Elements())
            {
                var package = ArPackage.FromXElement(element);
                if (package != null)
                    _packages.Add(package);
            }
        }

        private void ExtractIntroduction(XElement node)
        {
            Introduction = DocumentationBlock.FromXElement(node);
        }

        private void ExtractAdminData(XElement node)
        {
            AdminData = AdminData.FromXElement(node);
        }

        public static Autosar Load(string filename)
        {
            var node = XElement.Load(filename);
            return Parse(node);
        }

        public static Autosar Parse(XElement node)
        {
            if (node == null || node.Name.LocalName != "AUTOSAR")
                return null;

            return new Autosar(node);
        }
    }
}