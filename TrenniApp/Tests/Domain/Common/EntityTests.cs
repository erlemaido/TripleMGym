using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.Common;

namespace TrainingApp.Tests.Domain.Common
{
    [TestClass]
    public class EntityTests : AbstractClassTests<Entity<TimetableEntryData>, object>
    {
        private class testClass : Entity<TimetableEntryData>
        {

            public testClass(TimetableEntryData d = null) : base(d) { }

        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }

        [TestMethod]
        public void DataTest()
        {
            isReadOnlyProperty(obj, nameof(obj.Data), null);
        }

        [TestMethod]
        public void IsUnspecifiedTest()
        {
            Assert.IsTrue(new testClass().IsUnspecified);
            Assert.IsFalse(new testClass(GetRandom.Object<TimetableEntryData>()).IsUnspecified);
        }

        [TestMethod]
        public void CanSetDataTest()
        {
            var d = GetRandom.Object<TimetableEntryData>();
            obj = new testClass(d);
            Assert.AreNotSame(d, obj.Data);
            arePropertiesEqual(d, obj.Data);
        }

        [TestMethod]
        public void CanSetNullDataTest()
        {
            obj = new testClass();
            Assert.IsNull(obj.Data);
        }

        [TestMethod]
        public void CantChangeDataElementsTest()
        {
            obj = new testClass(GetRandom.Object<TimetableEntryData>());
            var d = obj.Data;
            obj.Data.Id = GetRandom.String();
            obj.Data.Description = GetRandom.String();
            obj.Data.StartTime = GetRandom.DateTime();
            obj.Data.EndTime = GetRandom.DateTime();
            obj.Data.CoachId = GetRandom.String();
            obj.Data.TrainingId = GetRandom.String();
            obj.Data.LocationId = GetRandom.String();
            obj.Data.TrainingTypeId = GetRandom.String();
            //obj.Data.TrainingLevel GetRandomisse ei saa TrainingLevelit lisada
            obj.Data.MaxNumberOfParticipants = GetRandom.Int32();
            arePropertiesEqual(d, obj.Data);
        }
    }
}
