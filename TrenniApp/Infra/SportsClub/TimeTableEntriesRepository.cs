using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;

namespace TrainingApp.Infra.SportsClub
{
    public sealed class TimetableEntriesRepository : PaginatedRepository<TimetableEntry, TimetableEntryData>, ITimetableEntriesRepository
    {
        public TimetableEntriesRepository() : this(null) { }

        public TimetableEntriesRepository(SportsClubDbContext c) : base(c, c.TimetableEntries) { }

        protected override async Task<TimetableEntryData> GetData(string timetableEntryId)
        {
            return await DbSet.SingleOrDefaultAsync(x => x.Id == timetableEntryId);
        }

        protected override string GetId(TimetableEntry obj)
        {
            return obj?.Data is null ? string.Empty : obj.Data.Id;
        }

        protected internal override TimetableEntry ToDomainObject(TimetableEntryData data) => new TimetableEntry(data);
    }
}
