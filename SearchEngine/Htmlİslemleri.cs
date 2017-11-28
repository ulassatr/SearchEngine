using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace SearchEngine
{
    public class Htmlİslemleri
    {

        public string GetVeri(string url)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new WebClient { Encoding = System.Text.Encoding.UTF8 };

            String htmlz = client.DownloadString(url);

            String html = HttpUtility.HtmlDecode(htmlz).ToString();

            return html;
           
        }
        public int FindWord(string metin,string kelime)
        {
            int sayac = 0;
                        
            string yeniMetin = metin.ToLower();

            int konum = yeniMetin.IndexOf(kelime);

            while (konum != -1)
            {
                konum = yeniMetin.IndexOf(kelime, konum + 1);

                sayac++;

            }
            return sayac;

        }
        public void UrlSırala()
        {



        }
    }
}