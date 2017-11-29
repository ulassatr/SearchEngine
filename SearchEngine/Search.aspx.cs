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
using SearchEngine.TagsFolder;

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
            string arananKelime = KeyText.Text;
            double firstUrlPuan = 0;
            Htmlİslemleri Cek_veri = new Htmlİslemleri();
            string html = Cek_veri.GetVeri(url);

            //Tag nesnelerimizi yaratıyoruz
            UrlPuan urlpuan = new UrlPuan();
            firstUrlPuan =urlpuan.PuanHesapla(html, arananKelime, Cek_veri);



            int KeyCount=Cek_veri.FindWord(html,arananKelime);
            
        }
       
    }
}
