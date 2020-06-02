using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Facade.SportsClub;
using TrainingApp.Pages;

namespace TrainingApp.Tests.Pages {

    [TestClass]
    public abstract class AbstractPageTests<TClass, TBaseClass> : AbstractClassTests<TClass, TBaseClass>
        where TClass : BasePage<IClientsRepository, Client, ClientView, ClientData>
    {

        internal TestRepository db;
        internal class TestClass : CommonPage<IClientsRepository, Client, ClientView, ClientData>
        {
            protected internal TestClass(IClientsRepository r) : base(r)
            {
                PageTitle = "Üritused";
            }

            public override string ItemId => Item is null ? string.Empty : Item.GetId();

            protected internal override string GetPageUrl() => "/Client/Clients";

            protected internal override Client ToObject(ClientView view) => ClientViewFactory.Create(view);

            protected internal override ClientView ToView(Client obj) => ClientViewFactory.Create(obj);
        }

        internal class TestRepository : BaseTestRepositoryForUniqueEntity<Client, ClientData>, IClientsRepository { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            db = new TestRepository();
        }
    }
}
