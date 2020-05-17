using System;
using TrainingApp.Data.Common;

namespace TrainingApp.Data.SportsClub
{
    public sealed class ClientData : NamedEntityData
    {
        public string IdCode { get; set; }
        public string Email { get; set; }
        public DateTime DateOfJoining { get; set; }
    }
}
