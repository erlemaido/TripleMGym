using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.Data.Training;

namespace TrainingApp.Infra.Training
{
    public sealed class TrainingsRepository : UniqueEntityRepository<Training, TrainingData>, ITrainingsRepository
    {
        public TrainingsRepository(TrainingAppDbContext c) : base(c, c.Trainings) { }

        protected internal override Training toDomainObject(TrainingData d) => new Training(d);

    }
}
