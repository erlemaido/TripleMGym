using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;

namespace TrainingApp.Facade.SportsClub
{
    public static class TimetableEntryViewFactory
    {
        public static TimetableEntry Create(TimetableEntryView v)
        {
            var d = new TimetableEntryData();
            Copy.Members(v, d);

            return new TimetableEntry(d);
        }

        public static TimetableEntryView Create(TimetableEntry o)
        {
            var v = new TimetableEntryView();
            if (!(o?.Data is null))
                Copy.Members(o.Data, v);

            return v;
        }
    }
}
