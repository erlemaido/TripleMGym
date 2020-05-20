using TrainingApp.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainingApp.Tests.Facade.Common
{
    [TestClass]
    public class UniqueEntityViewTests : AbstractClassTests<UniqueEntityView, PeriodView>
    {
        private class TestClass : UniqueEntityView { }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass();
        }
        [TestMethod]
        public void IdTest()
        {
            isNullableProperty(() => obj.Id, x => obj.Id = x);
        }
    }
}