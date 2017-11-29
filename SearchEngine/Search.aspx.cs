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

            Htmlİslemleri Cek_veri = new Htmlİslemleri();
            string html = Cek_veri.GetVeri(url);


            Title title = new Title();
            ahref ahref = new ahref();
            h1 h1 = new h1();
            h2 h2 = new h2();
            h3 h3 = new h3();
            h4 h4 = new h4();
            h5 h5 = new h5();
            h6 h6 = new h6();
            Head head = new Head();
            LabelHtml labelHtml = new LabelHtml();
            Link link = new Link();
            Span span = new Span();
            Strong strong = new Strong();
            Big big = new Big();
            Bold bold = new Bold();
            Em em = new Em();
            Li li = new Li();
            Option option = new Option();
            pTag p = new pTag();
            Th th = new Th();





            int title_KeSay=  title.TagsKelimeSayisi(html, arananKelime, Cek_veri, title.etiket);
            int ahref_KeSay = ahref.TagsKelimeSayisi(html, arananKelime, Cek_veri, ahref.etiket);
            int h1_KeSay = h1.TagsKelimeSayisi(html, arananKelime, Cek_veri, h1.etiket);
            int Strong_KeSay = strong.TagsKelimeSayisi(html, arananKelime, Cek_veri, strong.etiket);

            int KeyCount=Cek_veri.FindWord(html,arananKelime);
            
        }
       
    }
}
