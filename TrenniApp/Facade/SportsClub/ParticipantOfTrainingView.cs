using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TrainingApp.Facade.Common;

namespace TrainingApp.Facade.SportsClub
{
    public sealed class ParticipantOfTrainingView : NamedEntityView
    {
        [Required]
        [DisplayName("Client")]
        public string ClientId { get; set; }

        [Required]
        [DisplayName("Training")]
        public string TimetableEntryId { get; set; }

        [Required]
        [DisplayName("Registration Time")]
        public DateTime RegistrationTime { get; set; }

        public string GetId()
        {
            return $"{Id}.{ClientId}.{TimetableEntryId}";
        }
    }
}
