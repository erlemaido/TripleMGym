using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Data.Common;
using TrainingApp.Data.SportsClub;

namespace TrainingApp.Tests.Data.SportsClub
{
    [TestClass]
    public class ClientDataTests : SealedClassTests<ClientData, UniqueEntityData>
    {
        [TestMethod]
        public void FirstNameTest()
        {
            isNullableProperty(() => obj.Name, x => obj.Name = x);
        }

        [TestMethod]
        public void IdCodeTest()
        {
            isNullableProperty(() => obj.IdCode, x => obj.IdCode = x);
        }
        [TestMethod]
        public void EmailTest()
        {
            isNullableProperty(() => obj.Email, x => obj.Email = x);
        }
        [TestMethod]
        public void DateOfJoiningTest()
        {
            isProperty(() => obj.DateOfJoining, x => obj.DateOfJoining = x);
        }
    }
}
