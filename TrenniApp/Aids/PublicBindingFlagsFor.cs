using System.Reflection;

namespace TrainingApp.Aids {

    public static class PublicBindingFlagsFor 
    {
        private const BindingFlags P = BindingFlags.Public;
        private const BindingFlags I = BindingFlags.Instance;
        private const BindingFlags S = BindingFlags.Static;
        private const BindingFlags D = BindingFlags.DeclaredOnly;
        public const BindingFlags allMembers = P | I | S;
        public const BindingFlags declaredMembers = P | D | I | S;
    }
}
