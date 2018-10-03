using System.Xml.Linq;
using AsrLibrary.Tests.ArIdentifiable.TestDouble;
using ASR.Model;
using ASR.Model.Identification;
using Xunit;

namespace AsrLibrary.Tests.ArIdentifiable
{
    public class DefaultIdentifiable
    {
        private const string EmptyNode = "<Node></Node>";
        private readonly Identifiable _identifiable;

        public DefaultIdentifiable()
        {
            var node = XElement.Parse(EmptyNode);
            _identifiable = new ArIdentifiableDouble(node);
        }

        [Fact]
        public void IsArObject()
        {
            Assert.IsAssignableFrom<ASR.Model.ArObject>(_identifiable);
        }

        [Fact]
        public void IsReferable()
        {
            Assert.IsAssignableFrom<IReferable>(_identifiable);
        }

        [Fact]
        public void IsMultiReferable()
        {
            Assert.IsAssignableFrom<IMultiReferable>(_identifiable);
        }

        [Fact]
        public void HasNoShortName()
        {
            Assert.Null(_identifiable.ShortName);
        }

        [Fact]
        public void HasNoLongNames()
        {
            Assert.Empty(_identifiable.LongName);
        }

        [Fact]
        public void HasNoDescription()
        {
            Assert.Empty(_identifiable.Description);
        }

        [Fact]
        public void HasNoCategory()
        {
            Assert.Null(_identifiable.Category);
        }

        [Fact]
        public void HasNoUuid()
        {
            Assert.Null(_identifiable.Uuid);
        }
    }
}