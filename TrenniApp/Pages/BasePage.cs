using System;
using System.Linq.Expressions;
using TrainingApp.Aids;
using TrainingApp.Domain.Common;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace TrainingApp.Pages {

    public abstract class BasePage<TRepository, TDomain, TView, TData> :
        PageModel
        where TRepository : ICrudMethods<TDomain>, ISorting, IFiltering, IPaging {

        protected TRepository db;

        protected internal BasePage(TRepository r) => db = r;

        public string SortOrder {
            get => db.SortOrder;
            set => db.SortOrder = value;
        }
        public string SearchString {
            get => db.SearchString;
            set => db.SearchString = value;
        }
        public string FixedValue {
            get => db.FixedValue;
            set => db.FixedValue = value;
        }
        public string FixedFilter {
            get => db.FixedFilter;
            set => db.FixedFilter = value;
        }

        protected internal void SetFixedFilter(string fixedFilter, string fixedValue) {
            FixedFilter = fixedFilter;
            FixedValue = fixedValue;
        }

        protected internal abstract void SetPageValues(string sortOrder, string searchString, in int pageIndex);

        public string GetSortString(Expression<Func<TData, object>> e, string page) {
            var name = GetMember.Name(e);
            var sortOrder = GetSortOrder(name);

            return $"{page}?sortOrder={sortOrder}&currentFilter={SearchString}"
                   + $"&fixedFilter={FixedFilter}&fixedValue={FixedValue}";
        }

        internal string GetSortOrder(string name) {
            if (string.IsNullOrEmpty(SortOrder)) return name;
            if (!SortOrder.StartsWith(name)) return name;
            if (SortOrder.EndsWith("_desc")) return name;

            return name + "_desc";
        }

        internal static string GetSearchString(string currentFilter, string searchString, ref int? pageIndex) {
            if (searchString != null) { pageIndex = 1; }
            else { searchString = currentFilter; }

            return searchString;

        }

    }

}
