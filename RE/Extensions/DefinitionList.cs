    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    public static class DefinitionListExtensions
    {
        public static MvcHtmlString DT(this HtmlHelper htmlHelper, string text, object htmlAttributes = null)
        {
            return BuildDT(text, htmlAttributes);
        }

        public static MvcHtmlString DD(this HtmlHelper htmlHelper, string text, object htmlAttributes = null)
        {
            return BuildDD(text, htmlAttributes);
        }

        public static MvcHtmlString DTAndDD(this HtmlHelper htmlHelper, string label, string text, object htmlAttributesForDT = null, object htmlAttributesForDD = null)
        {
            return MvcHtmlString.Create(BuildDT(label, htmlAttributesForDT).ToString() + BuildDD(text, htmlAttributesForDD).ToString());
        }

        public static MvcHtmlString DTFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            ModelMetadata metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return BuildDT(metaData.GetDisplayName(), htmlAttributes);
        }

        public static MvcHtmlString DDFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            ModelMetadata metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return BuildDD(metaData.SimpleDisplayText, htmlAttributes);
        }

        public static MvcHtmlString DTAndDDFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributesForDT = null, object htmlAttributesForDD = null)
        {
            ModelMetadata metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            return MvcHtmlString.Create(BuildDT(metaData.GetDisplayName(), htmlAttributesForDT).ToString() + BuildDD(metaData.SimpleDisplayText, htmlAttributesForDD));
        }

        public static MvcHtmlString ImageSourceFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributesForDT = null, object htmlAttributesForDD = null, string directoryPath = "")
        {
            ModelMetadata metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var imageText = "<a href=\"/Content/images/" + directoryPath + metaData.SimpleDisplayText + "\" target=\blank\">" +
                            "<img src=\"/Content/images/" + directoryPath + metaData.SimpleDisplayText + "\" width=\"400px\"></a>";
            return MvcHtmlString.Create("/Content/images/" + directoryPath + metaData.SimpleDisplayText);
            return MvcHtmlString.Create(BuildDT(metaData.GetDisplayName(), htmlAttributesForDT).ToString() + BuildDD(imageText, htmlAttributesForDD));
        }

        private static MvcHtmlString BuildDT(string text, object htmlAttributes)
        {
            return BuildTag("dt", text, htmlAttributes);
        }

        private static MvcHtmlString BuildDD(string text, object htmlAttributes)
        {
            return BuildTag("dd", text, htmlAttributes);
        }

        private static MvcHtmlString BuildTag(string tagName, string text, object htmlAttributes)
        {
            var tag = new TagBuilder(tagName);
            tag.SetInnerText(text);
            tag.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            return MvcHtmlString.Create(tag.ToString());
        }
    }