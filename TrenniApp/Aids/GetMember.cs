﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace TrainingApp.Aids {
    public class GetMember {

        public static string Name<T>(Expression<Func<T, object>> ex) {
            return Safe.Run(()=>Name(ex.Body), string.Empty);
        }

        public static string DisplayName<T>(Expression<Func<T, object>> ex) {
            return Safe.Run(() => {
                var name = Name(ex);
                var p = GetClass.Property<T>(name);
                var list = p?.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                if (list is null || list.Length < 1) return name;
                var a = list.Cast<DisplayNameAttribute>().Single();
                return a?.DisplayName ?? name;
            }, string.Empty);
        }

        private static string Name(Expression ex) {
            var member = ex as MemberExpression;
            var method = ex as MethodCallExpression;
            var operand = ex as UnaryExpression;
            if (!(member is null)) return Name(member);
            if (!(method is null)) return Name(method);
            return !(operand is null) ? Name(operand) : string.Empty;
        }

        private static string Name(MemberExpression ex) { return ex?.Member.Name ?? string.Empty; }

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
