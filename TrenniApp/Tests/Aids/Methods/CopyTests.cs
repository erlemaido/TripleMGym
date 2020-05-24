using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids.Methods;
using TrainingApp.Aids.Random;
using TrainingApp.Data.SportsClub;
using TrainingApp.Tests.Data.SportsClub;

namespace TrainingApp.Tests.Aids.Methods {

    [TestClass] public class CopyTests : BaseTests {

        [TestInitialize] public void TestInitialize() {
            type = typeof(Copy);
        }

        [TestMethod] public void MembersTest() {
            var x = GetRandom.Object<TrainingDataTests>();
            /*var y = GetRandom.Object<TrainingView>();
            Copy.Members(x, y);
            TestArePropertyValuesEqual(x,y);*/
        }

    }

}
