using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SearchEngine.TagsFolder;

namespace SearchEngine
{
    public partial class UrlSıralama : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private List<string> url_list = new List<string>();
        private List<string> kelime_list = new List<string>();
        protected void btn_urlEkle_Click(object sender, EventArgs e)
        {

        }

        protected void btn_UrlSırala_Click(object sender, EventArgs e)
        {
            string[] url_kumesi = UrlText.Text.Split(',');

            for (int i = 0; i < url_kumesi.Count(); i++)
            {
                url_list.Add(url_kumesi[i]);

            }
            string[] kelime_kumesi = KelimeText.Text.Split(',');

            for (int i = 0; i < kelime_kumesi.Count(); i++)
            {
                kelime_list.Add(kelime_kumesi[i]);

            }

            List<int> list = new List<int>();
            UrlPuan url_puan = new UrlPuan();

        }
        /*
        public double sıralamaPuan(List<string> html, List<string> aranankelime, Htmlİslemleri Cek_veri, string etiket, double puan)
        {

            List<double> Toplam_puan;
            HtmlAgilityPack.HtmlDocument htmldoc = new HtmlAgilityPack.HtmlDocument();
            for (int i = 0; i < html.Count; i++)
            {

                htmldoc.LoadHtml(html[i]);
                for (int j = 0; j < aranankelime.Count; j++)
                {
                    aranankelime[j].ToLower();
                }
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

                    for (int k = 0; k < liste.Count; k++)
                    {
                        stringDizi[k] = liste[k].ToString();
                    }

                    string tekstring;
                    tekstring = ConvertStringArrayToString(stringDizi);
                    tekstring = tekstring.ToLower();

                    List<int> kelimeSayisi = new List<int>();
                    for (int l = 0; l < aranankelime.Count; i++)
                    {
                        kelimeSayisi.Add(Cek_veri.FindWord(tekstring, aranankelime[l]));
                        if (kelimeSayisi[l] > 20)
                        {
                            kelimeSayisi[l] = kelimeSayisi[l] / 6;
                        }
                        Toplam_puan[l] = puan * kelimeSayisi[l];
                    }


                }
            }
            Toplam_puan = 0;
        }
        */
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
            toplamPuan = title_Puan + h1_Puan + h2_Puan + h4_Puan + h3_Puan + h5_Puan + h6_Puan + Strong_Puan + bold_Puan + em_Puan + head_Puan + label_Puan + li_Puan + link_Puan + options_Puan + span_Puan + th_Puan;
            return toplamPuan;
        }
    }
}