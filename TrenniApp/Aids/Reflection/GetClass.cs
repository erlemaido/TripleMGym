using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TrainingApp.Aids.Classes;

namespace TrainingApp.Aids.Reflection {

    public static class GetClass {

        private static string G => "get_";
        private static string S => "set_";
        private static string A => "add_";
        private static string R => "remove_";
        private static string C => ".ctor";
        private static string V => "value__";
        private static string T => "+TestClass";

        public static string Namespace(Type type) => type is null ? string.Empty : type.Namespace;

        public static List<MemberInfo> Members(Type type,
            BindingFlags f = PublicFlagsFor.all,
            bool clean = true)
        {
            if (type is null) return new List<MemberInfo>();
            var l = type.GetMembers(f).ToList();
            if (clean) RemoveSurrogates(l);

            return l;
        }

        public static List<PropertyInfo> Properties(Type type,
            BindingFlags f = PublicFlagsFor.all)
            => type?.GetProperties(f).ToList() ?? new List<PropertyInfo>();

        public static PropertyInfo Property<T>(string name)
            => Methods.Safe.Run(() => typeof(T).GetProperty(name), null);


        private static void RemoveSurrogates(IList<MemberInfo> l)
        {
            for (var i = l.Count; i > 0; i--)
            {
                var m = l[i - 1];

                if (!IsSurrogate(m)) continue;
                l.RemoveAt(i - 1);
            }
        }

        private static bool IsSurrogate(MemberInfo m)
        {
            var n = m.Name;

            if (string.IsNullOrEmpty(n)) return false;
            if (n.Contains(G)) return true;
            if (n.Contains(S)) return true;
            if (n.Contains(A)) return true;
            if (n.Contains(R)) return true;
            if (n.Contains(V)) return true;

            return n.Contains(T) || n.Contains(C);
        }
    }
}
