using TrainingApp.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainingApp.Tests.Facade.Common
{
    [TestClass]
    public class NamedEntityViewTests : AbstractClassTests<NamedEntityView, UniqueEntityView>
    {
        private class TestClass : NamedEntityView { }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass();
        }
        [TestMethod]
        public void NameTest()
        {
            isNullableProperty(() => obj.Name, x => obj.Name = x);
        }
        
    }
}