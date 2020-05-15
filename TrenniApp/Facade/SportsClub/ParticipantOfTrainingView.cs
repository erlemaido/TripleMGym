using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TrainingApp.Facade.Common;

namespace TrainingApp.Facade.SportsClub
{
    public sealed class ParticipantOfTrainingView : UniqueEntityView
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
    }
}
