using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TrainingApp.Aids.Random {

    public static class GetRandom {

        private static readonly System.Random R = new System.Random();

        public static bool Bool() => Int32() % 2 == 0;

        public static char Char(char min = char.MinValue, char max = char.MaxValue)
            => (char) UInt16(min, max);

        public static Color Color()
            => System.Drawing.Color.FromArgb(UInt8(), UInt8(), UInt8());

        public static DateTime DateTime(DateTime? min = null, DateTime? max = null) {
            var m = min ?? System.DateTime.MinValue;
            var x = max ?? System.DateTime.MaxValue;
            var d = new DateTime(Int64(m.Ticks, x.Ticks));
            if (d.Hour == 3) d = d.AddHours(UInt8(4, 22));

            return d;
        }

        public static decimal Decimal(decimal min = decimal.MinValue,
            decimal max = decimal.MaxValue) {
            if (min == max) return min;

            return Methods.Safe.Run(() =>
                    Convert.ToDecimal(Double(Convert.ToDouble(min), Convert.ToDouble(max))),
                min);
        }

        public static double Double(double min = double.MinValue, double max = double.MaxValue) {
            if (min.CompareTo(max) == 0) return min;
            Methods.Sort.Ascending(ref min, ref max);
            var d = R.NextDouble();

            if (max > 0) return min + d * max - d * min;

            return min - d * min + d * max;
        }

        public static float Float(float min = float.MinValue, float max = float.MaxValue)
            => Convert.ToSingle(Double(min, max));

        public static sbyte Int8(sbyte min = sbyte.MinValue, sbyte max = sbyte.MaxValue)
            => (sbyte) Int32(min, max);

        public static short Int16(short min = short.MinValue, short max = short.MaxValue)
            => (short) Int32(min, max);

        public static int Int32(int min = int.MinValue, int max = int.MaxValue) {
            if (min.CompareTo(max) == 0) return min;
            return min.CompareTo(max) > 0 ? R.Next(max, min) : R.Next(min, max);
        }

        public static long Int64(long min = long.MinValue, long max = long.MaxValue) {
            if (min == max) return min;

            return Methods.Safe.Run(() =>
                    Convert.ToInt64(Double(Convert.ToDouble(min), Convert.ToDouble(max))),
                min);
        }

        public static string String(byte minLength = 5, byte maxLength = 10) {
            var b = new StringBuilder();
            var size = UInt8(minLength, maxLength);
            for (var i = 0; i < size; i++) b.Append(Char('a', 'z'));

            return b.ToString();
        }

        public static TimeSpan TimeSpan() => new TimeSpan(Int64());

        public static byte UInt8(byte min = byte.MinValue, byte max = byte.MaxValue)
            => (byte) Int32(min, max);

        public static ushort UInt16(ushort min = ushort.MinValue, ushort max = ushort.MaxValue)
            => (ushort) Int32(min, max);

        public static uint UInt32(uint min = uint.MinValue, uint max = uint.MaxValue)
            => Convert.ToUInt32(Double(min, max));

        public static ulong UInt64(ulong min = ulong.MinValue, ulong max = ulong.MaxValue) {
            if (min == max) return min;

            return Methods.Safe.Run(() =>
                    Convert.ToUInt64(Double(Convert.ToDouble(min), Convert.ToDouble(max))),
                min);
        }

        public static object Value(Type t) {
            var x = Nullable.GetUnderlyingType(t);
            if (!(x is null)) t = x;

            if (t.IsArray) return Array(t.GetElementType());
            if (t == typeof(string)) return String();
            if (t == typeof(char)) return Char();
            if (t == typeof(Color)) return Color();
            if (t == typeof(bool)) return Bool();
            if (t == typeof(DateTime)) return DateTime();
            if (t == typeof(decimal)) return Decimal();
            if (t == typeof(double)) return Double();
            if (t == typeof(float)) return Float();
            if (t == typeof(byte)) return UInt8();
            if (t == typeof(ushort)) return UInt16();
            if (t == typeof(uint)) return UInt32();
            if (t == typeof(ulong)) return UInt64();
            if (t == typeof(sbyte)) return Int8();
            if (t == typeof(short)) return Int16();
            if (t == typeof(int)) return Int32();
            if (t == typeof(long)) return Int64();
            if (t == typeof(TimeSpan)) return TimeSpan();
            if (t == typeof(char?)) return Char();
            if (t == typeof(Color?)) return Color();
            if (t == typeof(bool?)) return Bool();
            if (t == typeof(DateTime?)) return DateTime();
            if (t == typeof(decimal?)) return Decimal();
            if (t == typeof(double?)) return Double();
            if (t == typeof(float?)) return Float();
            if (t == typeof(byte?)) return UInt8();
            if (t == typeof(ushort?)) return UInt16();
            if (t == typeof(uint?)) return UInt32();
            if (t == typeof(ulong?)) return UInt64();
            if (t == typeof(sbyte?)) return Int8();
            if (t == typeof(short?)) return Int16();
            if (t == typeof(int?)) return Int32();
            if (t == typeof(long?)) return Int64();
            return t == typeof(TimeSpan) ? TimeSpan() : Object(t);
        }

        public static object Array(Type t) {
            if (t is null) return null;
            var listType = typeof(List<>);
            var constructedListType = listType.MakeGenericType(t);
            var list = (IList) Activator.CreateInstance(constructedListType);
            for (var i = 0; i < UInt8(3, 10); i++) list.Add(Value(t));
            var array = System.Array.CreateInstance(t, list.Count);
            list.CopyTo(array, 0);

            return array;
        }

        public static object Object(Type t) {
            var o = Reflection.CreateNew.Instance(t);
            SetRandom.Values(o);

            return o;
        }
    }
}
