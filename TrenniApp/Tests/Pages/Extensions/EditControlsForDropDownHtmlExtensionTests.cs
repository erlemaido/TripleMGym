using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Facade.SportsClub;
using TrainingApp.Pages.Extensions;

namespace TrainingApp.Tests.Pages.Extensions
{
    [TestClass]
    public class EditControlsForDropDownHtmlExtensionTests : BaseTests
    {

        private readonly List<SelectListItem> items = new List<SelectListItem> {new SelectListItem("text", "value")};

        [TestInitialize]
        public virtual void TestInitialize() => type = typeof(EditControlsForDropDownHtmlExtension);

        [TestMethod]
        public void EditControlsForDropDownTest()
        {
            var obj = new HtmlHelperMock<ClientView>().EditControlsForDropDown(x => x.Id, items);
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod]
        public void HtmlStringsTest()
        {
            var expected = new List<string> {"<div", "LabelFor", "DropDownListFor", "ValidationMessageFor", "</div>"};
            var actual = EditControlsForDropDownHtmlExtension.HtmlStrings(new HtmlHelperMock<ClientView>(),
                x => x.Id, items);
            TestHtml.Strings(actual, expected);
        }
    }
}