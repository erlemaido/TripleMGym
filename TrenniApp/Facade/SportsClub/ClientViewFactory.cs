using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;

namespace TrainingApp.Facade.SportsClub
{
    public static class ClientViewFactory
    {
        public static Client Create(ClientView v)
        {
            var d = new ClientData();
            Copy.Members(v, d);

            return new Client(d);
        }

        public static ClientView Create(Client o)
        {
            var v = new ClientView();
            if (!(o?.Data is null))
                Copy.Members(o.Data, v);

            return v;
        }
    }
}
