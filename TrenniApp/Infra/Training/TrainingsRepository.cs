using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.Data.Training;
using TrainingApp.Domain.Training;

namespace TrainingApp.Infra.Training
{
    public sealed class TrainingsRepository : UniqueEntityRepository<TrainingDomain, TrainingData>, ITrainingsRepository
    {
        public TrainingsRepository(TrainingAppDbContext c) : base(c, c.Trainings) { }

        protected internal override TrainingDomain ToDomainObject(TrainingData d) => new TrainingDomain(d);

        public object GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
