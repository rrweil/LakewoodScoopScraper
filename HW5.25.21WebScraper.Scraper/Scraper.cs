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
            foreach (var result in searchResultElements)
            {
                var scoopPost = new ScoopPost();
                scoopPost.Title = result.QuerySelector("h2").TextContent;
                scoopPost.Blurb = result.QuerySelector("p").TextContent.Replace("Read more ›", "");
                scoopPost.NumberOfComments = result.QuerySelector(".backtotop").TextContent;
                scoopPost.URL = result.QuerySelector("a").Attributes["href"].Value;
                var image = result.QuerySelector("img");
                if (image != null)
                {
                    scoopPost.ImageUrl = image.Attributes["src"].Value;
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
