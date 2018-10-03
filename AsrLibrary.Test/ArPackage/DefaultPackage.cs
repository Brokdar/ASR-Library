using System.Xml.Linq;
using Xunit;

namespace AsrLibrary.Test.ArPackage
{
    public class DefaultPackage
    {
        private const string EmptyNode = "<AR-PACKAGE></AR-PACKAGE>";
        private readonly ASR.Model.ArPackage _package;

        public DefaultPackage()
        {
            var node = XElement.Parse(EmptyNode);
            _package = ASR.Model.ArPackage.FromXElement(node);
        }

        [Fact]
        public void Exists()
        {
            Assert.NotNull(_package);
        }

        [Fact]
        public void IsArObject()
        {
            Assert.IsAssignableFrom<ASR.Model.ArObject>(_package);
        }

        [Fact]
        public void HasNoChecksum()
        {
            Assert.Null(_package.Checksum);
        }

        [Fact]
        public void HasNoTimestamp()
        {
            Assert.Null(_package.TimeStamp);
        }

        [Fact]
        public void HasNoPackages()
        {
            Assert.False(_package.HasPackages);
            Assert.Empty(_package.Packages);
        }

        [Fact]
        public void HasNoElements()
        {
            Assert.False(_package.HasElements);
            Assert.Empty(_package.Elements);
        }
    }
}
