using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Facade.Common;
using TrainingApp.Facade.SportsClub;

namespace TrainingApp.Tests.Facade.SportsClub
{
    [TestClass]
    public class ClientViewTests : SealedClassTests<ClientView, NamedEntityView>
    {
        [TestMethod] public void EmailTest() => isProperty(() => obj.Email, x => obj.Email = x);
        [TestMethod] public void DateOfJoiningTest() => isProperty(() => obj.DateOfJoining, x => obj.DateOfJoining = x);

    }
}
