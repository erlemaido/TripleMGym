using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TrainingApp.Aids {
    public static class GetClass {

        public static List<PropertyInfo> Properties(Type type,
            BindingFlags f = PublicBindingFlagsFor.allMembers) {
            return type?.GetProperties(f).ToList() ?? new List<PropertyInfo>();
        }

        public static PropertyInfo Property<T>(string name) {
            return Safe.Run(() => typeof(T).GetProperty(name), null);
        }
    }
}
