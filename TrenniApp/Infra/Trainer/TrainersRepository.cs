using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.Data.Trainer;
using TrainingApp.Domain.Trainer;

namespace TrainingApp.Infra.Trainer
{
    public sealed class TrainersRepository : UniqueEntityRepository<TrainerDomain,TrainerData>, ITrainersRepository
    {
        public TrainersRepository(TrainingAppDbContext c) : base(c, c.Trainers) { }

        protected internal override  TrainerDomain ToDomainObject(TrainerData d) => new TrainerDomain(d);

        public object GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
