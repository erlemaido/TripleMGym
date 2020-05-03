using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;

namespace TrainingApp.Infra.SportsClub
{
    public sealed class TimeTableEntriesRepository : UniqueEntityRepository<TimetableEntry, TimetableEntryData>, ITimetableEntriesRepository
    {
        public TimeTableEntriesRepository(SportsClubDbContext c) : base(c, c.TimeTableEntries)
        {
        }
        protected internal override TimetableEntry ToDomainObject(TimetableEntryData d) => new TimetableEntry(d);
    }
}
