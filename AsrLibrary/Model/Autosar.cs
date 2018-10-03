using System.Collections.Generic;
using System.Xml.Linq;

namespace ASR.Model
{
    public class Autosar
    {
        private readonly List<ArPackage> _packages = new List<ArPackage>();

        public IReadOnlyCollection<ArPackage> Packages => _packages;

        private Autosar(XElement node)
        {

        }

        public static Autosar Load(string filename)
        {
            return null;
        }

        public static Autosar Parse(string Arxml)
        {
            return null;
        }
    }
}