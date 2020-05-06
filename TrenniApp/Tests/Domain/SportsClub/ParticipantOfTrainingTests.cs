using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.Common;
using TrainingApp.Domain.SportsClub;

namespace TrainingApp.Tests.Domain.SportsClub
{
    [TestClass]
    public class ParticipantOfTrainingTests : SealedClassTests<ParticipantOfTraining, Entity<ParticipantOfTrainingData>> { }
}
