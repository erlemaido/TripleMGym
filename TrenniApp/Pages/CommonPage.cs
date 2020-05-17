using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingApp.Data.Common;
using TrainingApp.Domain.Common;

namespace TrainingApp.Pages {

    public abstract class CommonPage<TRepository, TDomain, TView, TData> :
        PaginatedPage<TRepository, TDomain, TView, TData>
        where TRepository : ICrudMethods<TDomain>, ISorting, IFiltering, IPaging {

        protected internal CommonPage(TRepository r) : base(r) { }

        public abstract string ItemId { get; }

        public string PageTitle { get; set; }

        public string PageSubTitle => GetPageSubTitle();

        protected internal virtual string GetPageSubTitle() => string.Empty;

        public string PageUrl => GetPageUrl();

        protected internal abstract string GetPageUrl();

        public string IndexUrl => GetIndexUrl();

        protected internal string GetIndexUrl() => $"{PageUrl}/Index?fixedFilter={FixedFilter}&fixedValue={FixedValue}";

        public string GetNameFromId(string id, IEnumerable<SelectListItem> list)
        {
            foreach (var m in list)
                if (m.Value == id)
                    return m.Text;
            return "Unspecified";
        }

        //protected static IEnumerable<SelectListItem> CreateSelectList<TTDomain, TTData>(IRepository<TTDomain> r)
        //    // TTData algselt pärineb Gunnaril namedEntity Datas. Kuna aga meil kõik klassid ei oma Name, siis tekib problee ja hetkel pandud lihtsalt unique, sest ID kõikidel olemas
        //    // aga sellega peab midagi ette võtma
        //    where TTDomain : Entity<TTData>, new()
        //{
        //    var items = r.Get().GetAwaiter().GetResult();

        //    return items.Select(m => new SelectListItem(m.Data.Id, m.Data.Id)).ToList();
        //}
    }

}
