﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TrainingApp.Pages.Extensions {

    public static class EditControlsForHtmlExtension 
    {

        public static IHtmlContent EditControlsFor<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression) 
        {
            var s = HtmlStrings(htmlHelper, expression);

            return new HtmlContentBuilder(s);
        }
        
        public static IHtmlContent HiddenEditControlsFor<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression) 
        {
            var s = HiddenHtmlStrings(htmlHelper, expression);

            return new HtmlContentBuilder(s);
        }

        internal static List<object> HtmlStrings<TModel, TResult>(IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TResult>> expression) 
        {
            return new List<object> 
            {
                new HtmlString("<div class=\"form-group\">"),
                htmlHelper.LabelFor(expression, new {@class = "text-dark"}),
                htmlHelper.EditorFor(expression,
                    new {htmlAttributes = new {@class = "form-control"}}),
                htmlHelper.ValidationMessageFor(expression, "", new {@class = "text-danger"}),
                new HtmlString("</div>")
            };
        }
        
        internal static List<object> HiddenHtmlStrings<TModel, TResult>(IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TResult>> expression) 
        {
            return new List<object> 
            {
                new HtmlString("<div class=\"form-group\">"),
                htmlHelper.EditorFor(expression,
                    new {htmlAttributes = new {@class = "form-control", @type = "hidden"}}),
                htmlHelper.ValidationMessageFor(expression, "", new {@class = "text-danger"}),
                new HtmlString("</div>")
            };
        }
    }
}
