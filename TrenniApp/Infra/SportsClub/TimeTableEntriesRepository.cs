using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;

namespace TrainingApp.Infra.SportsClub
{
    public sealed class TimetableEntriesRepository : UniqueEntityRepository<TimetableEntry, TimetableEntryData>, ITimetableEntriesRepository
    {
        public TimetableEntriesRepository(SportsClubDbContext c) : base(c, c.TimetableEntries) { }
        
        protected internal override TimetableEntry ToDomainObject(TimetableEntryData data) => new TimetableEntry(data);
    }
}
