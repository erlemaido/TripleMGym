using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TrainingApp.Facade.Common;

namespace TrainingApp.Facade.SportsClub
{
    public sealed class TrainingView : DefinedEntityView
    {
        [Required]
        [DisplayName("Kood")]
        public string Code { get; set; }

        [Required]
        [DisplayName("Kestvus minutites")]
        public int DurationInMinutes { get; set; }

        [Required]
        [DisplayName("Kategooria")]
        public string TrainingCategoryId { get; set; }

        public string GetId()
        {
            return Id;
        }
    }
}
