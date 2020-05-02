using System.ComponentModel;

namespace TrainingApp.Aids.Extensions {

    public static class Variable {

        public static string ToString<T>(T v)
            => Methods.Safe.Run(
                () => v?.ToString() ?? string.Empty,
                string.Empty);

        public static T TryParse<T>(string s)
            => Methods.Safe.Run(() => {
                var converter = TypeDescriptor.GetConverter(typeof(T));

                return (T) converter.ConvertFromString(s);
            }, default(T));

    }

}
