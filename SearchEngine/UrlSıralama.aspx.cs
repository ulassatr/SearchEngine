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
        public List<string> url_list = new List<string>();
        public List<string> kelime_list = new List<string>();
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
            Title title = new Title();
            ahref a = new ahref();
            List<int> list = new List<int>();
            UrlPuan url_puan = new UrlPuan();
            Htmlİslemleri Cek_veri = new Htmlİslemleri();
            List<double> title_Puan = new List<double>();
            List<double> ahref_Puan = new List<double>();
            List<double> h1_Puan = new List<double>();
            List<double> h2_Puan = new List<double>();
            List<double> h3_Puan = new List<double>();
            List<double> h4_Puan = new List<double>();
            List<double> h5_Puan = new List<double>();
            List<double> h6_Puan = new List<double>();
            List<double> big_Puan = new List<double>();
            List<double> bold_Puan = new List<double>();
            List<double> em_Puan = new List<double>();
            List<double> head_Puan = new List<double>();
            List<double> label_Puan = new List<double>();
            List<double> li_Puan = new List<double>();
            List<double> link_Puan = new List<double>();
            List<double> option_Puan = new List<double>();
            List<double> p_Puan = new List<double>();
            List<double> span_Puan = new List<double>();
            List<double> strong_Puan = new List<double>();
            List<double> th_Puan = new List<double>();
            //     List<double> toplamPuan = new List<double>();
            double[] toplamPuan = new double[kelime_list.Count];
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
            LabelHtml labelhtml = new LabelHtml();

            title_Puan = title.sıralamaPuan(url_list, kelime_list, Cek_veri, title.etiket, title.puan);
            ahref_Puan = ahref.sıralamaPuan(url_list, kelime_list, Cek_veri, ahref.etiket, ahref.puan);
            h1_Puan = h1.sıralamaPuan(url_list, kelime_list, Cek_veri, h1.etiket, h1.puan);
            h2_Puan = h2.sıralamaPuan(url_list, kelime_list, Cek_veri, h2.etiket, h2.puan);
            h3_Puan = h3.sıralamaPuan(url_list, kelime_list, Cek_veri, h3.etiket, h3.puan);
            h4_Puan = h4.sıralamaPuan(url_list, kelime_list, Cek_veri, h4.etiket, h4.puan);
            h5_Puan = h5.sıralamaPuan(url_list, kelime_list, Cek_veri, h5.etiket, h5.puan);
            h6_Puan = h6.sıralamaPuan(url_list, kelime_list, Cek_veri, h6.etiket, h6.puan);
            strong_Puan = strong.sıralamaPuan(url_list, kelime_list, Cek_veri, strong.etiket, strong.puan);
            bold_Puan = bold.sıralamaPuan(url_list, kelime_list, Cek_veri, bold.etiket, bold.puan);
            em_Puan = em.sıralamaPuan(url_list, kelime_list, Cek_veri, em.etiket, em.puan);
            head_Puan = head.sıralamaPuan(url_list, kelime_list, Cek_veri, head.etiket, head.puan);
            label_Puan = labelhtml.sıralamaPuan(url_list, kelime_list, Cek_veri, labelhtml.etiket, labelhtml.puan);
            li_Puan = li.sıralamaPuan(url_list, kelime_list, Cek_veri, li.etiket, li.puan);
            link_Puan = link.sıralamaPuan(url_list, kelime_list, Cek_veri, link.etiket, link.puan);
            option_Puan = option.sıralamaPuan(url_list, kelime_list, Cek_veri, option.etiket, option.puan);
            span_Puan = span.sıralamaPuan(url_list, kelime_list, Cek_veri, span.etiket, span.puan);
            th_Puan = th.sıralamaPuan(url_list, kelime_list, Cek_veri, th.etiket, th.puan);

            for (int i = 0; i < kelime_list.Count; i++)
            {
                if (ahref_Puan.Count != 0)
                {
                    toplamPuan[i] = toplamPuan[i]+ahref_Puan[i];
                }
                if (title_Puan.Count != 0)
                {
                    toplamPuan[i] = toplamPuan[i] + title_Puan[i];
                }
                 if (h1_Puan.Count != 0)
                {
                    toplamPuan[i] = toplamPuan[i] + h1_Puan[i];
                }
                if (h2_Puan.Count != 0)
                {
                    toplamPuan[i] = toplamPuan[i] + h2_Puan[i];
                }
                if (h3_Puan.Count != 0)
                {
                    toplamPuan[i] = toplamPuan[i] + h3_Puan[i];
                }
                if (h4_Puan.Count != 0)
                {
                    toplamPuan[i] = toplamPuan[i] + h4_Puan[i];

                }
                if (h5_Puan.Count != 0)
                {
                    toplamPuan[i] = toplamPuan[i] + h5_Puan[i];
                }
                if (h6_Puan.Count !=0)
                {
                    toplamPuan[i] = toplamPuan[i] + h6_Puan[i];
                }
                if (strong_Puan.Count != 0)
                {
                    toplamPuan[i] = toplamPuan[i] + strong_Puan[i];
                }
                if (bold_Puan.Count != 0)
                {
                    toplamPuan[i] = toplamPuan[i] + bold_Puan[i];
                }
                if (head_Puan.Count != 0)
                {
                    toplamPuan[i] = toplamPuan[i] + head_Puan[i];
                }
                if (label_Puan.Count != 0)
                {
                    toplamPuan[i] = toplamPuan[i] + label_Puan[i];
                }
               if (li_Puan.Count != 0)
                {
                    toplamPuan[i] = toplamPuan[i] + li_Puan[i];
                }
               if (link_Puan.Count != 0)
                {
                    toplamPuan[i] = toplamPuan[i] + link_Puan[i];
                }
                if (option_Puan.Count != 0)
                {
                    toplamPuan[i] = toplamPuan[i] + option_Puan[i];
                }
                if (span_Puan.Count != 0)
                {
                    toplamPuan[i] = toplamPuan[i] + span_Puan[i];
                }
                if (th_Puan.Count != 0)
                {
                    toplamPuan[i] = toplamPuan[i] + th_Puan[i];
                }
                 
            }

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
        /*
        public double PuanHesapla(string html, string arananKelime, Htmlİslemleri Cek_veri)
        {
            double toplamPuan;

           
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

     
            //double title_puan = title.sıralamapuan(html, aranankelime, cek_veri, title.etiket, title.puan);
            double ahref_puan = ahref.sıralamapuan(html, aranankelime, cek_veri, ahref.etiket, ahref.puan);
            double h1_puan = h1.sıralamapuan(html, aranankelime, cek_veri, h1.etiket, h1.puan);
            double h2_puan = h2.sıralamapuan(html, aranankelime, cek_veri, h2.etiket, h2.puan);
            double h3_puan = h3.sıralamapuan(html, aranankelime, cek_veri, h3.etiket, h3.puan);
            double h4_puan = h4.sıralamapuan(html, aranankelime, cek_veri, h4.etiket, h4.puan);
            double h5_puan = h5.sıralamapuan(html, aranankelime, cek_veri, h5.etiket, h5.puan);
            double h6_puan = h6.sıralamapuan(html, aranankelime, cek_veri, h6.etiket, h6.puan);
            double strong_puan = strong.sıralamapuan(html, aranankelime, cek_veri, strong.etiket, strong.puan);
            double bold_puan = bold.sıralamapuan(html, aranankelime, cek_veri, bold.etiket, bold.puan);
            double em_puan = em.sıralamapuan(html, aranankelime, cek_veri, em.etiket, em.puan);
            double head_puan = head.sıralamapuan(html, aranankelime, cek_veri, head.etiket, head.puan);
            double label_puan = labelhtml.sıralamapuan(html, aranankelime, cek_veri, labelhtml.etiket, labelhtml.puan);
            double li_puan = li.sıralamapuan(html, aranankelime, cek_veri, li.etiket, li.puan);
            double link_puan = link.sıralamapuan(html, aranankelime, cek_veri, link.etiket, link.puan);
            double options_puan = option.sıralamapuan(html, aranankelime, cek_veri, option.etiket, option.puan);
            double span_puan = span.sıralamapuan(html, aranankelime, cek_veri, span.etiket, span.puan);
            double th_puan = th.sıralamapuan(html, aranankelime, cek_veri, th.etiket, th.puan);
            toplampuan = title_puan + h1_puan + h2_puan + h4_puan + h3_puan + h5_puan + h6_puan + strong_puan + bold_puan + em_puan + head_puan + label_puan + li_puan + link_puan + options_puan + span_puan + th_puan;
            //return toplamPuan;
        }*/
    }
}