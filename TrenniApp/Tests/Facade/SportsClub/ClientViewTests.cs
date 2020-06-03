using System.Net.WebSockets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Facade.Common;
using TrainingApp.Facade.SportsClub;

namespace TrainingApp.Tests.Facade.SportsClub
{
    [TestClass]
    public class ClientViewTests : SealedClassTests<ClientView, NamedEntityView>
    {
        [TestMethod] 
        public void EmailTest() => IsNullableProperty(() => obj.Email, x => obj.Email = x);

        [TestMethod] 
        public void DateOfJoiningTest() => IsProperty(() => obj.DateOfJoining, x => obj.DateOfJoining = x);

        [TestMethod]
        public void GetIdTest()
        {
            var actual = obj.GetId();
            var expected = obj.Id;
            Assert.AreEqual(expected, actual);
        }
    }
}
