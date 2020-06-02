using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainingApp.Tests.Pages
{
    [TestClass]
    public class IsPagesTested : AssemblyTests
    {
        private const string Assembly = "TrainingApp.Pages";

        protected override string Namespace(string name)
        {
            return $"{Assembly}.{name}";
        }

        [TestMethod]
        public void IsSportsClubTested()
        {
            IsAllTested(Assembly, Namespace("SportsClub"));
        }

        [TestMethod]
        public void IsTested()
        {
            IsAllTested(base.Namespace("Pages"));
        }
    }
}
