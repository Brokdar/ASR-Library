using System.Xml.Linq;
using AsrLibrary.Tests.ArObject.TestDouble;
using Xunit;

namespace AsrLibrary.Tests.ArObject
{
    public class DefaultObject
    {
        private const string EmptyNode = "<Node></Node>";
        private readonly ASR.Model.ArObject _object;

        public DefaultObject()
        {
            var node = XElement.Parse(EmptyNode);
            _object = new ArObjectDouble(node);
        }

        [Fact]
        public void IsArObject()
        {
            Assert.IsAssignableFrom<ASR.Model.ArObject>(_object);
        }

        [Fact]
        public void HasNoChecksum()
        {
            Assert.Null(_object.Checksum);
        }

        [Fact]
        public void HasNoTimestamp()
        {
            Assert.Null(_object.TimeStamp);
        }
    }
}