using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Downloaders
{
    class Gelbooru
    {
        //global variables
        public static List<string> seedUrls = new List<string>();
        public static List<string> pageUrls = new List<string>();
        public static List<string> singlePageUrls = new List<string>();
        public static List<string> imageUrls = new List<string>();
        public static string downloadDirectory = "E:/pictures/Danbooru/test/";
        
        public static bool validateUrlSyntax(string url)
        {
            if(!url.ToLower().Contains("gelbooru.com"))
            {
                return false;
            }
            return true;
        }

        public static void getIndividualPageUrls(string url)
        {
            WebClient client = new WebClient();
            List<string> imagePageURLs = new List<string>();
            if (url.Length > 0)
            {

                HtmlAgilityPack.HtmlDocument htmldoc = new HtmlAgilityPack.HtmlDocument();
                htmldoc.LoadHtml(Encoding.UTF8.GetString(client.DownloadData(url)));
                var aTags = htmldoc.DocumentNode.SelectNodes("//a");
                if (aTags != null)
                {
                    foreach (var aTag in aTags)
                    {
                        if (aTag.InnerHtml.Contains("img"))
                            singlePageUrls.Add("http://gelbooru.com/" + aTag.Attributes["href"].Value.ToString().Replace("amp;", ""));
                    }
                }
            }
        }

        public static void getImageUrlsFromPage(string url)
        {
            WebClient client = new WebClient();
            List<string> imagePageURLs = new List<string>();
            if (url.Length > 0)
            {

                HtmlAgilityPack.HtmlDocument htmldoc = new HtmlAgilityPack.HtmlDocument();
                htmldoc.LoadHtml(Encoding.UTF8.GetString(client.DownloadData(url)));
                var aTags = htmldoc.DocumentNode.SelectNodes("//img");
                if (aTags != null)
                {
                    foreach (var aTag in aTags)
                    {
                        if (aTag.Attributes["src"].Value.Contains("image") || aTag.Attributes["src"].Value.Contains("thumbnail"))
                            imageUrls.Add(convertThumbToImage(aTag.Attributes["src"].Value.ToString().Replace("amp;", "")));
                    }
                }
            }
        }

        private static string convertThumbToImage(string url)
        {
            return url.Replace("thumbnail_", "").Replace("thumbnail", "image");
        }

        public static bool downloadImage(string imageUrl)
        {
            try
            {
                using (WebClient downloadClient = new WebClient())
                {
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile(new Uri(imageUrl), downloadDirectory + imageUrl.Split('?')[0].Split('/').Last().ToString());
                }
            }
            catch (Exception e) { return false; }
            return true;
            
        }
    }
}
