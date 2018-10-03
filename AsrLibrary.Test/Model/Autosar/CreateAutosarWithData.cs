using System.Linq;
using Xunit;

namespace AsrLibrary.Test.Model.Autosar
{
    public class CreateAutosarWithData
    {
        private const string AutosarWithPackages = "../../Model/Autosar/ExampleData/01_Autosar.xml";
        private const string AutosarWithIntroduction = "../../Model/Autosar/ExampleData/02_Autosar.xml";
        private const string AutosarWithAdminData = "../../Model/Autosar/ExampleData/03_Autosar.xml";

        [Fact]
        public void GivenDescriptionWithPackages_ThenAutosarContainsPackages()
        {
            var autosar = ASR.Model.Autosar.Load(AutosarWithPackages);

            Assert.NotEmpty(autosar.Packages);
            Assert.Equal(2, autosar.Packages.Count);
            Assert.Equal("Package1", autosar.Packages.First().ShortName);
            Assert.Equal("Package2", autosar.Packages.Last().ShortName);
        }

        [Fact]
        public void GivenDescriptionWithIntroduction_ThenAutosarContainsIntroduction()
        {
            var autosar = ASR.Model.Autosar.Load(AutosarWithIntroduction);

            Assert.NotNull(autosar.Introduction);
        }

        [Fact]
        public void GivenDescriptionWithAdminData_ThenAutosarContainsAdminData()
        {
            var autosar = ASR.Model.Autosar.Load(AutosarWithAdminData);

            Assert.NotNull(autosar.AdminData);
        }
    }
}