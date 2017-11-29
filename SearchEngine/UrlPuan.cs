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

        public double sıralamaPuan(string html, string aranankelime, Htmlİslemleri Cek_veri, string etiket, double puan)
        {
  
            double Toplam_puan = 0;
            HtmlAgilityPack.HtmlDocument htmldoc = new HtmlAgilityPack.HtmlDocument();
            htmldoc.LoadHtml(html);
            aranankelime.ToLower();
            HtmlNodeCollection basliklar = htmldoc.DocumentNode.SelectNodes(etiket);
            List<string> liste = new List<string>();
            if (basliklar != null)
            {
                foreach (var baslik in basliklar)
                {
                    liste.Add(baslik.InnerText);
                }
                double y;
                string[] stringDizi = new string[liste.Count];

                for (int i = 0; i < liste.Count; i++)
                {
                    stringDizi[i] = liste[i].ToString();
                }

                string tekstring;
                tekstring = ConvertStringArrayToString(stringDizi);
                tekstring = tekstring.ToLower();
                y = Cek_veri.FindWord(tekstring, aranankelime);
                if (y > 20)
                {
                    y = y / 6;
                }
                return Toplam_puan = puan * y;
            }
            return Toplam_puan=0;
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

        public double PuanHesapla(string html, string arananKelime, Htmlİslemleri Cek_veri)
        {
            double toplamPuan;

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
            UrlPuan urlpuan = new UrlPuan();



            double title_Puan = title.sıralamaPuan(html, arananKelime, Cek_veri, title.etiket, title.puan);
            double ahref_Puan = ahref.sıralamaPuan(html, arananKelime, Cek_veri, ahref.etiket, ahref.puan);
            double h1_Puan = h1.sıralamaPuan(html, arananKelime, Cek_veri, h1.etiket, h1.puan);
            double h2_Puan = h2.sıralamaPuan(html, arananKelime, Cek_veri, h2.etiket, h2.puan);
            double h3_Puan = h3.sıralamaPuan(html, arananKelime, Cek_veri, h3.etiket, h3.puan);
            double h4_Puan = h4.sıralamaPuan(html, arananKelime, Cek_veri, h4.etiket, h4.puan);
            double h5_Puan = h5.sıralamaPuan(html, arananKelime, Cek_veri, h5.etiket, h5.puan);
            double h6_Puan = h6.sıralamaPuan(html, arananKelime, Cek_veri, h6.etiket, h6.puan);
            double Strong_Puan = strong.sıralamaPuan(html, arananKelime, Cek_veri, strong.etiket, strong.puan);
            double bold_Puan = bold.sıralamaPuan(html, arananKelime, Cek_veri, bold.etiket, bold.puan);
            double em_Puan = em.sıralamaPuan(html, arananKelime, Cek_veri, em.etiket, em.puan);
            double head_Puan = head.sıralamaPuan(html, arananKelime, Cek_veri, head.etiket, head.puan);
            double label_Puan = labelHtml.sıralamaPuan(html, arananKelime, Cek_veri, labelHtml.etiket, labelHtml.puan);
            double li_Puan = li.sıralamaPuan(html, arananKelime, Cek_veri, li.etiket, li.puan);
            double link_Puan = link.sıralamaPuan(html, arananKelime, Cek_veri, link.etiket, link.puan);
            double options_Puan = option.sıralamaPuan(html, arananKelime, Cek_veri, option.etiket, option.puan);
            double span_Puan = span.sıralamaPuan(html, arananKelime, Cek_veri, span.etiket, span.puan);
            double th_Puan = th.sıralamaPuan(html, arananKelime, Cek_veri, th.etiket, th.puan);
            toplamPuan =title_Puan + h1_Puan + h2_Puan + h4_Puan + h3_Puan + h5_Puan + h6_Puan  +Strong_Puan+ bold_Puan + em_Puan + head_Puan + label_Puan + li_Puan + link_Puan + options_Puan + span_Puan + th_Puan;
            return toplamPuan;
        }



    }
}