using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Data.Common;
using TrainingApp.Data.SportsClub;

namespace TrainingApp.Tests.Data.SportsClub
{
    [TestClass]
    public class ParticipantOfTrainingDataTests : SealedClassTests<ParticipantOfTrainingData, PeriodData>
    {
        [TestMethod]
        public void ClientIdTest()
        {
            IsNullableProperty(() => obj.ClientId, x => obj.ClientId = x);
        }

        [TestMethod]
        public void TimetableEntryIdTest()
        {
            IsNullableProperty(() => obj.TimetableEntryId, x => obj.TimetableEntryId = x);
        }

        [TestMethod]
        public void RegistrationTimeTest()
        {
            IsProperty(() => obj.ValidFrom, x => obj.ValidFrom = x);
        }
    }
}
