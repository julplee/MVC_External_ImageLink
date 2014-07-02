using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExternalImageLink.RazorHtmlHelpers
{
    public static class HtmlImageHelpers
    {
        public static MvcHtmlString ExternalImageLink(this HtmlHelper htmlHelper, string pictureUrl, string alt, bool isNewTabLink = false, int? width = null, int? height = null)
        {
            string anchorHtml = null;

            if (!string.IsNullOrEmpty(pictureUrl))
            {
                // build the <img> tag
                var imgBuilder = new TagBuilder("img");
                imgBuilder.MergeAttribute("src", pictureUrl);
                if (width != null)
                    imgBuilder.MergeAttribute("width", width.ToString());
                if (height != null)
                    imgBuilder.MergeAttribute("height", height.ToString());
                imgBuilder.MergeAttribute("alt", alt);
                string imgHtml = imgBuilder.ToString(TagRenderMode.SelfClosing);

                // build the <a> tag
                var anchorBuilder = new TagBuilder("a");
                anchorBuilder.MergeAttribute("href", pictureUrl);
                if (isNewTabLink)
                    anchorBuilder.MergeAttribute("target", "_blank");
                anchorBuilder.InnerHtml = imgHtml; // include the <img> tag inside
                anchorHtml = anchorBuilder.ToString(TagRenderMode.Normal);
            }

            return MvcHtmlString.Create(anchorHtml);
        }
    }
}