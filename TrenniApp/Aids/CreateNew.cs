using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TrainingApp.Aids {

    public static class CreateNew 
    {
        public static T Instance<T>() 
        {
            static T Function() 
            {
                var type = typeof(T);
                var instance = Instance(type);
                var value = (T) instance;
                return value;
            }

            var def = default(T);
            var result = Safe.Run(Function, def);
            return result;
        }

        public static object Instance(Type t) 
        {
            return Safe.Run(() => {
                var constructor = GetFirstOrDefaultConstructorInfo(t);
                var parameters = constructor.GetParameters();
                var values = SetRandomParameterValues(parameters);
                return InvokeConstructor(constructor, values);
            }, null);
        }

        private static object InvokeConstructor(ConstructorInfo ci, object[] values) 
        {
            return values.Length == 0 ? ci.Invoke(null) : ci.Invoke(values);
        }

        private static object[] SetRandomParameterValues(IEnumerable<ParameterInfo> parameters) 
        {
            return parameters.Select(p => p.ParameterType).Select(t => GetRandom.Value(t)).ToArray();
        }

        private static ConstructorInfo GetFirstOrDefaultConstructorInfo(Type t) {
            var constructors = t.GetConstructors();
            return constructors.Length == 0 ? null : constructors[0];
        }
    }
}
