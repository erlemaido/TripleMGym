using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Facade.Common;
using TrainingApp.Facade.SportsClub;

namespace TrainingApp.Tests.Facade.SportsClub
{
    [TestClass]
    public class CoachViewTests : SealedClassTests<CoachView, DefinedEntityView>
    {
        [TestMethod] public void AgeTest() => isProperty(() => obj.Age, x => obj.Age = x);

        [TestMethod] public void EmailTest() => isProperty(() => obj.Email, x => obj.Email = x);
        [TestMethod] public void CoachCertificateNumberTest() => isNullableProperty(() => obj.CoachCertificateNumber, x => obj.CoachCertificateNumber = x);
        //ei tea, kummaga testida, kas isnullable või isproperty, mõlemaga läheb läbi, Pihol ID-d isnullableiga.
        [TestMethod] public void HireDateTest() => isProperty(() => obj.HireDate, x => obj.HireDate = x);

    }
    
    
}
