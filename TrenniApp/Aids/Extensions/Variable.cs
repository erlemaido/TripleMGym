using System.ComponentModel;
using Abc.Aids.Methods;

namespace Abc.Aids.Extensions {

    public static class Variable {

        public static string ToString<T>(T v)
            => Safe.Run(
                () => v?.ToString() ?? string.Empty,
                string.Empty);

        public static T TryParse<T>(string s)
            => Safe.Run(() => {
                var converter = TypeDescriptor.GetConverter(typeof(T));

                return (T) converter.ConvertFromString(s);
            }, default(T));

    }

}
