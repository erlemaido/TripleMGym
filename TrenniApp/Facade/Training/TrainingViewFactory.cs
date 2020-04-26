using TrainingApp.Aids;
using TrainingApp.Data.Training;
using TrainingApp.Domain.Common;
using TrainingApp.Domain.Training;

namespace TrainingApp.Facade.Training {

    public static class TrainingViewFactory
    {
        public static TrainingDomain Create(TrainingView view)
        {
            var d = new TrainingData();
            Copy.Members(view, d);
            return new TrainingDomain(d);
        }

        public static TrainingView Create(TrainingDomain obj)
        {
            var v = new TrainingView();
            Copy.Members(obj.Data, v);
            return v;
        }
    }
}