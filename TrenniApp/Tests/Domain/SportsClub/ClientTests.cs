using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.Common;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Tests;

namespace TrainingApp.Tests.Domain.SportsClub
{ 
    [TestClass]
    public class ClientTests : SealedClassTests<Client, Entity<ClientData>> { }
}
