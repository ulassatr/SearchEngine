using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Globalization;
using System.IO;
using System.Text;
using HtmlAgilityPack;
namespace SearchEngine
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            //  string adresal = UrlText.Text;
            //  WebResponse GelenCevap;
            //  WebRequest adresistegi = HttpWebRequest.Create(adresal);
            //  GelenCevap = adresistegi.GetResponse();
            //// CultureInfo tr = new CultureInfo("tr - TR");
            //  StreamReader SayfaKaynakBilgisi = new StreamReader(GelenCevap.GetResponseStream());
            //  string kaynakbilgiyial = SayfaKaynakBilgisi.ReadToEnd();

            //   string url = UrlText.Text;
            //    WebRequest req = HttpWebRequest.Create(url);
            //    WebResponse res;
            //    try
            //    {

            //        res = req.GetResponse();

            //        StreamReader data = new StreamReader(res.GetResponseStream(), System.Text.Encoding.GetEncoding("windows-1254"));
            //        string icerik = data.ReadToEnd();

            //        //int start = icerik.IndexOf("<h1>") + 4;
            //        //int end = icerik.IndexOf("</h1>");
            //        //string h1 = icerik.Substring(start, end - start);
            //        //richTextBox1.Text = h1;
            //    }
            //    catch
            //    { /*richTextBox1.Text = "Sayfa okunamadı!";*/ }


            //}
            //string url = UrlText.Text;
            //var html = new HtmlDocument();
            //html.LoadHtml(new WebClient().DownloadString(url));
            //var root = html.DocumentNode;
            //var nodes = root.Descendants();
            //var totalNodes = nodes.Count();
            string url = UrlText.Text;
            string document = GetSourceCode(url);
            KeyText.Text = document;
        }
        static string GetSourceCode(string url)
        {
            // web isteği oluştur
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            // gelen cevabı al
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            // cevapla gelen veriyi oku
            using (StreamReader sRead = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
            {
                // veriyi döndür
                return sRead.ReadToEnd();
            }
        }
    }
}
