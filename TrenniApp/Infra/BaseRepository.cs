﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainingApp.Data.Common;
using TrainingApp.Domain.Common;

namespace TrainingApp.Infra
{
    public abstract class BaseRepository<TDomain, TData> : ICrudMethods<TDomain>
        where TData : PeriodData, new()
        where TDomain : Entity<TData>, new()
    {
        protected internal DbContext db;
        protected internal DbSet<TData> dbSet;

        protected BaseRepository(DbContext c, DbSet<TData> s)
        {
            db = c;
            dbSet = s;
        }
        public virtual async Task<List<TDomain>> Get()
        {
            var query = CreateSqlQuery();
            var set = await RunSqlQueryAsync(query);

            return ToDomainObjectsList(set);
        }

        internal List<TDomain> ToDomainObjectsList(List<TData> set) => set.Select(ToDomainObject).ToList();

        protected internal abstract TDomain ToDomainObject(TData periodData);

        internal async Task<List<TData>> RunSqlQueryAsync(IQueryable<TData> query) => await query.AsNoTracking().ToListAsync();

        protected internal virtual IQueryable<TData> CreateSqlQuery()
        {
            var query = from s in dbSet select s;

            return query;
        }

        public async Task Add(TDomain obj)
        {
            if (obj?.Data is null) return;
            dbSet.Add(obj.Data);
            await db.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            if (id is null) return;
            var d = await GetData(id);

            if (d is null) return;

            dbSet.Remove(d);
            await db.SaveChangesAsync();
        }

        public async Task<TDomain> Get(string id)
        {
            if (id is null) return new TDomain();
            var d = await GetData(id);
            var obj = ToDomainObject(d);
            return obj;
        }

        protected abstract Task<TData> GetData(string id);

        public async Task Update(TDomain obj)
        {
            if (obj is null) return;
            var v = await GetData(GetId(obj));
            if (v is null) return;
            dbSet.Remove(v);
            dbSet.Add(obj.Data);
            await db.SaveChangesAsync();
        }

        protected abstract string GetId(TDomain entity);
    }
}