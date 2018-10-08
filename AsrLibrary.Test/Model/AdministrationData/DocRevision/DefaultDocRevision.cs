using System.Xml.Linq;
using Xunit;

namespace AsrLibrary.Test.Model.AdministrationData.DocRevision
{
    public class DefaultDocRevision
    {
        private const string EmptyNode = "<DOC-REVISION></DOC-REVISION>";

        [Fact]
        public void Exists()
        {
            var node = XElement.Parse(EmptyNode);

            var revision = ASR.Model.AdministrationData.DocRevision.FromXElement(node);

            Assert.NotNull(revision);
        }

        [Fact]
        public void IsArObject()
        {
            var node = XElement.Parse(EmptyNode);

            var revision = ASR.Model.AdministrationData.DocRevision.FromXElement(node);

            Assert.IsAssignableFrom<ASR.Model.ArObject>(revision);
        }

        [Fact]
        public void HasNoDate()
        {
            var node = XElement.Parse(EmptyNode);

            var revision = ASR.Model.AdministrationData.DocRevision.FromXElement(node);

            Assert.Null(revision.Date);
        }

        [Fact]
        public void HasNoIssuedBy()
        {
            var node = XElement.Parse(EmptyNode);

            var revision = ASR.Model.AdministrationData.DocRevision.FromXElement(node);

            Assert.Null(revision.IssuedBy);
        }

        [Fact]
        public void HasNoModifications()
        {
            var node = XElement.Parse(EmptyNode);

            var revision = ASR.Model.AdministrationData.DocRevision.FromXElement(node);

            Assert.Empty(revision.Modifications);
        }

        [Fact]
        public void HasNoRevisionLabel()
        {
            var node = XElement.Parse(EmptyNode);

            var revision = ASR.Model.AdministrationData.DocRevision.FromXElement(node);

            Assert.Null(revision.RevisionLabel);
        }

        [Fact]
        public void HasNoState()
        {
            var node = XElement.Parse(EmptyNode);

            var revision = ASR.Model.AdministrationData.DocRevision.FromXElement(node);

            Assert.Null(revision.State);
        }
    }
}