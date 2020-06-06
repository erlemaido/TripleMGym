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

        [TestMethod] public void createNewClientTitleTest() => Assert.AreEqual("Ei ole veel liige? Liitu klubiga", Constants.createNewClientTitle);
        [TestMethod] public void createNewLinkTitleTest() => Assert.AreEqual("Loo uus", Constants.createNewLinkTitle);
        [TestMethod] public void createNewReservationTitleTest() => Assert.AreEqual("BRONEERI OMALE TREENING", Constants.createNewReservationTitle);
        [TestMethod] public void deleteLinkTitleTest() => Assert.AreEqual("Kustuta", Constants.deleteLinkTitle);
        [TestMethod] public void detailsLinkTitleTest() => Assert.AreEqual("Detailid", Constants.detailsLinkTitle);
        [TestMethod] public void editLinkTitleTest() => Assert.AreEqual("Muuda", Constants.editLinkTitle);
        [TestMethod] public void selectLinkTitleTest() => Assert.AreEqual("Vali", Constants.selectLinkTitle);
    }
}
