using System;
using System.Xml.Linq;
using AsrLibrary.Tests.ArObject.TestDouble;
using Xunit;

namespace AsrLibrary.Tests.ArObject
{
    public class CreateObjectFromXElement
    {
        private const string ObjectInformation = "../../ArObject/ExampleData/00_ArObject.xml";
        private ArObjectDouble _object;

        [Fact]
        public void GivenNodeWithChecksum_ThenReturnedPackageContainsChecksum()
        {
            const string checksum = "955B1611351ACA89B931DACA9B75472AD155089B";
            var node = XElement.Load(ObjectInformation);

            _object = new ArObjectDouble(node);

            Assert.Equal(checksum, _object.Checksum);
        }

        [Fact]
        public void GivenNodeWithTimestamp_ThenReturnedPackageContainsTimestamp()
        {
            const string timestamp = "2018-09-20T13:30:50+01:00";
            var datetime = DateTime.Parse(timestamp);
            var node = XElement.Load(ObjectInformation);

            _object = new ArObjectDouble(node);

            Assert.Equal(datetime, _object.TimeStamp);
        }
    }
}