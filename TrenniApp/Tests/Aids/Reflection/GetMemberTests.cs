using System;
using System.Linq.Expressions;
using Abc.Aids.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainingApp.Tests.Aids.Reflection {

    [TestClass] public class GetMemberTests : BaseTests {

        [TestInitialize] public void TestInitialize() => type = typeof(GetMember);

        /*[TestMethod] public void NameTest() {
            Assert.AreEqual("Data", GetMember.Name<Country>(o => o.Data));
            Assert.AreEqual("Name", GetMember.Name<CountryData>(o => o.Name));
            Assert.AreEqual("NameTest", GetMember.Name<GetMemberTests>(o => o.NameTest()));
            Assert.AreEqual(string.Empty, GetMember.Name((Expression<Func<CountryData, object>>) null));
            Assert.AreEqual(string.Empty, GetMember.Name((Expression<Action<CountryData>>) null));
        }

        [TestMethod] public void DisplayNameTest() {
            Assert.AreEqual("Data", GetMember.DisplayName<Country>(o => o.Data));
            Assert.AreEqual("Valid from",
                GetMember.DisplayName<MeasureView>(o => o.ValidFrom));
            Assert.AreEqual("Name", GetMember.DisplayName<MeasureView>(o => o.Name));
            Assert.AreEqual("Valid to", GetMember.DisplayName<MeasureView>(o => o.ValidTo));
            Assert.AreEqual(string.Empty, GetMember.DisplayName<MeasureView>(null));*/
            //Impossible to use for methods
            //Assert.AreEqual(string.Empty, GetMember.DisplayName<GetMemberTests>(o => o.NameTest()));
        }

    }



