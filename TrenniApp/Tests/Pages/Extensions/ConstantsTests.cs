using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Pages.Extensions;

namespace TrainingApp.Tests.Pages.Extensions
{
    [TestClass]
    public class ConstantsTests:BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(Constants);
        }

        [TestMethod] public void CreateNewClientTitleTest()=> Assert.AreEqual("Määramata", Constants.createNewClientTitle);
        [TestMethod] public void CreateNewLinkTitleTest() => Assert.AreEqual("Loo uus", Constants.createNewLinkTitle);
        [TestMethod] public void CreateNewReservationTitleTest() => Assert.AreEqual("Muuda", Constants.createNewReservationTitle);
        [TestMethod] public void DeleteLinkTitleTest() => Assert.AreEqual("Lisainfo", Constants.deleteLinkTitle);
        [TestMethod] public void DetailsLinkTitleTest() => Assert.AreEqual("Kustuta", Constants.detailsLinkTitle);
        [TestMethod] public void EditLinkTitleTest() => Assert.AreEqual("Lisainfo", Constants.editLinkTitle);
        [TestMethod] public void SelectLinkTitleTest() => Assert.AreEqual("Kustuta", Constants.selectLinkTitle);
    }
}
