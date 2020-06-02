using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Data.Common;
using TrainingApp.Data.SportsClub;

namespace TrainingApp.Tests.Data.SportsClub
{
    [TestClass]
    public class ClientDataTests : SealedClassTests<ClientData, NamedEntityData>
    {
        [TestMethod]
        public void FirstNameTest()
        {
            IsNullableProperty(() => obj.Name, x => obj.Name = x);
        }

        [TestMethod]
        public void IdCodeTest()
        {
            IsNullableProperty(() => obj.Id, x => obj.Id = x);
        }

        [TestMethod]
        public void EmailTest()
        {
            IsNullableProperty(() => obj.Email, x => obj.Email = x);
        }

        [TestMethod]
        public void DateOfJoiningTest()
        {
            IsProperty(() => obj.DateOfJoining, x => obj.DateOfJoining = x);
        }
    }
}
