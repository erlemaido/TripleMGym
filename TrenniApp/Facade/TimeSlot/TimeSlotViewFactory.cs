using TrainingApp.Aids;
using TrainingApp.Data.TimeSlot;
using TrainingApp.Domain.Common;
using TrainingApp.Domain.TimeSlot;

namespace TrainingApp.Facade.TimeSlot {

    public static class TimeSlotViewFactory
    {
        public static TimeSlotDomain Create(TimeSlotView view)
        {
            var d = new TimeSlotData();
            Copy.Members(view, d);
            return new TimeSlotDomain(d);
        }

        public static TimeSlotView Create(TimeSlotDomain obj)
        {
            var v = new TimeSlotView();
            Copy.Members(obj.Data, v);
            return v;
        }
    }
}
