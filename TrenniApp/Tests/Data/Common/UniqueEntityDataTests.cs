using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Data.Common;

namespace TrainingApp.Tests.Data.Common
{
    [TestClass]
    public class UniqueEntityDataTests : AbstractClassTests<UniqueEntityData, PeriodData>
    {
        private class testClass : UniqueEntityData { }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }
        [TestMethod]
        public void IdTest()
        {
            isNullableProperty(() => obj.Id, x => obj.Id = x);
        }
    }
}