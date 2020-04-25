using System;
using TrainingApp.Data.Common;

namespace TrainingApp.Data.Sport
{
    public sealed class TrainingData : TitledEntityData
    {
        public TrainingType TrainingType { get; set; }
    }
}
