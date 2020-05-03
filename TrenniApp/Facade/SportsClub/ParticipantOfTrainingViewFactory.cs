using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;

namespace TrainingApp.Facade.SportsClub
{
    public static class ParticipantOfTrainingViewFactory
    {
        public static ParticipantOfTraining Create(ParticipantOfTrainingView v)
        {
            var d = new ParticipantOfTrainingData();
            Copy.Members(v, d);

            return new ParticipantOfTraining(d);
        }

        public static ParticipantOfTrainingView Create(ParticipantOfTraining o)
        {
            var v = new ParticipantOfTrainingView();
            if (!(o?.Data is null))
                Copy.Members(o.Data, v);

            return v;
        }
    }
}
