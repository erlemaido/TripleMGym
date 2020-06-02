using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.Common;

namespace TrainingApp.Tests.Domain.Common
{
    [TestClass]
    public class EntityTests : AbstractClassTests<Entity<ClientData>, object>
    {
        private class TestClass : Entity<ClientData>
        {
            public TestClass(ClientData d = null) : base(d)
            {
            }
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass();
        }

        [TestMethod]
        public void DataTest()
        {
            var d = GetRandom.Object<ClientData>();
            Assert.AreNotSame(d, obj.Data);
            obj = new TestClass(d);
            Assert.AreSame(d, obj.Data);
        }

        [TestMethod]
        public void DataIsNullTest()
        {
            var d = GetRandom.Object<ClientData>();
            Assert.IsNull(obj.Data);
            obj.Data = d;
            Assert.AreSame(d, obj.Data);
        }

        [TestMethod]
        public void CanSetNullDataTest()
        {
            obj.Data = null;
            Assert.IsNull(obj.Data);
        }
    }
}
