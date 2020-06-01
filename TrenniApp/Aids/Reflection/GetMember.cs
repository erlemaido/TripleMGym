using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace TrainingApp.Aids.Reflection {

    public static class GetMember {

        public static string Name<T, TResult>(Expression<Func<T, TResult>> ex) {
            return Methods.Safe.Run(() => Name(ex.Body), string.Empty);
        }

        private static string Name(Expression ex) {
            var member = ex as MemberExpression;
            var method = ex as MethodCallExpression;
            var operand = ex as UnaryExpression;

            if (!(member is null)) return Name(member);
            if (!(method is null)) return Name(method);
            return !(operand is null) ? Name(operand) : string.Empty;
        }

        private static string Name(MemberExpression ex) {
            return ex?.Member.Name ?? string.Empty;
        }

        private static string Name(MethodCallExpression ex) {
            return ex?.Method.Name ?? string.Empty;
        }

        private static string Name(UnaryExpression ex) {
            var member = ex?.Operand as MemberExpression;
            var method = ex?.Operand as MethodCallExpression;

            if (!(member is null)) return Name(member);
            return !(method is null) ? Name(method) : string.Empty;
        }
    }
}
