using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;

namespace TrainingApp.Infra.SportsClub
{
    public sealed class TimetableEntriesRepository : PaginatedRepository<TimetableEntry, TimetableEntryData>, ITimetableEntriesRepository
    {
        public TimetableEntriesRepository() : this(null) { }

        public TimetableEntriesRepository(SportsClubDbContext c) : base(c, c?.TimeTableEntries) { }

        protected override async Task<TimetableEntryData> GetData(string timetableId)
        {
            // vaja lisada coachId, trainingId, locationId
            var id = GetString.Head(timetableId);
            var coachId = "";
            var trainingId = "";
            var locationId = "";
            var trainingTypeId = GetString.Tail(timetableId);
            return await DbSet.SingleOrDefaultAsync(x => x.Id == id && x.CoachId == coachId && x.TrainingId == trainingId && x.LocationId == locationId && x.TrainingTypeId == trainingTypeId);
        }

        protected override string GetId(TimetableEntry obj)
        {
            return obj?.Data is null ? string.Empty : $"{obj.Data.Id}.{obj.Data.CoachId}.{obj.Data.TrainingId}.{obj.Data.LocationId}.{obj.Data.TrainingTypeId}.";
        }

        protected internal override TimetableEntry ToDomainObject(TimetableEntryData data) => new TimetableEntry(data);
    }
}
