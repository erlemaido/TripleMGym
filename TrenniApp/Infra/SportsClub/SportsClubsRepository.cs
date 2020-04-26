using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;

namespace TrainingApp.Infra.SportsClub
{
    public sealed class SportsClubsRepository : UniqueEntityRepository<SportsClub, SportsClubData>,ISportsClubsRepository
    {
        public SportsClubsRepository(TrainingAppDbContext c) : base(c, c.SportsClubs) { }
        protected internal override SportsClub toDomainObject(SportsClubData d) => new SportsClub(d);

    }
}
