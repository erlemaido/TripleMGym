using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainingApp.Tests.Aids {

    [TestClass] public class IsAidsTested : BaseAssemblyTests {

        protected override string assembly => "TrainingApp.Aids";

        protected override string nameSpace(string name) => $"{assembly}.{name}";

        [TestMethod] public void IsLoggingTested()
            => isAllTested(assembly, nameSpace("Logging"));

        [TestMethod] public void IsRandomTested()
            => isAllTested(assembly, nameSpace("Random"));

        [TestMethod] public void IsReflectionTested()
            => isAllTested(assembly, nameSpace("Reflection"));

        [TestMethod] public void IsMethodsTested()
            => isAllTested(assembly, nameSpace("Methods"));


        [TestMethod]
        public void IsClassesTested()
            => isAllTested(assembly, nameSpace("Classes"));
    }
}
