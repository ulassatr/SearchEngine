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
            Htmlİslemleri Cek_veri = new Htmlİslemleri();
            string html = Cek_veri.GetVeri(url);

            //HtmlNodeCollection basliklar = dokuman.DocumentNode.SelectNodes("//li[@class='post-listing-list-item__post post-listing-list-item__post--featured']");
            int KeyCount=Cek_veri.FindWord(html, KeyText.Text);

        }
    }
}
