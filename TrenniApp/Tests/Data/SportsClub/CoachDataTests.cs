#nullable enable
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Data.Common;
using TrainingApp.Data.SportsClub;

namespace TrainingApp.Tests.Data.SportsClub
{
    [TestClass]
    public class CoachDataTests : SealedClassTests<CoachData, DefinedEntityData>
    {
        [TestMethod]
        public void FirstNameTest()
        {
            IsNullableProperty(() => obj.Name, x => obj.Name = x);
        }

        [TestMethod]
        public void AgeTest()
        {
            IsProperty(() => obj.Age, x => obj.Age = x);
        }

        [TestMethod]
        public void EmailTest()
        {
            IsNullableProperty(() => obj.Email, x => obj.Email = x);
        }

        [TestMethod]
        public void HireDateTest()
        {
            IsProperty(() => obj.HireDate, x => obj.HireDate = x);
        }

        [TestMethod]
        public void CoachCertificateNumberTest()
        {
            IsNullableProperty(() => obj.CoachCertificateNumber, x => obj.CoachCertificateNumber = x);
        }
    }
}
