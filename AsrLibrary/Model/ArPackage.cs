using System.Collections.Generic;
using System.Xml.Linq;
using ASR.Model.Identification;

namespace ASR.Model
{
    /// <inheritdoc />
    /// <summary>
    /// AUTOSAR package, allowing to create top level packages to structure the contained
    /// ARElements. ARPackages are open sets. This means that in a file based description system
    /// multiple files can be used to partially describe the contents of a package.
    /// </summary>
    public class ArPackage : Identifiable
    {
        private readonly List<ArPackage> _packages = new List<ArPackage>();
        private readonly List<ArElement> _elements = new List<ArElement>();

        /// <summary>
        /// This represents a sub package within an ARPackage, thus allowing for an unlimited
        /// package hierarchy.
        /// </summary>
        public IReadOnlyCollection<ArPackage> Packages => _packages;
        public bool HasPackages => _packages.Count > 0;

        /// <summary>
        /// Elements that are part of this package
        /// </summary>
        public IReadOnlyCollection<ArElement> Elements => _elements;
        public bool HasElements => _elements.Count > 0;

        private ArPackage(XElement node) : base(node)
        {
            ExtractPackagesFrom(node);
            ExtractElementsFrom(node);
        }

        public static ArPackage FromXElement(XElement node)
        {
            if (node == null || node.Name.LocalName != "AR-PACKAGE")
                return null;

            return new ArPackage(node);
        }

        private void ExtractPackagesFrom(XContainer node)
        {
            var packageContainer = node.Element("AR-PACKAGES");
            if (packageContainer == null) return;

            foreach (var e in packageContainer.Elements())
            {
                var package = FromXElement(e);
                if (package != null)
                    _packages.Add(package);
            }
        }

        private void ExtractElementsFrom(XContainer node)
        {
            var elementContainer = node.Element("ELEMENTS");
            if (elementContainer == null) return;

            foreach (var e in elementContainer.Elements())
            {
                var element = ArElement.FromXElement(e);
                if (element != null)
                    _elements.Add(element);
            }
        }
    }
}