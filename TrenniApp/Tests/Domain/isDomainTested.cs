using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainingApp.Tests.Domain
{
    [TestClass]
    public class IsDomainTested : AssemblyTests
    {
        private const string assembly = "TrainingApp.Domain";

        protected override string Namespace(string name)
        {
            return $"{assembly}.{name}";
        }

        [TestMethod]
        public void IsCommonTested()
        {
            isAllTested(assembly, Namespace("Common"));
        }

        [TestMethod]
        public void IsSportsClubTested()
        {
            isAllTested(assembly, Namespace("SportsClub"));
        }
    }
}