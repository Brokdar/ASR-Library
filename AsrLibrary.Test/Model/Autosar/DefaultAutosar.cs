using System.IO;
using System.Xml.Linq;
using Xunit;

namespace AsrLibrary.Test.Model.Autosar
{
    public class DefaultAutosar
    {
        private const string EmptyAutosarNode = "<AUTOSAR></AUTOSAR>";
        private const string EmptyAutosar = "../../Model/Autosar/ExampleData/00_Autosar.xml";

        [Fact]
        public void CreatesFromXElement()
        {
            var node = XElement.Parse(EmptyAutosarNode);

            var autosar = ASR.Model.Autosar.Parse(node);

            Assert.NotNull(autosar);
        }

        [Fact]
        public void CreatesFromFile()
        {
            var autosar = ASR.Model.Autosar.Load(EmptyAutosar);

            Assert.NotNull(autosar);
        }

        [Fact]
        public void GivenInvalidInput_ThenParseReturnsNull()
        {
            var node = XElement.Parse("<ASR></ASR>");

            var autosar = ASR.Model.Autosar.Parse(node);

            Assert.Null(autosar);
        }

        [Fact]
        public void GivenNonExistingFile_ThenLoadThrowsFileNotFoundException()
        {
            Assert.Throws<FileNotFoundException>(() => ASR.Model.Autosar.Load("autosar.xml"));
        }

        [Fact]
        public void HasNoPackages()
        {
            var autosar = ASR.Model.Autosar.Load(EmptyAutosar);

            Assert.Empty(autosar.Packages);
        }

        [Fact]
        public void HasNoDocumentationBlock()
        {
            var autosar = ASR.Model.Autosar.Load(EmptyAutosar);

            Assert.Null(autosar.Introduction);
        }

        [Fact]
        public void HasNoAdminData()
        {
            var autosar = ASR.Model.Autosar.Load(EmptyAutosar);

            Assert.Null(autosar.AdminData);
        }
    }
}