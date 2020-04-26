using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.Data.Trainer;

namespace TrainingApp.Infra.Trainer
{
    public sealed class TrainersRepository : UniqueEntityRepository<Trainer,TrainerData>, ITrainersRepository
    {
        public TrainersRepository(TrainingAppDbContext c) : base(c, c.Trainers) { }

        protected internal override  Trainer toDomainObject(TrainerData d) => new Trainer(d);

    }
}
