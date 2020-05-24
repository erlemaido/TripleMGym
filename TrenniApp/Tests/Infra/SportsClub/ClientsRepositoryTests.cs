using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Infra;
using TrainingApp.Infra.SportsClub;

namespace TrainingApp.Tests.Infra.SportsClub
{
    [TestClass]
    public class ClientsRepositoryTests : RepositoryTests<ClientsRepository, Client, ClientData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<SportsClubDbContext>()
                .UseInMemoryDatabase("TestDb") 
                .Options;
            db = new SportsClubDbContext(options);
            dbSet = ((SportsClubDbContext) db).Clients;
            obj = new ClientsRepository((SportsClubDbContext) db);
            base.TestInitialize();
        }

        protected override Type GetBaseType()
        {
            return typeof(UniqueEntityRepository<Client, ClientData>);
        }

        protected override string GetId(ClientData d) => d.Id;

        protected override Client GetObject(ClientData d) => new Client(d);

        protected override void SetId(ClientData d, string id) => d.Id = id;
    }
}