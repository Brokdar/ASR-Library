using System.Xml.Linq;
using Xunit;

namespace AsrLibrary.Test.Model.ArElement
{
    public class DefaultElement
    {
        private const string EmptyNode = "<Node></Node>";
        private readonly ASR.Model.ArElement _element;

        public DefaultElement()
        {
            var node = XElement.Parse(EmptyNode);
            _element = ASR.Model.ArElement.FromXElement(node);
        }

        [Fact]
        public void Exists()
        {
            Assert.NotNull(_element);
        }

        [Fact]
        public void IsArObject()
        {
            Assert.IsAssignableFrom<ASR.Model.ArObject>(_element);
        }

        [Fact]
        public void DefaultElementHasNoChecksum()
        {
            Assert.Null(_element.Checksum);
        }

        [Fact]
        public void DefaultElementHasNoTimestamp()
        {
            Assert.Null(_element.TimeStamp);
        }
    }
}