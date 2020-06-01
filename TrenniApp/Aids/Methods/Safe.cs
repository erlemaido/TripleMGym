using System;

namespace TrainingApp.Aids.Methods {

    public static class Safe {

        private static readonly object Key = new object();

        public static T Run<T>(Func<T> function, T valueOnException,
            bool useLock = false) {
            return useLock
                ? LockedRun(function, valueOnException)
                : run(function, valueOnException);
        }

        public static void Run(Action action, bool useLock = false) {
            if (useLock) LockedRun(action);
            else run(action);
        }

        private static T run<T>(Func<T> function, T valueOnException) {
            try { return function(); }
            catch (Exception e) {
                Logging.Log.Exception(e);

                return valueOnException;
            }
        }

        private static T LockedRun<T>(Func<T> function, T valueOnException) {
            lock (Key) { return run(function, valueOnException); }
        }

        private static void run(Action action) {
            try { action(); }
            catch (Exception e) { Logging.Log.Exception(e); }
        }

        private static void LockedRun(Action action) {
            lock (Key) { run(action); }
        }
    }
}