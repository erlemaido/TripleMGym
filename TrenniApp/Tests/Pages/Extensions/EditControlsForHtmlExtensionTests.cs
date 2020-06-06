using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Facade.SportsClub;
using TrainingApp.Pages.Extensions;

namespace TrainingApp.Tests.Pages.Extensions
{
    [TestClass]
    public class EditControlsForHtmlExtensionTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(EditControlsForHtmlExtension);
        }

        [TestMethod]
        public void EditControlsForTest()
        {
            var obj = new HtmlHelperMock<ClientView>().EditControlsFor(x => x.Id);
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod]
        public void HtmlStringsTest()
        {
            var expected = new List<string> { "<div", "LabelFor", "EditorFor", "ValidationMessageFor", "</div>" };
            var actual = EditControlsForHtmlExtension.HtmlStrings(new HtmlHelperMock<ClientView>(), x => x.Name);
            TestHtml.Strings(actual, expected);
        }

        [TestMethod]
        public void HiddenEditControlsForTest()
        {
            var obj = new HtmlHelperMock<ClientView>().HiddenEditControlsFor(x => x.Id);
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }
    }
}
