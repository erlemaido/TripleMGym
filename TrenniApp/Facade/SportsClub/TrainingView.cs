using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TrainingApp.Facade.Common;

namespace TrainingApp.Facade.SportsClub
{
    public sealed class TrainingView : DefinedEntityView
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        [DisplayName("Duration in Minutes")]
        public int DurationInMinutes { get; set; }

        [Required]
        [DisplayName("Training Category")]
        public string TrainingCategoryId { get; set; }
    }
}
