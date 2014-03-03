using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Downloaders
{
    class Gelbooru
    {
        //global variables
        //seedURL, image url, save directory
        public static List<List<string>> imageData = new List<List<string>>();
        public static List<string> seedUrls = new List<string>();
        public static List<string> pageUrls = new List<string>();
        public static List<string> singlePageUrls = new List<string>();
        public static List<string> imageUrls = new List<string>();
        public static string downloadDirectory = "E:/pictures/Danbooru/test/";
        public static int numberOfPages = 0;
        public static string saveLocation = "";

        public static bool validateUrlSyntax(string url)
        {
            if(!url.ToLower().Contains("gelbooru.com"))
            {
                return false;
            }
            return true;
        }

        public static List<string> getIndividualPageUrls(string url)
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
                        {
                            imagePageURLs.Add("http://gelbooru.com/" + aTag.Attributes["href"].Value.ToString().Replace("amp;", ""));
                        }
                    }
                }
            }
            return imagePageURLs;
        }

        public static List<string> getImageUrlsFromPage(string url)
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
                        {
                            imagePageURLs.Add(convertThumbToImage(aTag.Attributes["src"].Value.ToString().Replace("amp;", "")));
                        }
                    }
                }
            }
            return imagePageURLs;
        }

        private static string convertThumbToImage(string url)
        {
            return url.Replace("thumbnail_", "").Replace("thumbnail", "image");
        }

        public static bool downloadImage(string imageUrl, string downloadLocation)
        {
            try
            {
                using (WebClient downloadClient = new WebClient())
                {
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile(new Uri(imageUrl), downloadLocation + imageUrl.Split('?')[0].Split('/').Last().ToString());
                }
            }
            catch (Exception e) { return false; }
            return true;
            
        }
    }
}
