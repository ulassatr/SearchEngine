using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SearchEngine
{
    public partial class SiteSiralama : System.Web.UI.Page
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

            string htmlstring;
            List<string> linkListesi = new List<string>();
            List<string> yuhAqIkıncıDerinlik = new List<string>();
            Htmlİslemleri Cek_veri = new Htmlİslemleri();
            List<string> liste = new List<string>();
            //Url listesi kadar htmllerini çekiyoruz
            for (int j = 0; j < url_list.Count; j++)
            {
                htmlstring = Cek_veri.GetVeri(url_list[j]);
                HtmlAgilityPack.HtmlDocument htmldoc = new HtmlAgilityPack.HtmlDocument();
                htmldoc.LoadHtml(htmlstring);

                List<string> hrefTags = new List<string>();
                foreach (HtmlNode link in htmldoc.DocumentNode.SelectNodes("//a[@href]"))
                {
                    HtmlAttribute att = link.Attributes["href"];
                    hrefTags.Add(att.Value); //linklerimizi alıyoruz
                }
                liste.AddRange(altDerinligeIn(hrefTags, j));
            }
       //     yuhAqIkıncıDerinlik.AddRange(ikinciDerinlikGeliyoBaba(liste));
            //Öylesine yazdım
        }

        public List<string> altDerinligeIn(List<string> hrefTags, int k)
        {
            List<string> dogruLinkler = new List<string>();
            List<bool> deneme = new List<bool>();
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
        /*
        public List<string> ikinciDerinlikGeliyoBaba(List<string> linkler)
        {
            List<string> linkListesi = new List<string>();
            List<bool> deneme = new List<bool>();
            string htmlstring;
            Htmlİslemleri Cek_veri = new Htmlİslemleri();
            for (int i = 0; i < linkler.Count; i++)
            {

                htmlstring = Cek_veri.GetVeri(linkler[i]);
                HtmlAgilityPack.HtmlDocument htmldoc = new HtmlAgilityPack.HtmlDocument();
                htmldoc.LoadHtml(htmlstring);

                List<string> hrefTags = new List<string>();
                if (htmldoc.DocumentNode.SelectNodes("//a[@href]") != null)
                {
                    foreach (HtmlNode link in htmldoc.DocumentNode.SelectNodes("//a[@href]"))
                    {
                        HtmlAttribute att = link.Attributes["href"];
                        hrefTags.Add(att.Value);
                    }
                    for (int b = 0; b < hrefTags.Count; b++)
                    {
                        deneme.Add(hrefTags[b].StartsWith(linkler[i]));
                    }
                    for (int j = 0; j < deneme.Count; j++)
                    {
                        if (deneme[j] == true)
                        {
                            linkListesi.Add(hrefTags[j]);

                        }
                    }
                }
                else continue;
              

              
            }
            return linkListesi;
        }
        */
    }
}