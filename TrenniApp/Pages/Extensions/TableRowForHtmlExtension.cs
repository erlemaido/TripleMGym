﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TrainingApp.Pages.Extensions
{
    public static class TableRowForHtmlExtension
    {
        public static IHtmlContent TableRowFor(this IHtmlHelper htmlHelper, string page, object index, 
            string fixedFilter, string fixedValue, params IHtmlContent[] values)
        {
            if (htmlHelper == null) throw new ArgumentNullException(nameof(htmlHelper));
            var s = HtmlStrings(page, index, fixedFilter, fixedValue, values);
            return new HtmlContentBuilder(s);
        }

        private static List<object> HtmlStrings(string page, object index, string fixedFilter, 
            string fixedValue, IEnumerable<IHtmlContent> values)
        {
            var list = new List<object>();
            foreach (var value in values) AddValue(list, value);
            list.Add(new HtmlString("<td>"));
            list.Add(new HtmlString($"<a href=\"{page}/Edit?id={index}&fixedFilter={fixedFilter}&fixedValue={fixedValue}\">{Constants.editLinkTitle}</a>"));
            list.Add(" | ");
            list.Add(new HtmlString($"<a href=\"{page}/Details?id={index}&fixedFilter={fixedFilter}&fixedValue={fixedValue}\">{Constants.detailsLinkTitle}</a>"));
            list.Add(" | ");
            list.Add(new HtmlString($"<a href=\"{page}/Delete?id={index}&fixedFilter={fixedFilter}&fixedValue={fixedValue}\">{Constants.deleteLinkTitle}</a>"));
            list.Add(new HtmlString("</td>"));

            return list;
        }

        public static IHtmlContent TableRowWithSelectFor(this IHtmlHelper htmlHelper, string page, object index,
            string sortOrder, string searchString, int pageIndex, string fixedFilter, string fixedValue, params IHtmlContent[] values)
        {
            if (htmlHelper == null) throw new ArgumentNullException(nameof(htmlHelper));
            var s = HtmlStringsWithSelect(page, index, sortOrder, searchString, pageIndex, fixedFilter, fixedValue, values);
            return new HtmlContentBuilder(s);
        }

        private static List<object> HtmlStringsWithSelect(string page, object id, string sortOrder, string searchString, 
            int pageIndex, string fixedFilter, string fixedValue, IEnumerable<IHtmlContent> values)
        {
            var list = new List<object>();
            foreach (var value in values) AddValue(list, value);
            var s = $"?id={id}";
            s += $"&fixedFilter={fixedFilter}";
            s += $"&fixedValue={fixedValue}";
            s += $"&sortOrder={sortOrder}";
            s += $"&searchString={searchString}";
            s += $"&pageIndex={pageIndex}";

            list.Add(new HtmlString("<td>"));
            list.Add(new HtmlString($"<a href=\"{page}/Index{s}\">{Constants.selectLinkTitle}</a>"));
            list.Add(" | ");
            list.Add(new HtmlString($"<a href=\"{page}/Edit{s}\">{Constants.editLinkTitle}</a>"));
            list.Add(" | ");
            list.Add(new HtmlString($"<a href=\"{page}/Details{s}\">{Constants.detailsLinkTitle}</a>"));
            list.Add(" | ");
            list.Add(new HtmlString($"<a href=\"{page}/Delete{s}\">{Constants.deleteLinkTitle}</a>"));
            list.Add(new HtmlString("</td>"));

            return list;
        }

        internal static void AddValue(List<object> htmlStrings, IHtmlContent value)
        {
            if (htmlStrings is null) return;
            if (value is null) return;
            htmlStrings.Add(new HtmlString("<td>"));
            htmlStrings.Add(value);
            htmlStrings.Add(new HtmlString("</td>"));
        }
    }
}
