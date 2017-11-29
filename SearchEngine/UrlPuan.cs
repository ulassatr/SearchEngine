using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SearchEngine.TagsFolder;
using HtmlAgilityPack;
using System.Text;

namespace SearchEngine
{
    public class UrlPuan : Search
    {
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
        Th th = new Th();
               

        public int TagsKelimeSayisi(string html, string aranankelime, Htmlİslemleri Cek_veri, string etiket,int puan)
        {
            int Toplam_puan = 0;
            HtmlAgilityPack.HtmlDocument htmldoc = new HtmlAgilityPack.HtmlDocument();
            htmldoc.LoadHtml(html);
            aranankelime.ToLower();
            HtmlNodeCollection basliklar = htmldoc.DocumentNode.SelectNodes(etiket);
            List<string> liste = new List<string>();
            foreach (var baslik in basliklar)
            {
                liste.Add(baslik.InnerText);
            }
            int y;
            string[] stringDizi = new string[liste.Count];

            for (int i = 0; i < liste.Count; i++)
            {
                stringDizi[i] = liste[i].ToString();
            }

            string tekstring;
            tekstring = ConvertStringArrayToString(stringDizi);
            tekstring = tekstring.ToLower();

            y = Cek_veri.FindWord(tekstring, aranankelime);

            return Toplam_puan=puan*y;

        }
        public string ConvertStringArrayToString(string[] array)
        {
            //
            // Bu metod ile string builder nesne'mizi oluşturup
            // foreach döngüsü ve StringBuilder'in Append metodu
            // ilede stringimizi oluşturuyoruz
            //
            StringBuilder builder = new StringBuilder();
            foreach (string value in array)
            {
                builder.Append(value);
                builder.Append(' ');
            }
            return builder.ToString();
        }
        
        public int PuanHesapla(string html, string arananKelime, Htmlİslemleri Cek_veri, string etiket,int puan)
        {
            int title_KeSay = title.TagsKelimeSayisi(html, arananKelime, Cek_veri, title.etiket);
            int ahref_KeSay = ahref.TagsKelimeSayisi(html, arananKelime, Cek_veri, ahref.etiket,ahref.puan);
            int h1_KeSay = h1.TagsKelimeSayisi(html, arananKelime, Cek_veri, h1.etiket);
            int h2_KeSay = h2.TagsKelimeSayisi(html, arananKelime, Cek_veri, h2.etiket);
            int h3_KeSay = h3.TagsKelimeSayisi(html, arananKelime, Cek_veri, h3.etiket);
            int h4_KeSay = h4.TagsKelimeSayisi(html, arananKelime, Cek_veri, h4.etiket);
            int h5_KeSay = h5.TagsKelimeSayisi(html, arananKelime, Cek_veri, h5.etiket);
            int h6_KeSay = h6.TagsKelimeSayisi(html, arananKelime, Cek_veri, h6.etiket);
            int Strong_KeSay = strong.TagsKelimeSayisi(html, arananKelime, Cek_veri, strong.etiket);
            int Bold_Kesay= bold.TagsKelimeSayisi(html, arananKelime, Cek_veri, bold.etiket);
            int Em_Kesay = em.TagsKelimeSayisi(html, arananKelime, Cek_veri, em.etiket);
            int Head_Kesay = head.TagsKelimeSayisi(html, arananKelime, Cek_veri, head.etiket);
            int Label_Kesay = labelHtml.TagsKelimeSayisi(html, arananKelime, Cek_veri, labelHtml.etiket);
            int Li_Kesay = li.TagsKelimeSayisi(html, arananKelime, Cek_veri, li.etiket);
            int Link_Kesay = link.TagsKelimeSayisi(html, arananKelime, Cek_veri, link.etiket);
            int Options_Kesay = option.TagsKelimeSayisi(html, arananKelime, Cek_veri, option.etiket);
            int Span_Kesay = span.TagsKelimeSayisi(html, arananKelime, Cek_veri, span.etiket);
            int Th_Kesay = th.TagsKelimeSayisi(html, arananKelime, Cek_veri, th.etiket);
            

        }

        

    }
}