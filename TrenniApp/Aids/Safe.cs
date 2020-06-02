using System;

namespace TrainingApp.Aids {
    public static class Safe 
    {

        private static readonly object Key = new object();

        public static T Run<T>(Func<T> function, T valueOnException, bool useLock = false) 
        {
            return useLock 
                ? LockedRun(function, valueOnException) 
                : Run(function, valueOnException);
        }

        private static T Run<T>(Func<T> function, T valueOnException) 
        {
            try 
            {
                return function(); 
            } catch (Exception e) 
            {
                Log.Exception(e);
                return valueOnException;
            }
        }

        private static T LockedRun<T>(Func<T> function, T valueOnException) 
        {
            lock (Key) { return Run(function, valueOnException); }
        }
    }
}
