﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TrainingApp.Pages.Extensions {

    public static class HypertextLinkForHtmlExtension 
    {

        public static IHtmlContent HypertextLinkFor(this IHtmlHelper htmlHelper, string text, params Link[] items) 
        {
            if (htmlHelper == null) throw new ArgumentNullException(nameof(htmlHelper));
            var s = HtmlStrings(text, items);

            return new HtmlContentBuilder(s);
        }

        internal static List<object> HtmlStrings(string text, Link[] items) 
        {
            var l = new List<object> {
                new HtmlString("<p>"),
                new HtmlString($"<a>{text}</a>")
            };

            l.AddRange(
                items.Select(item => new HtmlString($"<a> </a><a href=\"{item.Url}\">{item.DisplayName}</a>")));

            l.Add(new HtmlString("</p>"));

            return l;
        }
    }
}
