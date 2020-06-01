using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingApp.Data.Common;
using TrainingApp.Domain.Common;

namespace TrainingApp.Pages
{

    public abstract class CommonPage<TRepository, TDomain, TView, TData> :
        PaginatedPage<TRepository, TDomain, TView, TData>
        where TRepository : ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
    {

        protected internal CommonPage(TRepository r) : base(r) { }

        public abstract string ItemId { get; }

        public string PageTitle { get; set; }

        public string PageSubTitle => GetPageSubTitle();

        protected internal virtual string GetPageSubTitle() => string.Empty;

        public string PageUrl => GetPageUrl();

        protected internal abstract string GetPageUrl(); 

        public string IndexUrl => GetIndexUrl();

        protected internal string GetIndexUrl() => $"{PageUrl}/Index?fixedFilter={FixedFilter}&fixedValue={FixedValue}";

        protected static IEnumerable<SelectListItem> CreateSelectList<TTDomain, TTData>(IRepository<TTDomain> r)
            where TTDomain : Entity<TTData>
            where TTData : NamedEntityData, new()
        {
            var items = r.Get().GetAwaiter().GetResult();

            return items.Select(m => new SelectListItem(m.Data.Name, m.Data.Id)).ToList();
        }
    }
}