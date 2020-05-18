using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TrainingApp.Facade.Common;

namespace TrainingApp.Facade.SportsClub
{
    public sealed class ParticipantOfTrainingView : PeriodView
    {
        [Required]
        [DisplayName("Klient")]
        public string ClientId { get; set; }

        [Required]
        [DisplayName("Treening")]
        public string TimetableEntryId { get; set; }
        
        public string GetId()
        {
            return $"{ClientId}.{TimetableEntryId}";
        }
    }
}
