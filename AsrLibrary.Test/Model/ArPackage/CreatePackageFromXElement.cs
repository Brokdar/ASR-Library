using System.Linq;
using System.Xml.Linq;
using Xunit;

namespace AsrLibrary.Test.Model.ArPackage
{
    public class CreatePackageFromXElement
    {
        private const string EmptyPackage = "../../Model/ArPackage/ExampleData/00_ArPackage.xml";
        private const string PackageWithSubPackages = "../../Model/ArPackage/ExampleData/01_ArPackage.xml";
        private const string PackageWithElements = "../../Model/ArPackage/ExampleData/02_ArPackage.xml";
        private const string NodeWithoutPackage = "../../Model/ArPackage/ExampleData/03_ArPackage.xml";

        [Fact]
        public void GivenNullAsParameter_ThenReturnsNull()
        {
            var package = ASR.Model.ArPackage.FromXElement(null);
            Assert.Null(package);
        }

        [Fact]
        public void GivenWrongXElement_ThenReturnsNull()
        {
            var node = XElement.Load(NodeWithoutPackage);

            var package = ASR.Model.ArPackage.FromXElement(node);

            Assert.Null(package);
        }

        [Fact]
        public void GivenEmptyNode_ThenDefaultPackageGetsReturned()
        {
            var node = XElement.Load(EmptyPackage);

            var package = ASR.Model.ArPackage.FromXElement(node);

            Assert.NotNull(package);
            Assert.False(package.HasElements);
            Assert.Empty(package.Elements);
            Assert.False(package.HasPackages);
            Assert.Empty(package.Packages);
        }

        [Fact]
        public void GivenNodeWithSubPackages_ThenReturnedPackageContainsSubPackages()
        {
            const int packageCount = 2;
            var node = XElement.Load(PackageWithSubPackages);

            var package = ASR.Model.ArPackage.FromXElement(node);

            Assert.NotNull(package);
            Assert.True(package.HasPackages);
            Assert.NotEmpty(package.Packages);
            Assert.Equal(packageCount, package.Packages.Count());
        }

        [Fact]
        public void GivenNodeWithElements_ThenReturnedPackageContainsElements()
        {
            const int elementCount = 3;
            var node = XElement.Load(PackageWithElements);

            var package = ASR.Model.ArPackage.FromXElement(node);

            Assert.NotNull(package);
            Assert.True(package.HasElements);
            Assert.NotEmpty(package.Elements);
            Assert.Equal(elementCount, package.Elements.Count());
        }
    }
}