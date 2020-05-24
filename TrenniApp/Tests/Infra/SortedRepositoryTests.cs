using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids;
using TrainingApp.Data.SportsClub;
using TrainingApp.Domain.SportsClub;
using TrainingApp.Infra;
using TrainingApp.Infra.SportsClub;

namespace TrainingApp.Tests.Infra
{
    [TestClass]
    public class SortedRepositoryTests : AbstractClassTests<SortedRepository<Client, ClientData>,
        BaseRepository<Client, ClientData>>
    {
        private class TestClass : SortedRepository<Client, ClientData>
        {
            public TestClass(DbContext c, DbSet<ClientData> s) : base(c, s)
            {
            }

            protected internal override Client ToDomainObject(ClientData d) => new Client(d);

            protected override async Task<ClientData> GetData(string id)
            {
                await Task.CompletedTask;
                return new ClientData();
            }

            protected override string GetId(Client entity) => entity?.Data?.Id;
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var options = new DbContextOptionsBuilder<SportsClubDbContext>().UseInMemoryDatabase("TestDb").Options;
            var c = new SportsClubDbContext(options);
            obj = new TestClass(c, c.Clients);
        }

        [TestMethod]
        public void SortOrderTest()
        {
            isNullableProperty(() => obj.SortOrder, x => obj.SortOrder = x);
        }

        [TestMethod]
        public void DescendingStringTest()
        {
            var propertyName = GetMember.Name<TestClass>(x => x.DescendingString);
            isReadOnlyProperty(obj, propertyName, "_desc");
        }
        [TestMethod]
        public void SetSortingTest()
        {
            void Test(IQueryable<ClientData> d, string sortOrder)
            {
                obj.SortOrder = sortOrder + obj.DescendingString;
                var set = obj.AddSorting(d);
                Assert.IsNotNull(set);
                Assert.AreNotEqual(d, set);
                var str = set.Expression.ToString();
                Assert.IsTrue(str
                    .Contains($"TrainingApp.Data.SportsClub.ClientData]).OrderByDescending(x => Convert(x.{sortOrder}, Object)"));
                obj.SortOrder = sortOrder;
                set = obj.AddSorting(d);
                Assert.IsNotNull(set);
                Assert.AreNotEqual(d, set);
                str = set.Expression.ToString();
                Assert.IsTrue(str.
                    Contains($"TrainingApp.Data.SportsClub.ClientData]).OrderBy(x => Convert(x.{sortOrder}, Object)"));
            }

            Assert.IsNull(obj.AddSorting(null));
            IQueryable<ClientData> data = obj.dbSet;
            obj.SortOrder = null;
            Assert.AreEqual(data, obj.AddSorting(data));
            Test(data, GetMember.Name<ClientData>(x => x.DateOfJoining));
            Test(data, GetMember.Name<ClientData>(x => x.Email));
            Test(data, GetMember.Name<ClientData>(x => x.Id));
        }

        [TestMethod]
        public void CreateExpressionTest()
        {
            string s;
            TestCreateExpression(GetMember.Name<ClientData>(x => x.Id));
            TestCreateExpression(GetMember.Name<ClientData>(x => x.Name));
            TestCreateExpression(GetMember.Name<ClientData>(x => x.DateOfJoining));
            TestCreateExpression(GetMember.Name<ClientData>(x => x.Email));

            TestCreateExpression(s = GetMember.Name<ClientData>(x => x.Id), s + obj.DescendingString);
            TestCreateExpression(s = GetMember.Name<ClientData>(x => x.Name), s + obj.DescendingString);
            TestCreateExpression(s = GetMember.Name<ClientData>(x => x.DateOfJoining), s + obj.DescendingString);
            TestCreateExpression(s = GetMember.Name<ClientData>(x => x.Email), s + obj.DescendingString);
            TestNullExpression(GetRandom.String());
            TestNullExpression(string.Empty);
            TestNullExpression(null);
        }

        private void TestNullExpression(string name)
        {
            obj.SortOrder = name;
            var lambda = obj.CreateExpression();
            Assert.IsNull(lambda);
        }

        private void TestCreateExpression(string expected, string name = null)
        {
            name ??= expected;//kui name on tühi, võta expected
            obj.SortOrder = name;
            var lambda = obj.CreateExpression();
            Assert.IsNotNull(lambda);
            Assert.IsInstanceOfType(lambda, typeof(Expression<Func<ClientData, object>>));
            Assert.IsTrue(lambda.ToString().Contains(expected));
        }

        [TestMethod]
        public void LambdaExpressionTest()
        {
            var name = GetMember.Name<ClientData>(x => x.Email);
            var property = typeof(ClientData).GetProperty(name);
            var lambda = obj.LambdaExpression(property);
            Assert.IsNotNull(lambda);
            Assert.IsInstanceOfType(lambda, typeof(Expression<Func<ClientData, object>>));
            Assert.IsTrue(lambda.ToString().Contains(name));
        }

        [TestMethod]
        public void FindPropertyTest()
        {
            string s;
            void test(PropertyInfo expected, string sortOrder)
            {
                obj.SortOrder = sortOrder;
                Assert.AreEqual(expected, obj.FindProperty());
            }
            test(null, GetRandom.String());
            test(null, null);
            test(null, string.Empty);
            test(typeof(ClientData).GetProperty(s = GetMember.Name<ClientData>(x => x.Name)), s);
            test(typeof(ClientData).GetProperty(s = GetMember.Name<ClientData>(x => x.Id)), s);
            test(typeof(ClientData).GetProperty(s = GetMember.Name<ClientData>(x => x.DateOfJoining)), s);
            test(typeof(ClientData).GetProperty(s = GetMember.Name<ClientData>(x => x.Email)), s);

            test(typeof(ClientData).GetProperty(s = GetMember.Name<ClientData>(x => x.Name)),
                s + obj.DescendingString);
            test(typeof(ClientData).GetProperty(s = GetMember.Name<ClientData>(x => x.Id)),
                s + obj.DescendingString);
            test(typeof(ClientData).GetProperty(s = GetMember.Name<ClientData>(x => x.DateOfJoining)),
                s + obj.DescendingString);
            test(typeof(ClientData).GetProperty(s = GetMember.Name<ClientData>(x => x.Email)),
                s + obj.DescendingString);
        }

        [TestMethod]
        public void GetNameTest()
        {
            string s;
            void test(string expected, string sortOrder)
            {
                obj.SortOrder = sortOrder;
                Assert.AreEqual(expected, obj.GetName());
            }
            test(s = GetRandom.String(), s);
            test(s = GetRandom.String(), s + obj.DescendingString);
            test(string.Empty, string.Empty);
            test(string.Empty, null);
        }
        [TestMethod]
        public void SetOrderByTest()
        {
            void Test(IQueryable<ClientData> d, Expression<Func<ClientData, object>> e, string expected)
            {
                obj.SortOrder = GetRandom.String() + obj.DescendingString;
                var set = obj.AddOrderBy(d, e);
                Assert.IsNotNull(set);
                Assert.AreNotEqual(d, set); 
                Assert.IsTrue(set.Expression.ToString()
                    .Contains($"TrainingApp.Data.SportsClub.ClientData]).OrderByDescending({expected})"));
                obj.SortOrder = GetRandom.String();
                set = obj.AddOrderBy(d, e);
                Assert.IsNotNull(set);
                Assert.AreNotEqual(d, set); 
                Assert.IsTrue(set.Expression.ToString()
                    .Contains($"TrainingApp.Data.SportsClub.ClientData]).OrderBy({expected})"));
            }
            Assert.IsNull(obj.AddOrderBy(null, null));
            IQueryable<ClientData> data = obj.dbSet;
            Assert.AreEqual(data, obj.AddOrderBy(data, null));
            Test(data, x => x.DateOfJoining, "x => x.DateOfJoining");
            Test(data, x => x.Id, "x => x.Id");
            Test(data, x => x.Name, "x => x.Name");
            Test(data, x => x.Email, "x => x.Email");
        }
        [TestMethod]
        public void IsDescendingTest()
        {
            void Test(string sortOrder, bool expected)
            {
                obj.SortOrder = sortOrder;
                var actual = obj.IsDescending();
                Assert.AreEqual(expected, actual);
            }
            Test(GetRandom.String(), false);
            Test(GetRandom.String() + obj.DescendingString, true);
            Test(string.Empty, false);
            Test(null, false);
        }
    }
}
