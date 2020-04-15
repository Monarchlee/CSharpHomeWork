using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleCrawler;
using System.Threading;



namespace Crawler
{

    public partial class CrawlerForm : Form
    {

        private SimpleCrawler.SimpleCrawler simpleCrawler = new SimpleCrawler.SimpleCrawler();
        public List<UrlData> UrlsInfo { get; set; }
        public CrawlerForm()
        {
            InitializeComponent();
            UrlsInfo = new List<UrlData>();
            simpleCrawler.DownloadThing += DownloadDone;
            bdsUrl.DataSource = UrlsInfo;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            simpleCrawler.StartUrl.Add(txbStartURL.Text);
            UrlsInfo.Clear();
            new Thread(simpleCrawler.ThreadStart).Start();
        }
        public void DownloadDone(string obj)
        {
            if (this.dgvDownLoadInfo.InvokeRequired)
            {
                Action<String> action = this.AddUrl;
                this.Invoke(action, new object[] { obj });
            }
            else
            {
                UrlData urlData = new UrlData();
                urlData.UrlInfo = obj;
                UrlsInfo.Add(urlData);
            }

        }


        private void AddUrl(string url)
        {
            UrlData urlData = new UrlData();
            urlData.UrlInfo = url;
            UrlsInfo.Add(urlData);
            bdsUrl.DataSource = UrlsInfo;
            bdsUrl.ResetBindings(true);
        }
    }
    public class UrlData
    {
        public string UrlInfo { get; set; }
    }
}
