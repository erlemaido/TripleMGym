using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Pages.Extensions;

namespace TrainingApp.Tests.Pages.Extensions
{
    [TestClass]
    public class DropDownNavigationMenuForHtmlExtensionTests : BaseTests
    {
        private string name;
        private Link[] items;

        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(DropDownNavigationMenuForHtmlExtension);
        }

        [TestMethod]
        public void DropDownNavigationMenuForTest()
        {
            Assert.Inconclusive();
        }
    }
}