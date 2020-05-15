
using System;

namespace TrainingApp.Domain.Common {
    public interface IEntity {
        //DateTime StartTime { get; }
        //DateTime EndTime { get; }

        bool IsUnspecified { get; }
    }
    public interface IEntity<out TData> : IEntity
    {
        TData Data { get; }
    }
}
