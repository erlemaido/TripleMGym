using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainingApp.Tests
{
    public abstract class AbstractClassTests<TClass, TBaseClass> :BaseClassTests<TClass,TBaseClass>
    {
        [TestMethod]
        public void IsAbstract()
        {
            Assert.IsTrue(type.IsAbstract);
        }
    }
}