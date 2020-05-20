using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Facade.SportsClub;
using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;

namespace TrainingApp.Tests.Facade.SportsClub
{
    [TestClass]
    public class ClientViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(ClientViewFactory);
        }
        [TestMethod]
        public void CreateTest()
        {
        }
        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<ClientView>();
            var data = ClientViewFactory.Create(view).Data;
            testArePropertyValuesEqual(view, data);

        }
        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<ClientData>();
            var view = ClientViewFactory.Create(new Client(data));
            testArePropertyValuesEqual(view, data);

        }
    }
}
