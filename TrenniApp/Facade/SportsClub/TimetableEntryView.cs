using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TrainingApp.Data.SportsClub;
using TrainingApp.Facade.Common;

namespace TrainingApp.Facade.SportsClub
{
    public sealed class TimetableEntryView : DefinedEntityView
    {
        [Required]
        [DisplayName("Coach")]
        public string CoachId { get; set; }

        [Required]
        [DisplayName("Training")]
        public string TrainingId { get; set; }

        [Required]
        [DisplayName("Location")]
        public string LocationId { get; set; }

        [Required]
        [DisplayName("Type")]
        public string TrainingTypeId { get; set; }

        [Required]
        [DisplayName("Level")]
        public TrainingLevel TrainingLevel { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayName("Start")]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayName("End")]
        public DateTime EndTime { get; set; }

        [Required]
        [DisplayName("Maximum Number of Participants")]
        public int MaxNrOfParticipants { get; set; }

        [Required]
        [DisplayName("Number of Participants")]
        public int NrOfParticipants { get; set; }

        public string GetId()
        {
            return $"{Id}.{CoachId}.{TrainingId}.{LocationId}.{TrainingTypeId}.";
        }
    }
}
