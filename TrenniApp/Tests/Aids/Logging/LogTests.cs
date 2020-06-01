using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainingApp.Aids.Logging;
using TrainingApp.Aids.Random;

namespace TrainingApp.Tests.Aids.Logging {

    [TestClass] public class LogTests : BaseTests {

        internal class TestLogBook : ILogBook {

            public string LoggedMessage { get; private set; }
            public Exception LoggedException { get; private set; }
            public List<Exception> LoggedExceptions { get; } = new List<Exception>();

            public void WriteEntry(string message) {
                LoggedMessage = message;
            }

            public void WriteEntry(Exception e) {
                LoggedException = e;
                LoggedExceptions.Add(e);
            }

        }

        private TestLogBook logBook;

        [TestInitialize] public virtual void TestInitialize() {
            type = typeof(Log);
            logBook = new TestLogBook();
        }

        [TestCleanup] public void TestCleanup() => Log.logBook = null;

        [TestMethod] public void MessageTest() {
            var message = GetRandom.String();
            Log.Message(message);
            Assert.IsNull(logBook.LoggedMessage);
            Log.logBook = logBook;
            Log.Message(message);
            Assert.AreEqual(message, logBook.LoggedMessage);
        }

        [TestMethod] public void ExceptionTest() {
            var exception = new NotImplementedException();
            Log.Exception(exception);
            Assert.IsNull(logBook.LoggedException);
            Log.logBook = logBook;
            Log.Exception(exception);
            Assert.AreEqual(exception, logBook.LoggedException);
        }
    }
}
