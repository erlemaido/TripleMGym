using Microsoft.VisualBasic.CompilerServices;
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
            IsNullableProperty(() => obj.CoachId, x => obj.CoachId = x);
        }

        [TestMethod]
        public void TrainingIdTest()
        {
            IsNullableProperty(() => obj.TrainingId, x => obj.TrainingId = x);
        }

        [TestMethod]
        public void LocationIdTest()
        {
            IsNullableProperty(() => obj.LocationId, x => obj.LocationId = x);
        }

        [TestMethod]
        public void TrainingTypeIdTest()
        {
            IsNullableProperty(() => obj.TrainingTypeId, x => obj.TrainingTypeId = x);
        }

        [TestMethod]
        public void TrainingLevelTest()
        {
            IsEnumProperty(obj, nameof(obj.TrainingLevel), typeof(TrainingLevel));
        }

        [TestMethod]
        public void StartTimeTest()
        {
            IsProperty(() => obj.StartTime, x => obj.StartTime = x);
        }

        [TestMethod]
        public void EndTimeTest()
        {
            IsProperty(() => obj.EndTime, x => obj.EndTime = x);
        }

        [TestMethod]
        public void DateTest()
        {
            IsProperty(() => obj.Date, x => obj.Date = x);
        }

        [TestMethod]
        public void MaxNumberOfParticipantsTest()
        {
            IsProperty(() => obj.MaxNumberOfParticipants, x => obj.MaxNumberOfParticipants = x);
        }
    }
}
