using System;
using TrainingApp.Data.Common;

namespace TrainingApp.Data.Sport
{
    public sealed class TrainingData : NamedEntityData
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Type { get; set; } //kas era või rühma
        public string Code { get; set; }
        public string Location { get; set; }
        public string Trainer { get; set; }
    }
}
