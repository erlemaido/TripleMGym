using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Facade.SportsClub;
using TrainingApp.Aids;

namespace TrainingApp.Tests.Facade.SportsClub
{
    [TestClass]
    public class TrainingViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(TrainingViewFactory);
        }
        [TestMethod]
        public void CreateTest()
        {
        }
        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<TrainingView>();
            var data = TrainingViewFactory.Create(view).Data;
            testArePropertyValuesEqual(view, data);

        }
        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<TrainingData>();
            var view = TrainingViewFactory.Create(new Training(data));
            testArePropertyValuesEqual(view, data);

        }
    }
}
