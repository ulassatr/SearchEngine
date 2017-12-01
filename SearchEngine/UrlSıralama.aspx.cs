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

            Htmlİslemleri Cek_veri = new Htmlİslemleri();
            string htmlstring;
            htmlstring = Cek_veri.GetVeri(url_list[0]);
            HtmlAgilityPack.HtmlDocument htmldoc = new HtmlAgilityPack.HtmlDocument();
            htmldoc.LoadHtml(htmlstring);

            Title title = new Title();
            ahref a = new ahref();
            List<int> list = new List<int>();
            UrlPuan url_puan = new UrlPuan();

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

            title_Puan = title.sıralamaPuan(url_list, kelime_list, Cek_veri, title.etiket, title.puan, htmldoc);
            ahref_Puan = ahref.sıralamaPuan(url_list, kelime_list, Cek_veri, ahref.etiket, ahref.puan, htmldoc);
            h1_Puan = h1.sıralamaPuan(url_list, kelime_list, Cek_veri, h1.etiket, h1.puan, htmldoc);
            h2_Puan = h2.sıralamaPuan(url_list, kelime_list, Cek_veri, h2.etiket, h2.puan, htmldoc);
            h3_Puan = h3.sıralamaPuan(url_list, kelime_list, Cek_veri, h3.etiket, h3.puan, htmldoc);
            h4_Puan = h4.sıralamaPuan(url_list, kelime_list, Cek_veri, h4.etiket, h4.puan, htmldoc);
            h5_Puan = h5.sıralamaPuan(url_list, kelime_list, Cek_veri, h5.etiket, h5.puan, htmldoc);
            h6_Puan = h6.sıralamaPuan(url_list, kelime_list, Cek_veri, h6.etiket, h6.puan, htmldoc);
            strong_Puan = strong.sıralamaPuan(url_list, kelime_list, Cek_veri, strong.etiket, strong.puan, htmldoc);
            bold_Puan = bold.sıralamaPuan(url_list, kelime_list, Cek_veri, bold.etiket, bold.puan, htmldoc);
            em_Puan = em.sıralamaPuan(url_list, kelime_list, Cek_veri, em.etiket, em.puan, htmldoc);
            head_Puan = head.sıralamaPuan(url_list, kelime_list, Cek_veri, head.etiket, head.puan, htmldoc);
            label_Puan = labelhtml.sıralamaPuan(url_list, kelime_list, Cek_veri, labelhtml.etiket, labelhtml.puan, htmldoc);
            li_Puan = li.sıralamaPuan(url_list, kelime_list, Cek_veri, li.etiket, li.puan, htmldoc);
            link_Puan = link.sıralamaPuan(url_list, kelime_list, Cek_veri, link.etiket, link.puan, htmldoc);
            option_Puan = option.sıralamaPuan(url_list, kelime_list, Cek_veri, option.etiket, option.puan, htmldoc);
            span_Puan = span.sıralamaPuan(url_list, kelime_list, Cek_veri, span.etiket, span.puan, htmldoc);
            th_Puan = th.sıralamaPuan(url_list, kelime_list, Cek_veri, th.etiket, th.puan, htmldoc);
            List<double> URLpuan = new List<double>();
            double tekUrlPuan = 0;
            for (int i = 0; i < kelime_list.Count; i++)
            {
                tekUrlPuan = 0;
                if (ahref_Puan.Count != 0)
                {
                    toplamPuan[i] = toplamPuan[i] + ahref_Puan[i];
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
                if (h6_Puan.Count != 0)
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
                //2 kelime için puanı toplanıcak

                tekUrlPuan = tekUrlPuan + toplamPuan[i];
            }
            //ŞURAYI DÜZENLİCEZ TÜM URLLER İÇİN PUAN ALICAK
            for (int i = 0; i < url_list.Count; i++)
            {
                URLpuan.Add(tekUrlPuan);
            }
        }
    }
}
