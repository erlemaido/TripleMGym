using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;

namespace TrainingApp.Infra.SportsClub
{
    public sealed class LocationsRepository : UniqueEntityRepository<Location, LocationData>, ILocationsRepository
    {
        public LocationsRepository(SportsClubDbContext c) : base(c, c.Locations)
        {
        }
        protected internal override Location ToDomainObject(LocationData d) => new Location(d);
    }
}
