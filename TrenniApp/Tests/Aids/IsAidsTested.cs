using Abc.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainingApp.Tests.Aids {

    [TestClass] public class IsAidsTested : BaseAssemblyTests {

        protected override string assembly => "Abc.Aids";

        protected override string nameSpace(string name) => $"{assembly}.{name}";

        [TestMethod] public void IsEnumsTested()
            => isAllTested(assembly, nameSpace("Enums"));

        [TestMethod] public void IsConstantsTested()
            => isAllTested(assembly, nameSpace("Constants"));

        [TestMethod] public void IsExtensionsTested()
            => isAllTested(assembly, nameSpace("Extensions"));

        [TestMethod] public void IsLoggingTested()
            => isAllTested(assembly, nameSpace("Logging"));

        [TestMethod] public void IsRandomTested()
            => isAllTested(assembly, nameSpace("Random"));

        [TestMethod] public void IsReflectionTested()
            => isAllTested(assembly, nameSpace("Reflection"));

        [TestMethod] public void IsServicesTested()
            => isAllTested(assembly, nameSpace("Services"));

        [TestMethod] public void IsMethodsTested()
            => isAllTested(assembly, nameSpace("Methods"));

        [TestMethod] public void IsValuesTested()
            => isAllTested(assembly, nameSpace("Values"));

        [TestMethod] public void IsRegionsTested()
            => isAllTested(assembly, nameSpace("Regions"));

        [TestMethod]
        public void IsRegExpTested()
            => isAllTested(assembly, nameSpace("RegExp"));

        [TestMethod]
        public void IsClassesTested()
            => isAllTested(assembly, nameSpace("Classes"));
        [TestMethod]
        public void IsFormatsTested()
            => isAllTested(assembly, nameSpace("Formats"));


    }

}
