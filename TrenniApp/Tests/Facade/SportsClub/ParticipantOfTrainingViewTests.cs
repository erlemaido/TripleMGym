using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Facade.Common;
using TrainingApp.Facade.SportsClub;

namespace TrainingApp.Tests.Facade.SportsClub
{
    [TestClass]
    public class ParticipantOfTrainingViewTests : SealedClassTests<ParticipantOfTrainingView, PeriodView>
    {
        [TestMethod] 
        public void ClientIdTest() => IsNullableProperty(() => obj.ClientId, x => obj.ClientId = x);

        [TestMethod] 
        public void TimetableEntryIdTest() => IsProperty(() => obj.TimetableEntryId, x => obj.TimetableEntryId = x);

        [TestMethod]
        public void GetIdTest()
        {
            var actual = obj.GetId();
            var expected = $"{obj.ClientId}.{obj.TimetableEntryId}";
            Assert.AreEqual(expected, actual);
        }
    }
}
