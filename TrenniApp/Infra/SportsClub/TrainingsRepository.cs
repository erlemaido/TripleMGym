﻿using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;

namespace TrainingApp.Infra.SportsClub
{
    public sealed class TrainingsRepository : UniqueEntityRepository<Training, TrainingData>, ITrainingsRepository
    {
        public TrainingsRepository(SportsClubDbContext c) : base(c, c.Trainings) { }

        protected internal override Training ToDomainObject(TrainingData d) => new Training(d);
    }
}
