using TrainingApp.Aids;
using TrainingApp.Data.Trainer;
using TrainingApp.Domain.Common;
using TrainingApp.Domain.Trainer;

namespace TrainingApp.Facade.Trainer {

    public static class TrainerViewFactory
    {
        public static TrainerDomain Create(TrainerView view)
        {
            var d = new TrainerData();
            Copy.Members(view, d);
            return new TrainerDomain(d);
        }

        public static TrainerView Create(TrainerDomain obj)
        {
            var v = new TrainerView();
            Copy.Members(obj.Data, v);
            return v;
        }
    }
}
