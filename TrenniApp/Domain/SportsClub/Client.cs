using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.Common;

namespace TrainingApp.Domain.SportsClub
{
    public sealed class Client : Entity<ClientData>
    {
        public Client() : this(null)
        {

        }

        public Client(ClientData data) : base(data)
        {

        }
    }
}
