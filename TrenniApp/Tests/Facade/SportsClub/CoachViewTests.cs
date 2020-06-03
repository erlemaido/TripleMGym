using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Facade.Common;
using TrainingApp.Facade.SportsClub;

namespace TrainingApp.Tests.Facade.SportsClub
{
    [TestClass]
    public class CoachViewTests : SealedClassTests<CoachView, DefinedEntityView>
    {
        [TestMethod] 
        public void AgeTest() => IsProperty(() => obj.Age, x => obj.Age = x);

        [TestMethod] 
        public void EmailTest() => IsNullableProperty(() => obj.Email, x => obj.Email = x);
        
        [TestMethod] 
        public void CoachCertificateNumberTest() => IsNullableProperty(() => obj.CoachCertificateNumber, x => obj.CoachCertificateNumber = x);

        [TestMethod] 
        public void HireDateTest() => IsProperty(() => obj.HireDate, x => obj.HireDate = x);
        [TestMethod]
        public void GetIdTest()
        {
            var actual = obj.GetId();
            var expected = obj.Id;
            Assert.AreEqual(expected, actual);
        }
    }
}
