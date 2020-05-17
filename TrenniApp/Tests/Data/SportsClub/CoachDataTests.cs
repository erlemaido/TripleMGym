#nullable enable
using System;
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
            isNullableProperty(() => obj.Name, x => obj.Name = x);
        }

        [TestMethod]
        public void AgeTest()
        {
            isProperty(() => obj.Age, x => obj.Age = x);
        }
        [TestMethod]
        public void EmailTest()
        {
            isNullableProperty(() => obj.Email, x => obj.Email = x);
        }
        [TestMethod]
        public void HireDateTest()
        {
            isProperty(() => obj.HireDate, x => obj.HireDate = x);
        }
        [TestMethod]
        public void CoachCertificateNumberTest()
        {
            isNullableProperty(() => obj.CoachCertificateNumber, x => obj.CoachCertificateNumber = x);
        }
    }
}
