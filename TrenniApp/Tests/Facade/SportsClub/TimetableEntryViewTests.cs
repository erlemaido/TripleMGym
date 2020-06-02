using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Facade.Common;
using TrainingApp.Facade.SportsClub;

namespace TrainingApp.Tests.Facade.SportsClub
{
    public class TimetableEntryViewTests : SealedClassTests<TimetableEntryView, DefinedEntityView>
    {
        [TestMethod] 
        public void CoachIdTest() => IsNullableProperty(() => obj.CoachId, x => obj.CoachId = x);
        
        [TestMethod] 
        public void TrainingIdTest() => IsNullableProperty(() => obj.TrainingId, x => obj.TrainingId = x);
        
        [TestMethod] 
        public void LocationIdTest() => IsNullableProperty(() => obj.LocationId, x => obj.LocationId = x);
        
        [TestMethod] 
        public void TrainingTypeIdTest() => IsNullableProperty(() => obj.TrainingTypeId, x => obj.TrainingTypeId = x);
        
        [TestMethod] 
        public void TrainingLevelTest() => IsProperty(() => obj.TrainingLevel, x => obj.TrainingLevel = x);
        
        [TestMethod] 
        public void DateTest() => IsProperty(() => obj.Date, x => obj.Date = x);
        
        [TestMethod] 
        public void StartTimeTest() => IsProperty(() => obj.StartTime, x => obj.StartTime = x);
        
        [TestMethod] 
        public void EndTimeTest() => IsProperty(() => obj.EndTime, x => obj.EndTime = x);
        
        [TestMethod] 
        public void MaxNumberOfParticipantsTest() => IsProperty(() => obj.MaxNumberOfParticipants, x => obj.MaxNumberOfParticipants = x);
    }
}
