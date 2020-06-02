using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids;

namespace TrainingApp.Tests
{
    public class AssemblyTests
    {

        private static string IsNotTested => "<{0}> is not tested";
        private static string NoClassesInAssembly => "No classes found in assembly {0}";
        private static string NoClassesInNamespace => "No classes found in namespace {0}";
        private static string TestAssembly => "TrainingApp.Tests";
        private static string Assembly => "TrainingApp";
        private static char GenericsChar => '`';
        private static char InternalClass => '+';
        private static string DisplayClass => "<>";
        private static string Shell32 => "Shell32.";
        private List<string> list;

        [TestInitialize]
        public void CreateList()
        {
            list = new List<string>();
        }

        protected virtual string Namespace(string name)
        {
            return $"{Assembly}.{name}";
        }

        protected void IsAllTested(string assemblyName, string namespaceName = null)
        {
            var l = GetAssemblyClasses(assemblyName);
            RemoveInterfaces(l);
            list = ToClassNamesList(l);
            RemoveNotInNamespace(namespaceName);
            RemoveSurrogateClasses();
            RemoveTested();

            if (list.Count == 0) return;

            Report(IsNotTested, list[0]);
        }

        private static void Report(string message, params object[] parameters)
        {
            Assert.Fail(message, parameters);
        }

        private static List<Type> GetAssemblyClasses(string assemblyName)
        {
            var l = GetSolution.TypesForAssembly(assemblyName);
            if (l.Count == 0) Report(NoClassesInAssembly, assemblyName);

            return l;
        }

        private static void RemoveInterfaces(IList<Type> types)
        {
            for (var i = types.Count; i > 0; i--)
            {
                var e = types[i - 1];

                if (!e.IsInterface) continue;

                types.Remove(e);
            }
        }

        private static List<string> ToClassNamesList(IEnumerable<Type> l)
        {
            return l.Select(o => o.FullName).ToList();
        }

        private void RemoveNotInNamespace(string namespaceName)
        {
            if (string.IsNullOrEmpty(namespaceName)) return;

            list.RemoveAll(o => !o.StartsWith(namespaceName + '.'));

            if (list.Count > 0) return;

            Report(NoClassesInNamespace, namespaceName);
        }

        private void RemoveSurrogateClasses()
        {
            list.RemoveAll(o => o.Contains(Shell32));
            list.RemoveAll(o => o.Contains(InternalClass));
            list.RemoveAll(o => o.Contains(DisplayClass));
            list.RemoveAll(o => o.Contains("<"));
            list.RemoveAll(o => o.Contains(">"));
            list.RemoveAll(o => o.Contains("Migrations"));
        }

        private void RemoveTested()
        {
            var tests = GetTestClasses();

            for (var i = list.Count; i > 0; i--)
            {
                var className = list[i - 1];
                var testName = ToTestName(className);
                var t = tests.Find(o => o.EndsWith(testName));

                if (ReferenceEquals(null, t)) continue;

                list.RemoveAt(i - 1);
            }
        }

        private static List<string> GetTestClasses()
        {
            var tests = GetSolution.TypeNamesForAssembly(TestAssembly);

            return tests.Select(RemoveGenericsChars).ToList();
        }

        private static string ToTestName(string className)
        {
            className = RemoveAssemblyName(className);
            className = RemoveGenericsChars(className);

            return className + "Tests";
        }

        private static string RemoveGenericsChars(string className)
        {
            var idx = className.IndexOf(GenericsChar);
            if (idx > 0) className = className.Substring(0, idx);

            return className;
        }

        private static string RemoveAssemblyName(string className)
        {
            return className.Substring(Assembly.Length);
        }
    }
}
