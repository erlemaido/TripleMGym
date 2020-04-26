using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;

namespace TrainingApp.Infra.SportsClub
{
    public sealed class SportsClubsRepository : UniqueEntityRepository<SportsClubDomain, SportsClubData>,ISportsClubsRepository
    {
        public SportsClubsRepository(TrainingAppDbContext c) : base(c, c.SportsClubs) { }
        protected internal override SportsClubDomain ToDomainObject(SportsClubData d) => new SportsClubDomain(d);

        public object GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
