﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TrainingApp.Data.Common;
using TrainingApp.Domain.Common;

namespace TrainingApp.Infra
{
    public abstract class SortedRepository<TDomain, TData> : BaseRepository<TDomain, TData>, ISorting
        where TData : PeriodData, new()
        where TDomain : Entity<TData>, new()
    {
        public string SortOrder { get; set; }
        public string DescendingString => "_desc";

        protected SortedRepository(DbContext c, DbSet<TData> s) : base(c, s)
        {
        }

        protected internal override IQueryable<TData> CreateSqlQuery()
        {
            var query = base.CreateSqlQuery();
            query = AddSorting(query);

            return query;
        }

        protected internal IQueryable<TData> AddSorting(IQueryable<TData> query)
        {
            var expression = CreateExpression();
            var r = expression is null ? query : AddOrderBy(query, expression);
            return r;
        }

        internal Expression<Func<TData, object>> CreateExpression()
        {
            var property = FindProperty();
            return property is null ? null : LambdaExpression(property);
        }

        internal Expression<Func<TData, object>> LambdaExpression(PropertyInfo p)
        {
            var param = Expression.Parameter(typeof(TData), "x");
            var property = Expression.Property(param, p);
            var body = Expression.Convert(property, typeof(object));
            return Expression.Lambda<Func<TData, object>>(body, param);
        }

        internal PropertyInfo FindProperty()
        {
            var name = GetName();
            return typeof(TData).GetProperty(name);
        }

        internal string GetName()
        {
            if (string.IsNullOrEmpty(SortOrder)) return string.Empty;
            var idx = SortOrder.IndexOf(DescendingString, StringComparison.Ordinal);
            return idx > 0 ? SortOrder.Remove(idx) : SortOrder;
        }

        internal IQueryable<TData> AddOrderBy(IQueryable<TData> query, Expression<Func<TData, object>> e)
        {
            if (query is null) return null;
            if (e is null) return query;
            try
            {
                return IsDescending() ? query.OrderByDescending(e) : query.OrderBy(e);
            }
            catch
            {
                return query;
            }
        }

        internal bool IsDescending() => !string.IsNullOrEmpty(SortOrder) && SortOrder.EndsWith(DescendingString);
    }
}