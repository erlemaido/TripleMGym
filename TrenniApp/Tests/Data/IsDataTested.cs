using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainingApp.Tests.Data
{
    [TestClass]
    public class IsDataTested : AssemblyTests
    {
        private const string assembly = "TrainingApp.Data";

        protected override string Namespace(string name) { return $"{assembly}.{name}"; }

        [TestMethod] public void IsCommonTested() { isAllTested(assembly, Namespace("Common")); }
        [TestMethod] public void IsSportsClubTested() { isAllTested(assembly, Namespace("SportsClub")); }
    }
}
