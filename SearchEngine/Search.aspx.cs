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
            string url = UrlText.Text;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new WebClient { Encoding = System.Text.Encoding.UTF8 };

            String htmlz = client.DownloadString(url);

            String html = HttpUtility.HtmlDecode(htmlz).ToString();

            HtmlAgilityPack.HtmlDocument dokuman = new HtmlAgilityPack.HtmlDocument();
            dokuman.LoadHtml(html);
            string htmlSon = dokuman.ToString();

            //HtmlNodeCollection basliklar = dokuman.DocumentNode.SelectNodes("//li[@class='post-listing-list-item__post post-listing-list-item__post--featured']");

            int sayac = 0;
            
            string metin = html;
            
            string kelime = KeyText.Text;
            
            int konum = metin.IndexOf(kelime);
            
            while (konum != -1)
            {
                konum = metin.IndexOf(kelime, konum + 1);

                sayac++;
                
            }

        }
    }
}
