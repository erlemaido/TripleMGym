using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Data.Common;
using TrainingApp.Data.SportsClub;

namespace TrainingApp.Tests.Data.SportsClub
{
    [TestClass]
    public class TimetableEntryDataTests : SealedClassTests<TimetableEntryData, DefinedEntityData>
    {
        [TestMethod]
        public void CoachIdTest()
        {
            isNullableProperty(() => obj.CoachId, x => obj.CoachId = x);
        }
        [TestMethod]
        public void TrainingIdTest()
        {
            isNullableProperty(() => obj.TrainingId, x => obj.TrainingId = x);
        }
        [TestMethod]
        public void LocationIdTest()
        {
            isNullableProperty(() => obj.LocationId, x => obj.LocationId = x);
        }
        [TestMethod]
        public void TrainingTypeIdTest()
        {
            isNullableProperty(() => obj.TrainingTypeId, x => obj.TrainingTypeId = x);
        }
        [TestMethod]
        public void TrainingLevelTest()
        {
            isNullableProperty(() => obj.TrainingLevel, x => obj.TrainingLevel = x);
        }
        [TestMethod]
        public void StartTimeTest()
        {
            isProperty(() => obj.StartTime, x => obj.StartTime = x);
        }
        [TestMethod]
        public void EndTimeTest()
        {
            isProperty(() => obj.EndTime, x => obj.EndTime = x);
        }
        [TestMethod]
        public void DateTest()
        {
            isProperty(() => obj.Date, x => obj.Date = x);
        }
        [TestMethod]
        public void MaxNumberOfParticipantsTest()
        {
            isProperty(() => obj.MaxNumberOfParticipants, x => obj.MaxNumberOfParticipants = x);
        }
    }
}
