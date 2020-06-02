using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainingApp.Tests.Domain
{
    [TestClass]
    public class IsDomainTested : AssemblyTests
    {
        private const string Assembly = "TrainingApp.Domain";

        protected override string Namespace(string name)
        {
            return $"{Assembly}.{name}";
        }

        [TestMethod]
        public void IsCommonTested()
        {
            IsAllTested(Assembly, Namespace("Common"));
        }

        [TestMethod]
        public void IsSportsClubTested()
        {
            IsAllTested(Assembly, Namespace("SportsClub"));
        }
    }
}