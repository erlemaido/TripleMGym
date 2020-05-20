using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainingApp.Tests.Facade
{
    [TestClass]
    public class IsFacadeTested : AssemblyTests
    {

        private const string assembly = "TrainingApp.Facade";

        protected override string Namespace(string name)
        {
            return $"{assembly}.{name}";
        }
        [TestMethod] public void IsCommonTested() { isAllTested(assembly, Namespace("Common")); }
        [TestMethod] public void IsSportsClubTested() { isAllTested(assembly, Namespace("SportsClub")); }
        [TestMethod] public void IsTested() { isAllTested(assembly, base.Namespace("Facade")); }

    }
}
