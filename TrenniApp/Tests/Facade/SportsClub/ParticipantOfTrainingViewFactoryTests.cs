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
    public class ParticipantOfTrainingViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(ParticipantOfTrainingViewFactory);
        }
        [TestMethod]
        public void CreateTest()
        {
        }
        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<ParticipantOfTrainingView>();
            var data = ParticipantOfTrainingViewFactory.Create(view).Data;
            TestArePropertyValuesEqual(view, data);

        }
        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<ParticipantOfTrainingData>();
            var view = ParticipantOfTrainingViewFactory.Create(new ParticipantOfTraining(data));
            TestArePropertyValuesEqual(view, data);

        }
    }
}
