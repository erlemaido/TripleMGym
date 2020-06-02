using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainingApp.Tests.Facade
{
    [TestClass]
    public class IsFacadeTested : AssemblyTests
    {
        private const string Assembly = "TrainingApp.Facade";

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

        [TestMethod]
        public void IsTested()
        {
            IsAllTested(Assembly, base.Namespace("Facade"));
        }
    }
}
