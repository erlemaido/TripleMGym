﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TrainingApp.Pages.Extensions {

    public static class DropDownNavigationMenuForHtmlExtension 
    {

        internal static void AddDropDownMenuItem(List<object> htmlStrings, Link item) 
        {
            if (htmlStrings is null) return;
            if (item is null) return;
            var s = $"<a class='dropdown-item text-dark' href=\"{item.Url}\">{item.DisplayName}</a>";
            htmlStrings.Add(new HtmlString(s));
        }

        internal static void BeginDropDownNavigationMenu(List<object> htmlStrings, string name) 
        {
            if (htmlStrings is null) return;
            htmlStrings.Add(new HtmlString("<li class=\"nav-item dropdown\">"));
            htmlStrings.Add(new HtmlString(
                "<a class=\"nav-link text-dark dropdown-toggle\" href=\"#\" id=\"navbardrop\" data-toggle=\"dropdown\">"));
            htmlStrings.Add(new HtmlString(name));
            htmlStrings.Add(new HtmlString("</a>"));
            htmlStrings.Add(new HtmlString("<div class=\"dropdown-menu\">"));
        }

        internal static void EndDropDownNavigationMenu(List<object> htmlStrings) 
        {
            if (htmlStrings is null) return;
            htmlStrings.Add(new HtmlString("</div>"));
            htmlStrings.Add(new HtmlString("</li>"));
        }

        public static IHtmlContent DropDownNavigationMenuFor(this IHtmlHelper helper, string name, params Link[] items) 
        {
            if (helper == null) throw new ArgumentNullException(nameof(helper));
            var strings = HtmlStrings(name, items);

            return new HtmlContentBuilder(strings);
        }

        internal static List<object> HtmlStrings(string name, params Link[] items) 
        {
            var list = new List<object>();
            BeginDropDownNavigationMenu(list, name);
            foreach (var item in items) AddDropDownMenuItem(list, item);
            EndDropDownNavigationMenu(list);

            return list;
        }
    }
}
