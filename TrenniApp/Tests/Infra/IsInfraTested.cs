using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainingApp.Tests.Infra
{
    [TestClass]
    public class IsInfraTested : AssemblyTests
    {
        private const string Assembly = "TrainingApp.Infra";

        protected override string Namespace(string name) { return $"{Assembly}.{name}"; }

        [TestMethod] public void IsSportsClubTested() { isAllTested(Assembly, Namespace("SportsClub")); }
        [TestMethod] public void IsTested() { isAllTested(base.Namespace("Infra")); }
    }
}
