using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Data.Common;

namespace TrainingApp.Tests.Data.Common
{
    [TestClass]
    public class DefinedEntityDataTests : AbstractClassTests<DefinedEntityData, NamedEntityData>
    {
        private class testClass : DefinedEntityData { }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }

        [TestMethod]
        public void DescriptionTest()
        {
            isNullableProperty(() => obj.Description, x => obj.Description = x);
        }
    }
}