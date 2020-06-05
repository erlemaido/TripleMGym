using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Facade.SportsClub;
using TrainingApp.Pages.Extensions;

namespace TrainingApp.Tests.Pages.Extensions
{
    [TestClass]
    public class DisplayControlsForHtmlExtensionTests: BaseTests 
    {
        [TestInitialize]
        public virtual void TestInitialize() => type = typeof(DisplayControlsForHtmlExtension ); 

        [TestMethod]
        public void DisplayControlsForTest()
        {
            var obj = new HtmlHelperMock<ClientView>().DisplayControlsFor(x => x.Id);
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod]
        public void HtmlStringsTest()
        {
            var expected = new List<string> { "<dt", "DisplayNameFor", "</dt>", "<dd", "DisplayFor", "</dd>" };
            var actual =
                DisplayControlsForHtmlExtension.HtmlStrings(new HtmlHelperMock<ClientView>(), x => x.Id);
            TestHtml.Strings(actual, expected);
        }
    }
}
