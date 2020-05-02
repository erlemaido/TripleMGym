﻿using Abc.Aids.Extensions;
using Abc.Aids.Random;
using Abc.Aids.Regions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrainingApp.Tests.Aids.Extensions {

    [TestClass] public class StringsTests : BaseTests {

        private string s1;
        private string s2;

        [TestInitialize] public virtual void TestInitialize() {
            type = typeof(Strings);
            s1 = GetRandom.String();
            s2 = GetRandom.String();
        }

        [TestMethod] public void FormatTest() {
            var i = GetRandom.Int32();
            var d = GetRandom.Double();
            var s = "{0}, {1}";

            var actual = s.Format(i, d);

            var expected = string.Format(UseCulture.Invariant, s, i, d);
            Assert.AreEqual(expected, actual);
            actual = ((string) null).Format();
            Assert.AreEqual(string.Empty, actual);
        }

        [TestMethod] public void IsWordTest() {
            var s = GetRandom.String();
            void test(char c, bool b) => Assert.AreEqual(b, (c + s).IsWord());

            test(GetRandom.Char(max: '@'), false);
            test(GetRandom.Char('A', 'Z'), true);
            test(GetRandom.Char('a', 'z'), true);
            Assert.AreEqual(false, ((string) null).IsWord());
        }

        [TestMethod] public void BackwardsTest() {
            var s = "987654321" + GetRandom.String();
            s = s.Backwards();
            Assert.IsTrue(s.EndsWith("123456789"));
            s = ((string) null).Backwards();
            Assert.AreEqual(string.Empty, s);
        }

        [TestMethod] public void SubstringBeforeTest() {
            var x = GetRandom.String();
            var y = GetRandom.String();
            Assert.AreEqual(x, (x + y).SubstringBefore(y));
            Assert.AreEqual(string.Empty, (x + y).SubstringBefore(x));
            Assert.AreEqual(y, (y + x).SubstringBefore(x));
            Assert.AreEqual(string.Empty, (y + x).SubstringBefore(y));
            Assert.AreEqual(string.Empty, ((string) null).SubstringBefore(y));
            Assert.AreEqual(x + y, (x + y).SubstringBefore(null));
            Assert.AreEqual(string.Empty, ((string) null).SubstringBefore(null));
        }

        [TestMethod] public void ToLowerCaseTest() {
            var s = GetRandom.String();
            var expected = s.ToLower(UseCulture.Invariant);
            var actual = s.ToLowerCase();
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(string.Empty, ((string) null).ToLowerCase());
        }

        [TestMethod] public void RemoveSpacesTest() {
            static string spaces() {
                var c = GetRandom.UInt8();
                var s = string.Empty;
                for (var i = 0; i < c; i++) s += ' ';

                return s;
            }

            var x = GetRandom.String();
            var y = GetRandom.String();
            Assert.AreEqual(x + y, (spaces() + x + spaces() + y + spaces()).RemoveSpaces());
            Assert.AreEqual(string.Empty, ((string) null).RemoveSpaces());
        }

        [TestMethod] public void GetHeadTest() {
            static string str() => GetRandom.String();
            var x = GetRandom.String();
            Assert.AreEqual(x, (x + '.' + str() + '.' + str()).GetHead());
            Assert.AreEqual(string.Empty, ((string) null).GetHead());
        }

        [TestMethod] public void GetTailTest() {
            static string str() => GetRandom.String();
            var x = str() + '.' + str() + '.' + str();
            Assert.AreEqual(x, (str() + '.' + x).GetTail());
            Assert.AreEqual(string.Empty, ((string) null).GetTail());
        }
        [TestMethod]
        public void AddTest()
        {
            Assert.AreEqual(s1 + s2, Strings.Add(s1, s2));
        }

        [TestMethod]
        public void IfNullSetEmptyTest()
        {
            Assert.AreEqual(string.Empty, Strings.IfNullSetEmpty(null));
            var s = GetRandom.String();
            Assert.AreEqual(s, Strings.IfNullSetEmpty(s));
        }

        [TestMethod]
        public void TrimTest()
        {
            Assert.AreEqual(string.Empty, Strings.Trim(null));
            var s = GetRandom.String();
            Assert.AreEqual(s, Strings.Trim("     " + s + "         "));
        }

        [TestMethod]
        public void ContainsTest()
        {
            var s = GetRandom.String();
            Assert.AreEqual(true, Strings.Contains(GetRandom.String() + s + GetRandom.String(), s));
            Assert.AreEqual(false, Strings.Contains(GetRandom.String() + GetRandom.String(), s));
            Assert.AreEqual(false, Strings.Contains(s, null));
            Assert.AreEqual(false, Strings.Contains(null, s));
            Assert.AreEqual(false, Strings.Contains(null, null));
        }

        [TestMethod]
        public void GetLengthTest()
        {
            Assert.AreEqual(0, Strings.GetLength(null));
            Assert.AreEqual(0, Strings.GetLength(string.Empty));
            Assert.AreEqual(3, Strings.GetLength("   "));
            var s = GetRandom.String();
            Assert.AreEqual(s.Length, Strings.GetLength(s));
        }

        [TestMethod]
        public void ToLowerTest()
        {
            Assert.AreEqual("", Strings.ToLower(null));
            Assert.AreEqual("", Strings.ToLower(string.Empty));
            Assert.AreEqual("   ", Strings.ToLower("   "));
            var s = GetRandom.String();
            Assert.AreEqual(s.ToLower(), Strings.ToLower(s.ToUpper()));
        }

        [TestMethod]
        public void ToUpperTest()
        {
            Assert.AreEqual("", Strings.ToUpper(null));
            Assert.AreEqual("", Strings.ToUpper(string.Empty));
            Assert.AreEqual("   ", Strings.ToUpper("   "));
            var s = GetRandom.String();
            Assert.AreEqual(s.ToUpper(), Strings.ToUpper(s.ToLower()));
        }
        [TestMethod]
        public void SubstringTest()
        {
            Assert.AreEqual("", Strings.Substring(null, GetRandom.Int32()));
            Assert.AreEqual("", Strings.Substring("", GetRandom.Int32()));
            var s = GetRandom.String(5, 100);
            var i = GetRandom.Int32(0, s.Length / 2);
            var j = GetRandom.Int32(i, s.Length / 2);
            Assert.AreEqual(s.Substring(i), Strings.Substring(s, i));
            Assert.AreEqual(s.Substring(i, j), Strings.Substring(s, i, j));
        }

        [TestMethod]
        public void EndsWithTest()
        {
            var s = GetRandom.String();
            Assert.AreEqual(true, Strings.EndsWith(GetRandom.String() + s, s));
            Assert.AreEqual(false, Strings.EndsWith(s + GetRandom.String(), s));
            Assert.AreEqual(false, Strings.EndsWith(s, null));
            Assert.AreEqual(false, Strings.EndsWith(null, s));
            Assert.AreEqual(false, Strings.EndsWith(null, null));
        }
        [TestMethod]
        public void StartsWithTest()
        {
            var s = GetRandom.String();
            Assert.AreEqual(false, Strings.StartsWith(GetRandom.String() + s, s));
            Assert.AreEqual(true, Strings.StartsWith(s + GetRandom.String(), s));
            Assert.AreEqual(false, Strings.StartsWith(s, null));
            Assert.AreEqual(false, Strings.StartsWith(null, s));
            Assert.AreEqual(false, Strings.StartsWith(null, null));
        }

    }

}
