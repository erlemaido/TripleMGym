﻿using TrainingApp.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainingApp.Tests.Data.Common
{
    [TestClass]
    public class PeriodDataTests : AbstractClassTests<PeriodData, object>
    {
        private class TestClass : PeriodData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new TestClass();
        }

        [TestMethod]
        public void ValidFromTest()
        {
            IsNullableProperty(() => obj.ValidFrom, x => obj.ValidFrom = x);
        }

        [TestMethod]
        public void ValidToTest()
        {
            IsNullableProperty(() => obj.ValidTo, x => obj.ValidTo = x);
        }
    }
}
