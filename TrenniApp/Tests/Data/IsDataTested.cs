using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainingApp.Tests.Data
{
    [TestClass]
    public class IsDataTested : AssemblyTests
    {
        private const string Assembly = "TrainingApp.Data";

        protected override string Namespace(string name) { return $"{Assembly}.{name}"; }

        [TestMethod] public void IsCommonTested() { IsAllTested(Assembly, Namespace("Common")); }
        [TestMethod] public void IsSportsClubTested() { IsAllTested(Assembly, Namespace("SportsClub")); }
    }
}
