using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TrainingApp.Facade.Sport
{
    public class TrainingView
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Start time")]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("End time")]
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public string Trainer { get; set; }


    }
}
