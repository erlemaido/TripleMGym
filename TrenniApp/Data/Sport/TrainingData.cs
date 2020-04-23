using System;
using TrainingApp.Data.Common;

namespace TrainingApp.Data.Sport
{
    public sealed class TrainingData : DefinedEntityData
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Type { get; set; } //kas era või rühma
        public string Code { get; set; }
        public string LocationId { get; set; }
        public string TrainerId { get; set; }
    }
}
