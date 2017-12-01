﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SearchEngine.TagsFolder;
using HtmlAgilityPack;
using System.Text;
namespace SearchEngine
{
    public class UrlPuan:UrlSıralama
    {



              
        public int kelimeSayisi(string html, string aranankelime, Htmlİslemleri Cek_veri, string etiket)
        {

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
                return y;
            }
            return 0;
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
        public List<double> sıralamaPuan(List<string> url, List<string> aranankelime, Htmlİslemleri Cek_veri, string etiket, double puan,HtmlAgilityPack.HtmlDocument htmldoc)
        {

            List<double> etiketPuan = new List<double>();


                              HtmlNodeCollection basliklar = htmldoc.DocumentNode.SelectNodes(etiket);
                for (int j = 0; j < aranankelime.Count; j++)
                {

                    aranankelime[j].ToLower();
                    List<string> liste = new List<string>();
                    if (basliklar != null)
                    {
                        foreach (var baslik in basliklar)
                        {
                            liste.Add(baslik.InnerText);
                        }
                        double kelimeSayisi;
                        string[] stringDizi = new string[liste.Count];

                        for (int k = 0; k < liste.Count; k++)
                        {
                            stringDizi[k] = liste[k].ToString();
                        }

                        string tekstring;
                        tekstring = ConvertStringArrayToString(stringDizi);
                        tekstring = tekstring.ToLower();
                        kelimeSayisi = Cek_veri.FindWord(tekstring, aranankelime[j]);
                        etiketPuan.Add(kelimeSayisi * puan);
                    }
                    else
                        continue;
                }       
            return etiketPuan;

        }
    }
}