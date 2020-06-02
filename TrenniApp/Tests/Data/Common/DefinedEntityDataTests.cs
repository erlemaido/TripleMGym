using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Data.Common;

namespace TrainingApp.Tests.Data.Common
{
    [TestClass]
    public class DefinedEntityDataTests : AbstractClassTests<DefinedEntityData, NamedEntityData>
    {
        private class TestClass : DefinedEntityData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass();
        }

        [TestMethod]
        public void DescriptionTest()
        {
            IsNullableProperty(() => obj.Description, x => obj.Description = x);
        }
    }
}