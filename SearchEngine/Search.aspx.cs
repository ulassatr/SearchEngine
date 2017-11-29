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

            int title_KeSay=  title.TagsKelimeSayisi(html, arananKelime, Cek_veri, title.etiket);
            int ahref_KeSay = ahref.TagsKelimeSayisi(html, arananKelime, Cek_veri, ahref.etiket);
            int h1_KeSay = h1.TagsKelimeSayisi(html, arananKelime, Cek_veri, h1.etiket);

            int KeyCount=Cek_veri.FindWord(html,arananKelime);
            
        }
       
    }
}
