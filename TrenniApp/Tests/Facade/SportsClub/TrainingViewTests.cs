using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Facade.Common;
using TrainingApp.Facade.SportsClub;

namespace TrainingApp.Tests.Facade.SportsClub
{
    [TestClass]
    public class TrainingViewTests : SealedClassTests<TrainingView, DefinedEntityView>
    {
        [TestMethod] public void CodeTest() => isProperty(() => obj.Code, x => obj.Code = x);

        [TestMethod] public void DurationInMinutesTest() => isProperty(() => obj.DurationInMinutes, x => obj.DurationInMinutes = x);
        [TestMethod] public void TrainingCategoryIdTest() => isNullableProperty(() => obj.TrainingCategoryId, x => obj.TrainingCategoryId = x);
        //ei tea, kummaga testida, kas isnullable või isproperty, mõlemaga läheb läbi, Pihol ID-d isnullableiga.
    }
}
