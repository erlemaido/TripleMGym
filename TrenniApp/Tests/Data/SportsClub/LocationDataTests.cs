using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Data.Common;
using TrainingApp.Data.SportsClub;

namespace TrainingApp.Tests.Data.SportsClub
{
    [TestClass]
    public class LocationDataTests : SealedClassTests<LocationData, NamedEntityData>
    {
        [TestMethod]
        public void CodeTest()
        {
            IsNullableProperty(() => obj.Name, x => obj.Name = x);
        }
    }
}
