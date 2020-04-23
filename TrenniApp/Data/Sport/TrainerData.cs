using TrainingApp.Data.Common;

namespace TrainingApp.Data.Sport

{
    public sealed class TrainerData : DefinedEntityData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }//mis treener ta on
        public ICollection<Training>TrainingAssignme


    }
}
