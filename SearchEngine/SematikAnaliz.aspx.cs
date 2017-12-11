using HtmlAgilityPack;
using SearchEngine.TagsFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SearchEngine
{
    public partial class SematikAnaliz : System.Web.UI.Page
    {
        public List<string> url_list = new List<string>();
        public List<string> kelime_list = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            linkleriBul();
        }
        public void linkleriBul()
        {
            //Kullanıcının girdiği urlleri listeye attık
            string[] url_kumesi = TextBox1.Text.Split(',');

            for (int i = 0; i < url_kumesi.Count(); i++)
            {
                url_list.Add(url_kumesi[i]);

            }
            //Kullanıcının girdiği kelimeleri listeye attık
            string[] kelime_kumesi = TextBox2.Text.Split(',');

            for (int i = 0; i < kelime_kumesi.Count(); i++)
            {
                kelime_list.Add(kelime_kumesi[i]);

            }
            List<string> esAnlam = esAnlamMethod(kelime_list);

            for (int i = 0; i < esAnlam.Count; i++)
            {
                kelime_list.Add(esAnlam[i]);
            }


            List<string> linkListesi = new List<string>();
            List<string> yuhAqIkıncıDerinlik = new List<string>();
            Htmlİslemleri Cek_veri = new Htmlİslemleri();
            List<string> liste = new List<string>();
            List<string> ikinciListe = new List<string>();

            for (int j = 0; j < url_list.Count; j++)
            {
                liste.AddRange(altDerinligeIn(hrefDonduren(url_list), j, url_list));
            }
            for (int i = 0; i < url_list.Count; i++)
            {
                for (int j = 0; j < liste.Count; j++)
                {
                    if (url_list[i] == liste[j])
                    {
                        liste.RemoveAt(j);
                    }
                }
            }
            for (int z = 0; z < liste.Count; z++)
            {
                ikinciListe.AddRange(altDerinligeIn(hrefDonduren(liste), z, liste));

            }
            for (int i = 0; i < liste.Count; i++)
            {
                for (int j = 0; j < ikinciListe.Count; j++)
                {
                    if (liste[i] == ikinciListe[j])
                    {
                        ikinciListe.RemoveAt(j);
                    }
                }
            }

            List<string> sonuc = new List<string>();
            List<double> anaURL = puanHesapla(url_list);
            List<double> derinlik1 = puanHesapla(liste);
            List<double> derinlik2 = puanHesapla(ikinciListe);

            for (int i = 0; i < anaURL.Count; i++)
            {
                sonuc.Add(url_list[i]);
                sonuc.Add("puan: " + anaURL[i].ToString());
            }
            for (int j = 0; j < derinlik1.Count; j++)
            {
                sonuc.Add(liste[j]);
                sonuc.Add("puan: " + derinlik1[j].ToString());
            }
            for (int k = 0; k < derinlik2.Count; k++)
            {
                sonuc.Add(ikinciListe[k]);
                sonuc.Add("puan: " + derinlik2[k].ToString());
            }
            for (int c = 0; c < sonuc.Count; c++)
            {
                TextBox3.Text = TextBox3.Text + sonuc[c] + Environment.NewLine;
            }



        }

        public List<string> hrefDonduren(List<string> url_list)
        {
            string htmlstring;
            List<string> hrefTags = new List<string>();
            Htmlİslemleri Cek_veri = new Htmlİslemleri();
            List<string> liste = new List<string>();
            //Url listesi kadar htmllerini çekiyoruz
            for (int j = 0; j < url_list.Count; j++)
            {
                try
                {
                    htmlstring = Cek_veri.GetVeri(url_list[j]);
                    HtmlAgilityPack.HtmlDocument htmldoc = new HtmlAgilityPack.HtmlDocument();
                    htmldoc.LoadHtml(htmlstring);

                    if (htmldoc.DocumentNode.SelectNodes("//a[@href]") != null)
                    {

                        foreach (HtmlNode link in htmldoc.DocumentNode.SelectNodes("//a[@href]"))
                        {


                            HtmlAttribute att = link.Attributes["href"];
                            hrefTags.Add(att.Value); //linklerimizi alıyoruz
                            if (hrefTags.Count == 200)
                            {
                                return hrefTags;
                            }


                        }
                    }

                }

                catch (Exception ex)
                {

                    url_list.RemoveAt(j);
                    //throw;
                }


            }
            return hrefTags;
        }
        public List<string> altDerinligeIn(List<string> hrefTags, int k, List<string> url_list)
        {
            List<string> dogruLinkler = new List<string>();
            List<bool> deneme = new List<bool>();
            for (int c = 0; c < hrefTags.Count; c++)
            {
                if (hrefTags[c].IndexOf(".pdf") != -1)
                {
                    hrefTags.RemoveAt(c);
                }
            }
            for (int i = 0; i < hrefTags.Count; i++)
            {
                deneme.Add(hrefTags[i].StartsWith(url_list[k]));
            }

            for (int i = 0; i < deneme.Count; i++)
            {
                if (deneme[i] == true)
                {
                    dogruLinkler.Add(hrefTags[i]);

                }
            }
            return dogruLinkler;
        }

        public List<double> puanHesapla(List<string> url_list)
        {
            #region tanımlamalar
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


            Htmlİslemleri Cek_veri = new Htmlİslemleri();
            string htmlstring;
            List<int> kelimeSayilari = new List<int>();
            int KeyCount = 0;
            List<double> standartSapmaListesi = new List<double>();
            double standartSapma;
            List<double> URLpuan = new List<double>();
            double tekUrlPuan = 0;


            #endregion

            for (int j = 0; j < url_list.Count; j++)
            {
                htmlstring = Cek_veri.GetVeri(url_list[j]);
                HtmlAgilityPack.HtmlDocument htmldoc = new HtmlAgilityPack.HtmlDocument();
                htmldoc.LoadHtml(htmlstring);
                #region etiketPuanlama
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
                #endregion
                tekUrlPuan = 0;

                for (int i = 0; i < kelime_list.Count; i++)
                {
                    KeyCount = Cek_veri.FindWord(htmlstring, kelime_list[i]);
                    if (kelimeSayilari.Count == kelime_list.Count)
                    {
                        kelimeSayilari.Clear();
                    }
                    kelimeSayilari.Add(KeyCount);
                    if (i == kelime_list.Count - 1)
                    {
                        standartSapma = 0;
                        standartSapma = standart(kelimeSayilari);
                        standartSapmaListesi.Add(standartSapma);
                    }
                    #region uzunifkontrolu
                    toplamPuan[i] = 0;
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
                    #endregion
                    //2 kelime için puanı toplanıcak
                    tekUrlPuan = tekUrlPuan + toplamPuan[i];
                }
                if (kelime_list.Count == 1)
                {
                    URLpuan.Add(tekUrlPuan);
                }
                else
                {
                    URLpuan.Add(tekUrlPuan / standartSapmaListesi[j]);
                }
            }
            return URLpuan;

        }
        public double ortalama(List<int> dizi) // Ortalama
        {
            int toplam = 0;
            for (int i = 0; i < dizi.Count; i++)
                toplam += dizi[i];
            return toplam / dizi.Count;
        }

        public double standart(List<int> dizi) // Standart Sapma
        {
            double ort = ortalama(dizi);
            double toplam = 0.0;
            for (int i = 0; i < dizi.Count; i++)
                toplam += Math.Pow((dizi[i] - ort), 2);
            return Math.Sqrt(toplam / (dizi.Count - 1));
        }

        public List<string> esAnlamMethod(List<string> kelime_list)
        {
            List<HtmlNode> linkNode = new List<HtmlNode>();
            Htmlİslemleri Cek_veri = new Htmlİslemleri();
            List<string> esAnlam = new List<string>();
            for (int i = 0; i < kelime_list.Count; i++)
            {
                List<string> parcala;
                string donen;
                string htmlstring;
                string kelimeUrl = "http://www.es-anlam.com/kelime/" + kelime_list[i];
                htmlstring = Cek_veri.GetVeri(kelimeUrl);
                HtmlAgilityPack.HtmlDocument htmldoc = new HtmlAgilityPack.HtmlDocument();
                htmldoc.LoadHtml(htmlstring);
                HtmlNodeCollection link = htmldoc.DocumentNode.SelectNodes("//strong");

                if (link != null)
                {
                    if (link[1].InnerText == "BULUNAMADI !")
                    {
                        continue;
                    }
                    if (link[1].InnerText.Contains(','))
                    {

                        parcala = link[1].InnerText.Split(',').ToList();
                        for (int h = 0; h < parcala.Count; h++)
                        {
                            donen = parcala[h].Trim();
                            esAnlam.Add(donen);
                        }

                    }
                    else
                    {
                        esAnlam.Add(link[1].InnerText);
                    }


                }

            }
            return esAnlam;
        }
    }
}
