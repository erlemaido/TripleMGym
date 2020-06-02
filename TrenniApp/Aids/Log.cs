using System;

namespace TrainingApp.Aids {

    public static class Log 
    {
        internal static ILogBook logBook;

        public static void Exception(Exception e) {
            logBook?.WriteEntry(e);
        }
    }
}
