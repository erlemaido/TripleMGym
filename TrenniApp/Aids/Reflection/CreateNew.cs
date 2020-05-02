using System;
using System.Collections.Generic;
using System.Reflection;

namespace TrainingApp.Aids.Reflection {


    public static class CreateNew {
        public static T Instance<T>() {
            static T f() {
                var t = typeof(T);
                var o = Instance(t);
                return (T) o;
            }
            var def = default(T);
            return Methods.Safe.Run(f, def);
        }
        public static object Instance(Type t) {
            return Methods.Safe.Run(() => {
                var constructor = getConstructorInfo(t);
                var parameters = constructor.GetParameters();
                var values = setRandomParameters(parameters);
                return invoke(constructor, values);
            }, null);
        }
        private static object invoke(ConstructorInfo ci, object[] values) {
            return values.Length == 0 ? ci.Invoke(null) : ci.Invoke(values);
        }
        private static object[] setRandomParameters(IEnumerable<ParameterInfo> parameters) {
            var values = new List<object>();
            foreach (var p in parameters) {
                var t = p.ParameterType;
                var value = Random.GetRandom.Value(t);
                values.Add(value);
            }
            return values.ToArray();
        }
        private static ConstructorInfo getConstructorInfo(Type t) {
            var constructors = t.GetConstructors();
            return constructors.Length == 0 ? null : constructors[0];
        }
    }
}



