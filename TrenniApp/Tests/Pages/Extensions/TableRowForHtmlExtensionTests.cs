﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids;
using TrainingApp.Facade.SportsClub;
using TrainingApp.Pages.Extensions;

namespace TrainingApp.Tests.Pages.Extensions
{
    [TestClass]
    public class TableRowForHtmlExtensionTests : BaseTests
    {
        private string s;
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(TableRowForHtmlExtension);
            s = GetRandom.String();
        }

        [TestMethod]
        public void TableRowForTest()
        {
            var obj = new HtmlHelperMock<ClientView>().TableRowFor(
                GetRandom.String(),
                new Uri(GetRandom.String(), UriKind.Relative),

                GetRandom.String(),
                GetRandom.String(),
                new HtmlContentMock(GetRandom.String()));

            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod]
        public void TableRowWithSelectForTest()
        {
            var obj = new HtmlHelperMock<ClientView>().TableRowWithSelectFor(
                GetRandom.String(),
                new Uri(GetRandom.String(), UriKind.Relative),
                GetRandom.String(),
                GetRandom.String(),
                GetRandom.Int32(),
                GetRandom.String(),
                GetRandom.String(),
                new HtmlContentMock(GetRandom.String()));

            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod]
        public void AddValueTest()
        {
            var value = new HtmlContentMock(s);
            var l = new List<object>();
            TableRowForHtmlExtension.AddValue(l, value);
            Assert.AreEqual(3, l.Count);
            Assert.AreEqual("<td>", l[0].ToString());
            Assert.AreEqual(s, l[1].ToString());
            Assert.AreEqual("</td>", l[2].ToString());
        }
    }
}