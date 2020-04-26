using System;
using TrainingApp.Data.Common;

namespace TrainingApp.Domain.Common {

    public abstract class Entity<TData> where TData : UniqueEntityData
    {
        protected internal Entity(TData d = null) => Data = d;
        public TData Data { get; internal set; }
    }

}
