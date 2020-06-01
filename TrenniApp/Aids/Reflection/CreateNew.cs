using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TrainingApp.Aids.Reflection {

    public static class CreateNew {
        public static T Instance<T>() {
            static T F() {
                var t = typeof(T);
                var o = Instance(t);
                return (T) o;
            }
            var def = default(T);
            return Methods.Safe.Run(F, def);
        }

        public static object Instance(Type t) {
            return Methods.Safe.Run(() => {
                var constructor = GetConstructorInfo(t);
                var parameters = constructor.GetParameters();
                var values = SetRandomParameters(parameters);
                return Invoke(constructor, values);
            }, null);
        }

        private static object Invoke(ConstructorInfo ci, object[] values) {
            return values.Length == 0 ? ci.Invoke(null) : ci.Invoke(values);
        }

        private static object[] SetRandomParameters(IEnumerable<ParameterInfo> parameters) {
            return parameters.Select(p => p.ParameterType).Select(t => Random.GetRandom.Value(t)).ToArray();
        }

        private static ConstructorInfo GetConstructorInfo(Type t) {
            var constructors = t.GetConstructors();
            return constructors.Length == 0 ? null : constructors[0];
        }
    }
}
