using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.Common;

namespace TrainingApp.Domain.SportsClub
{
    public sealed class ParticipantOfTraining : Entity<ParticipantOfTrainingData>
    {
        public ParticipantOfTraining() : this(null)
        {

        }

        public ParticipantOfTraining(ParticipantOfTrainingData data) : base(data)
        {

        }
    }
}
