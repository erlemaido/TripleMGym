﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Facade.Common;
using TrainingApp.Facade.SportsClub;

namespace TrainingApp.Tests.Facade.SportsClub
{
    [TestClass]
    public class LocationViewTests : SealedClassTests<LocationView, NamedEntityView>
    {
        [TestMethod]
        public void GetIdTest()
        {
            var actual = obj.GetId();
            var expected = obj.Id;
            Assert.AreEqual(expected, actual);
        }
    }
}
