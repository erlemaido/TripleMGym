using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Facade.Common;
using TrainingApp.Facade.SportsClub;

namespace TrainingApp.Tests.Facade.SportsClub
{
    [TestClass]
    public class TrainingViewTests : SealedClassTests<TrainingView, DefinedEntityView>
    {
        [TestMethod] 
        public void CodeTest() => IsNullableProperty(() => obj.Code, x => obj.Code = x);

        [TestMethod] 
        public void DurationInMinutesTest() => IsProperty(() => obj.DurationInMinutes, x => obj.DurationInMinutes = x);
        
        [TestMethod] 
        public void TrainingCategoryIdTest() => IsNullableProperty(() => obj.TrainingCategoryId, x => obj.TrainingCategoryId = x);
        [TestMethod]
        public void GetIdTest()
        {
            var actual = obj.GetId();
            var expected = obj.Id;
            Assert.AreEqual(expected, actual);
        }
    }
}
