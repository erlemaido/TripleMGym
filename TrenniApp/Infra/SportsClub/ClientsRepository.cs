using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;

namespace TrainingApp.Infra.SportsClub
{
    public sealed class ClientsRepository : UniqueEntityRepository<Client, ClientData>, IClientsRepository
    {
        public ClientsRepository(SportsClubDbContext c) : base(c, c.Clients) { }

        protected internal override Client ToDomainObject(ClientData d) => new Client(d);
    }
}
