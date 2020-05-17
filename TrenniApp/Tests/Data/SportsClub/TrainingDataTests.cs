using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Data.Common;
using TrainingApp.Data.SportsClub;

namespace TrainingApp.Tests.Data.SportsClub
{
    [TestClass]
    public class TrainingDataTests : SealedClassTests<TrainingData, DefinedEntityData>
    {
        [TestMethod]
        public void TrainingCategoryIdTest()
        {
            isNullableProperty(() => obj.TrainingCategoryId, x => obj.TrainingCategoryId = x);
        }
        [TestMethod]
        public void TitleTest()
        {
            isNullableProperty(() => obj.Name, x => obj.Name = x);
        }
        [TestMethod]
        public void CodeTest()
        {
            isNullableProperty(() => obj.Code, x => obj.Code = x);
        }
        [TestMethod]
        public void DurationInMinutesTest()
        {
            isProperty(() => obj.DurationInMinutes, x => obj.DurationInMinutes = x);
        }
    }
}
