using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace HW5._25._21WebScraper.Scraper
{
    public static class Scraper
    {
        public static List<ScoopPost> ScrapeLakewoodScoop()
        {
            var results = new List<ScoopPost>();
            var html = GetHtml();
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);
            IHtmlCollection<IElement> searchResultElements = document.QuerySelectorAll(".post");
            foreach (IElement result in searchResultElements)
            {
                var title = result.QuerySelector(".post.h2");
                if (title == null)
                {
                    continue;
                }

                var scoopPost = new ScoopPost();
                scoopPost.Title = title.TextContent;

                var priceSpan = result.QuerySelector("span.a-offscreen");
                if (priceSpan != null)
                {
                    //scoopPost.Price = double.Parse(priceSpan.TextContent.Replace("$", String.Empty));
                }

                var imageElement = result.QuerySelector("img.s-image");
                if (imageElement != null)
                {
                    var imageSrcValue = imageElement.Attributes["src"].Value;
                    scoopPost.ImageUrl = imageSrcValue;
                }

                var anchorTag = result.QuerySelector("a.a-link-normal.a-text-normal");
                if (anchorTag != null)
                {
                    //scoopPost.LinkUrl = anchorTag.Attributes["href"].Value;
                }

                results.Add(scoopPost);


            }

            return results;
        }


        private static string GetHtml()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            string url = "https://www.thelakewoodscoop.com/";
            var client = new HttpClient(handler);
            var html = client.GetStringAsync(url).Result;
            return html;
        }
    }
}
