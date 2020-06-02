using System;
using System.Text;

namespace TrainingApp.Aids {

    public static class GetRandom 
    {
        private static readonly Random R = new Random();


        public static bool Bool() 
        {
            return Int32() % 2 == 0;
        }

        public static DateTime DateTime(DateTime? minValue = null, DateTime? maxValue = null)
        {
            var min = minValue ?? System.DateTime.MinValue;
            var max = maxValue ?? System.DateTime.MaxValue;
            var d = new DateTime(Int64(min.Ticks, max.Ticks));
            if (d.Hour == 3) d = d.AddHours(UInt8(4, 22));
            return d;
        }

        public static char Char(char min = char.MinValue, char max = char.MaxValue) 
        {
            return (char) UInt16(min, max);
        }

        public static double Double(double min = double.MinValue, double max = double.MaxValue) 
        {
            if (min.CompareTo(max) == 0) return min;
            Sort.Upwards(ref min, ref max);
            var d = R.NextDouble();
            if (max > 0) return min + d * max - d * min;
            return min - d * min + d * max;
        }

        public static int Int32(int min = int.MinValue, int max = int.MaxValue) 
        {
            if (min.CompareTo(max) == 0) return min;
            return min.CompareTo(max) > 0 ? R.Next(max, min) : R.Next(min, max);
        }

        public static long Int64(long min = long.MinValue, long max = long.MaxValue)
        {
            if (min == max) return min;
            return Safe.Run(() =>
                    Convert.ToInt64(Double(Convert.ToDouble(min), Convert.ToDouble(max))),
                min);
        }

        public static string String(byte minLength = 5, byte maxLength = 10) 
        {
            var b = new StringBuilder();
            var size = UInt8(minLength, maxLength);
            for (var i = 0; i < size; i++) b.Append(Char('a', 'z'));
            return b.ToString();
        }

        public static byte UInt8(byte min = byte.MinValue, byte max = byte.MaxValue) 
        {
            return (byte) Int32(min, max);
        }

        public static ushort UInt16(ushort min = ushort.MinValue, ushort max = ushort.MaxValue) 
        {
            return (ushort) Int32(min, max);
        }

        public static uint UInt32(uint min = uint.MinValue, uint max = uint.MaxValue) 
        {
            return Convert.ToUInt32(Double(min, max));
        }

        public static object Value(Type t) 
        {
            var x = Nullable.GetUnderlyingType(t);
            if (!(x is null)) t = x;
            if (t == typeof(string)) return String();
            if (t == typeof(char)) return Char();
            if (t == typeof(bool)) return Bool();
            if (t == typeof(DateTime)) return DateTime();
            if (t == typeof(double)) return Double();
            if (t == typeof(byte)) return UInt8();
            if (t == typeof(ushort)) return UInt16();
            if (t == typeof(uint)) return UInt32();
            if (t == typeof(int)) return Int32();
            if (t == typeof(char?)) return Char();
            if (t == typeof(bool?)) return Bool();
            if (t == typeof(DateTime?)) return DateTime();
            if (t == typeof(double?)) return Double();
            if (t == typeof(byte?)) return UInt8();
            if (t == typeof(ushort?)) return UInt16();
            if (t == typeof(uint?)) return UInt32();
            return t == typeof(int?) ? Int32() : Object(t);
        }

        public static T Object<T>() 
        {
            var o = CreateNew.Instance<T>();
            SetRandom.Values(o);
            return o;
        }

        public static object Object(Type t) 
        {
            var o = CreateNew.Instance(t);
            SetRandom.Values(o);
            return o;
        }
    }
}
