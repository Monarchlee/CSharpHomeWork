using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCrawler
{
    public delegate void DownloadHanlder(string obj);
    public class SimpleCrawler
    {

        public event DownloadHanlder DownloadThing;
        private Hashtable urls = new Hashtable();
        private int count = 0;
        public List<string> StartUrl { get; set; }
       static void Main(string[] args)
        {
            SimpleCrawler myCrawler = new SimpleCrawler();
            if (args.Length >= 1)
                foreach (string url in args)
                {
                    myCrawler.urls.Add(url, false);
                    myCrawler.StartUrl.Add(url);
                }//加入初始页面
            else
            {
                myCrawler.StartUrl.Add("http://www.cnblogs.com/dstang2000/");
                myCrawler.urls.Add(myCrawler.StartUrl[0], false);
            }
            new Thread(myCrawler.Crawl).Start();
        }
        
        public void ThreadStart()
        {
            if(StartUrl.Count==0)
            {
                return;
            }
            else
            {
                foreach(string url in StartUrl)
                {
                    urls.Add(url, false);
                }
            }
            Crawl();
        }

        public SimpleCrawler()
        {
            StartUrl = new List<string>();
        }
        public void Crawl()
        {
            //Console.WriteLine("开始爬行了.... ");
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                }

                if (current == null || count > 10) break;
               // Console.WriteLine("爬行" + current + "页面!");
                string html = DownLoad(current); // 下载
                urls[current] = true;
                count++;
                if(JudgeHtmlDow(html))
                Parse(html);//解析,并加入新的链接
               // Console.WriteLine("爬行结束");
            }
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                DownloadThing("Success->"+url);
                return html;
            }
            catch (Exception ex)
            {
                DownloadThing(ex.Message+"->"+url);
                return ex.Message;
            }
        }

        private void Parse(string html)
        {
            string strRef = @"(href|HREF)[ ]*=[ ]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                          .Trim('"', '\"', '#', '>');
                if (strRef.Length == 0) continue;
                strRef = Transform(html, strRef);
                if (urls[strRef] == null && JudgeChild(strRef)&&JudgeHtml(strRef)) urls[strRef] = false;
            }
        }

        private bool JudgeChild(string strRef)
        {
            foreach (string startUrl in StartUrl)
            {
                if (!Regex.IsMatch(strRef, TransToFather(startUrl)))
                {
                    return false;
                }
            }
            return true;
        }
        private bool JudgeHtmlDow(string html)
        {
            return Regex.IsMatch(html, @"</html>[ ]*$");
        }
        private bool JudgeHtml(string url)
        {
            return Regex.IsMatch(url, @"[.]html[^/]*$")&&!Regex.IsMatch(url,@"<head>");
        }

        private string Transform(string html, string child)
        {
            if (Regex.IsMatch(child, @"^(https://|HTTPS://)"))
                return child;
            if (Regex.IsMatch(child, @"^[/]"))
            {
                Regex regex = new Regex(@"(https://|HTTPS://)[^/]+");
                return regex.Match(html) + child;
            }
            else
            {
                Regex regex = new Regex(@"/([^/]+$|$)");
                return regex.Replace(html, "/" + child);
            }
        }
        private string TransToFather(string url)
        {
            return Regex.Match(url, @"(https://|HTTPS://)[^/]+").Value;
        }
    }
}
