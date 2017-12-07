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
     //       double firstUrlPuan = 0;
            Htmlİslemleri Cek_veri = new Htmlİslemleri();
            string html = Cek_veri.GetVeri(url);

            //Tag nesnelerimizi yaratıyoruz
            UrlPuan urlpuan = new UrlPuan();
            //     firstUrlPuan =urlpuan.PuanHesapla(html, arananKelime, Cek_veri);

            Title title = new Title();
            h2 h2 = new h2();
            h3 h3 = new h3();
            h1 h1 = new h1();
            Head head = new Head();
            Th th = new Th();
            p p = new p();
            Li li = new Li();
            ahref a = new ahref();
            Span span = new Span();
            int toplamKelimeSayisi;


            int title_sayi = title.kelimeSayisi(html, arananKelime, Cek_veri, title.etiket);
            int a_sayi = a.kelimeSayisi(html, arananKelime, Cek_veri, a.etiket);
            int h1_sayi = h1.kelimeSayisi(html, arananKelime, Cek_veri, h1.etiket);
            int h2_sayi = h2.kelimeSayisi(html, arananKelime, Cek_veri, h2.etiket);
            int h3_sayi = h3.kelimeSayisi(html, arananKelime, Cek_veri, h3.etiket);
            int th_sayi = th.kelimeSayisi(html, arananKelime, Cek_veri, th.etiket);
        //    int li_sayi = li.kelimeSayisi(html, arananKelime, Cek_veri, li.etiket);
            int span_sayi= span.kelimeSayisi(html, arananKelime, Cek_veri, span.etiket);
          //  int p_sayi = p.kelimeSayisi(html, arananKelime, Cek_veri, p.etiket);
            int head_Sayi = head.kelimeSayisi(html, arananKelime, Cek_veri, head.etiket);
            toplamKelimeSayisi = th_sayi + h1_sayi + title_sayi+a_sayi+title_sayi+h2_sayi+h3_sayi+span_sayi+head_Sayi;
            //      int KeyCount=Cek_veri.FindWord(html,arananKelime);

            text_goruntule.Text = "Toplam Kelime Sayısı : "+toplamKelimeSayisi.ToString();


        }
       
    }
}
