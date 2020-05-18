﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TrainingApp.Data.Common;
using TrainingApp.Domain.Common;

namespace TrainingApp.Infra
{
    public abstract class PaginatedRepository<TDomain, TData> : FilteredRepository<TDomain, TData>, IPaging
        where TData : PeriodData, new()
        where TDomain : Entity<TData>, new()
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; } = 5;
        public int TotalPages => GetTotalPages(PageSize);
        public bool HasNextPage => PageIndex < TotalPages;
        public bool HasPreviousPage => PageIndex > 1;

        protected PaginatedRepository(DbContext c, DbSet<TData> s) : base(c, s)
        {
        }

        internal int GetTotalPages(in int pageSize)
        {
            var count = GetItemsCount();
            var pages = CountTotalPages(count, pageSize);

            return pages;
        }

        internal int CountTotalPages(int count, in int pageSize) => (int)Math.Ceiling(count / (double)pageSize);

        internal int GetItemsCount() => base.CreateSqlQuery().CountAsync().Result;

        protected internal override IQueryable<TData> CreateSqlQuery() => AddSkipAndTake(base.CreateSqlQuery());

        protected internal IQueryable<TData> AddSkipAndTake(IQueryable<TData> query)
        {
            if (PageIndex < 1) return query;
            return query
                .Skip((PageIndex - 1) * PageSize)
                .Take(PageSize);
        }
    }
}