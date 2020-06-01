using System.Reflection;

namespace TrainingApp.Aids.Classes {

    public static class PublicFlagsFor {
        private const BindingFlags P = BindingFlags.Public;
        private const BindingFlags I = BindingFlags.Instance;
        private const BindingFlags S = BindingFlags.Static;
        private const BindingFlags D = BindingFlags.DeclaredOnly;
        public const BindingFlags all = P | I | S;
        public const BindingFlags instance = P | I;
        public const BindingFlags @static = P | S;
        public const BindingFlags declared = P | D | I | S;
    }

}
