using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Data.Common;
using TrainingApp.Data.SportsClub;

namespace TrainingApp.Tests.Data.SportsClub
{
    [TestClass]
    public class ParticipantOfTrainingDataTests : SealedClassTests<ParticipantOfTrainingData, UniqueEntityData>
    {
        [TestMethod]
        public void ClientIdTest()
        {
            isNullableProperty(() => obj.ClientId, x => obj.ClientId = x);
        }
        [TestMethod]
        public void TimetableEntryIdTest()
        {
            isNullableProperty(() => obj.TimetableEntryId, x => obj.TimetableEntryId = x);
        }
        [TestMethod]
        public void CoachIdTest()
        {
            isNullableProperty(() => obj.CoachId, x => obj.CoachId = x);
        }
        [TestMethod]
        public void RegistrationTimeTest()
        {
            isProperty(() => obj.RegistrationTime, x => obj.RegistrationTime = x);
        }
    }
}
