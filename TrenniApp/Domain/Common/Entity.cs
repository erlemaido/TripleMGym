using TrainingApp.Data.Common;
using TrainingApp.Data.SportsClub;

namespace TrainingApp.Domain.Common
{
    public abstract class Entity<TData> : BaseEntity, IEntity<TData> where TData : UniqueEntityData, new()
    {
        protected internal Entity(TData d = null) => Data = d;
        public TData Data { get; internal set; }
        public bool IsUnspecified => data is null;
        protected readonly TData data;
        //public virtual DateTime StartTime => Data?.StartTime ?? DateTime.MinValue;
        //public virtual DateTime EndTime => Data?.EndTime ?? DateTime.MaxValue;
    }
}
