using System;

namespace TrainingApp.Aids.Methods {

    public static class Sort {

        public static void Ascending<T>(ref T min, ref T max) where T : notnull, IComparable {
            if (min.CompareTo(max) <= 0) return;
            var d = min;
            min = max;
            max = d;
        }
    }
}
