using TrainingApp.Facade.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainingApp.Tests.Facade.Common
{
    [TestClass]
    public class DefinedEntityViewTests : AbstractClassTests<DefinedEntityView, NamedEntityView>
    {
        private class TestClass : DefinedEntityView { }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass();
        }
        [TestMethod]
        public void DescriptionTest()
        {
            isNullableProperty(()=>obj.Description, x=>obj.Description = x);
        }
    }       
}