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

            Htmlİslemleri Cek_veri = new Htmlİslemleri();
            string html = Cek_veri.GetVeri(url);


            Title title = new Title();
            int y=  title.TagsKelimeSayisi(html, arananKelime, Cek_veri, title.etiket);

         


            //for (int i = 0; i < liste.Count; i++)
            //{
            //    string[i] y = liste[i].ToString();
            //    y[i].ToLower();
            //}
            

            //int sayac = 0;
            //for (int i = 0; i < h1.Length; i++)
            //{

            //    int a = h1[i].IndexOf(aranankelime);
            //    if (a == -1)
            //    {
            //        continue;
            //    }
            //    else
            //        while (a != -1)
            //        {
            //            a = h1[i].IndexOf(aranankelime, a + 1);
            //            sayac++;
            //        }
            //}

            //int a = y.IndexOf(arananKelime);
            //int sayac = 0;
            //while (a != -1)
            //{
            //     a= liste.IndexOf(arananKelime,a+1);

            //    sayac++;

            //}
            int KeyCount=Cek_veri.FindWord(html,arananKelime);
            
        }
       
    }
}
