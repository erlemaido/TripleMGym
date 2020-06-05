using Microsoft.AspNetCore.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids;
using TrainingApp.Facade.SportsClub;
using TrainingApp.Pages.Extensions;

namespace TrainingApp.Tests.Pages.Extensions
{
    [TestClass]
    public class TableHeaderForHtmlExtensionTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(TableHeaderForHtmlExtension);
        }

        [TestMethod]
        public void TableHeaderForTest()
        {
            var obj = new HtmlHelperMock<ClientView>().TableHeaderFor(
                GetRandom.Object<Link>(),
                GetRandom.Object<Link>(),
                GetRandom.Object<Link>(),
                GetRandom.Object<Link>()
            );
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }
    }
}