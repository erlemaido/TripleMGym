using TrainingApp.Data.Common;
using TrainingApp.Domain.SportsClub;

namespace TrainingApp.Domain.Common
{
    public abstract class Entity<TData> where TData : UniqueEntityData, new()
    {
    protected internal Entity(TData d = null) => Data = d;
    public TData Data { get; internal set; }
    }
}
