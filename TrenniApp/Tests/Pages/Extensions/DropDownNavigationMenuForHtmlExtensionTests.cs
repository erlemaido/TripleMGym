using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Facade.SportsClub;
using TrainingApp.Pages.Extensions;

namespace TrainingApp.Tests.Pages.Extensions
{
    [TestClass]
    public class DropDownNavigationMenuForHtmlExtensionTests : BaseTests
    {
        private readonly List<SelectListItem> items = new List<SelectListItem> { new SelectListItem("text", "value") };

        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(DropDownNavigationMenuForHtmlExtension);
        }

        [TestMethod]
        public void DropDownNavigationMenuForTest()
        {
            var obj = new HtmlHelperMock<TrainingCategoryView>().DropDownListFor(x => x.Id, items);
            Assert.IsInstanceOfType(obj, typeof(HtmlContentMock));
        }
    }
}