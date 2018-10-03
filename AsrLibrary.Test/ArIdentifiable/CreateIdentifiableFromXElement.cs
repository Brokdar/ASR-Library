using System.Linq;
using System.Xml.Linq;
using AsrLibrary.Test.ArIdentifiable.TestDouble;
using Xunit;

namespace AsrLibrary.Test.ArIdentifiable
{
    public class CreateIdentifiableFromXElement
    {
        private const string EmptyIdentifiable = "../../ArIdentifiable/ExampleData/00_ArIdentifiable.xml";
        private const string Identifiable = "../../ArIdentifiable/ExampleData/01_ArIdentifiable.xml";

        [Fact]
        public void GivenEmptyNode_ThenDefaultPackageGetsReturned()
        {
            var node = XElement.Load(EmptyIdentifiable);

            var identifiable = new ArIdentifiableDouble(node);

            Assert.NotNull(identifiable);
            Assert.Null(identifiable.ShortName);
            Assert.Empty(identifiable.LongName);
            Assert.Empty(identifiable.Description);
            Assert.Null(identifiable.Category);
            Assert.Null(identifiable.Uuid);
        }

        [Fact]
        public void GivenIdentifiableWithShortName_ThenReturnedIdentifiableContainsShortName()
        {
            var node = XElement.Load(Identifiable);

            var identifiable = new ArIdentifiableDouble(node);

            Assert.Equal("Name", identifiable.ShortName);
        }

        [Fact]
        public void GivenIdentifiableWithLongName_ThenReturnedIdentifiableContainsLongName()
        {
            var node = XElement.Load(Identifiable);

            var identifiable = new ArIdentifiableDouble(node);
            var longName = identifiable.LongName.First();

            Assert.NotEmpty(identifiable.LongName);
            Assert.Equal(1, identifiable.LongName.Count);
            Assert.NotNull(longName);
            Assert.Equal("FOR-ALL", longName.Language);
            Assert.Equal("GlobalName", longName.Text);
        }

        [Fact]
        public void GivenIdentifiableWithDescription_ThenReturnedIdentifiableContainsDescription()
        {
            var node = XElement.Load(Identifiable);

            var identifiable = new ArIdentifiableDouble(node);
            var deGerman = identifiable.Description.First();
            var enEnglish = identifiable.Description.Last();

            Assert.NotEmpty(identifiable.Description);
            Assert.Equal(2, identifiable.Description.Count);
            Assert.NotNull(deGerman);
            Assert.Equal("DE", deGerman.Language);
            Assert.Equal("German", deGerman.Text);
            Assert.NotNull(enEnglish);
            Assert.Equal("EN", enEnglish.Language);
            Assert.Equal("English", enEnglish.Text);
        }

        [Fact]
        public void GivenIdentifiableWithCategory_ThenReturnedIdentifiableContainsCategory()
        {
            var node = XElement.Load(Identifiable);

            var identifiable = new ArIdentifiableDouble(node);

            Assert.Equal("Category", identifiable.Category);
        }

        [Fact]
        public void GivenIdentifiableWithUuid_ThenReturnedIdentifiableContainsUuid()
        {
            const string uuid = "00112233445566778899AABBCCDDEEFF";
            var node = XElement.Load(Identifiable);

            var identifiable = new ArIdentifiableDouble(node);

            Assert.Equal(uuid, identifiable.Uuid);
        }
    }
}