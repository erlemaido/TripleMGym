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
        [DisplayName("Treener")]
        public string CoachId { get; set; }

        [Required]
        [DisplayName("Treening")]
        public string TrainingId { get; set; }

        [Required]
        [DisplayName("Asukoht")]
        public string LocationId { get; set; }

        [Required]
        [DisplayName("Tüüp")]
        public string TrainingTypeId { get; set; }

        [Required]
        [DisplayName("Tase")]
        public TrainingLevel TrainingLevel { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Kuupäev")]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayName("Algus")]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayName("Lõpp")]
        public DateTime EndTime { get; set; }

        [Required]
        [DisplayName("Maksimaalne osalejate arv")]
        public int MaxNumberOfParticipants { get; set; }

        public string GetId()
        {
            return Id;
        }
    }
}
