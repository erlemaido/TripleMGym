using Abc.Aids.Methods;
using Abc.Aids.Random;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Data.SportsClub;

namespace TrainingApp.Tests.Aids.Methods {

    [TestClass] public class CopyTests : BaseTests {

        [TestInitialize] public void TestInitialize() {
            type = typeof(Copy);
        }

        [TestMethod] public void MembersTest() {
            var x = GetRandom.Object<TrainingData>();
            /*var y = GetRandom.Object<TrainingView>();
            Copy.Members(x, y);
            testArePropertyValuesEqual(x,y);*/
        }

    }

}
