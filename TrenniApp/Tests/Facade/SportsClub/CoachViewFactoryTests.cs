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
    public class CoachViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(CoachViewFactory);
        }
        [TestMethod]
        public void CreateTest()
        {
        }
        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<CoachView>();
            var data = CoachViewFactory.Create(view).Data;
            testArePropertyValuesEqual(view, data);

        }
        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<CoachData>();
            var view = CoachViewFactory.Create(new Coach(data));
            testArePropertyValuesEqual(view, data);

        }
    }
}
