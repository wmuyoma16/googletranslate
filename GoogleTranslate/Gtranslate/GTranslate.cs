using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;

namespace GoogleTranslate
{	
    public enum GLanguages {sq ,ar , bg , ca , zhCN , zhTW  , hr , cs , da , nl , en
                                         , et , tl , fi , fr , gl , de , el , iw , hi , hu , id , it , ja , ko , lv , lt
                                         , mt , no , pl , pt , ro , ru , sr , sk , sl , es , sv , th , tr , uk , vi};
    public class GTranslate
    {
		public static string[] SupportLanguages = new string[]
		         {"sq" ,"ar" , "bg ", "ca" , "zhCN",
				 "zhTW","hr" , "cs" , "da" , "nl" ,
				 "en","et","tl","fi","fr","gl","de",
				 "el","iw","hi","hu" ,"id","it","ja",
				 "ko","lv","lt","mt","no","pl","pt",
				 "ro","ru","sr","sk","sl","es","sv","th","tr","uk","vi"};
		
        private static GLanguages StringToGLanguages(string source)
        {
            switch (source)
            {
                case "Albanian":
                    return GLanguages.sq;
                case "Arabic":
                    return GLanguages.ar;
                case "Bulgarian":
                    return GLanguages.bg;
                case "Catalan":
                    return GLanguages.ca;
                case "Chinese (Simplified)":
                    return GLanguages.zhCN;
                case "Chinese (Traditional)":
                    return GLanguages.zhTW;
                case "Croatian":
                    return GLanguages.hr;
                case "Czech":
                    return GLanguages.cs;
                case "Danish":
                    return GLanguages.da;
                case "Dutch":
                    return GLanguages.nl;
                case "English":
                    return GLanguages.en;
                case "Estonian":
                    return GLanguages.et;
                case "Filipino":
                    return GLanguages.tl;
                case "Finnish":
                    return GLanguages.fi;
                case "French":
                    return GLanguages.fr;
                case "Galician":
                    return GLanguages.gl;
                case "German":
                    return GLanguages.de;
                case "Greek":
                    return GLanguages.el;
                case "Hebrew":
                    return GLanguages.iw;
                case "Hindi":
                    return GLanguages.hi;
                case "Hungarian":
                    return GLanguages.hu;
                case "Indonesian":
                    return GLanguages.id;
                case "Italian":
                    return GLanguages.it;
                case "Japanese":
                    return GLanguages.ja;
                case "Korean":
                    return GLanguages.ko;
                case "Latvian":
                    return GLanguages.lv;
                case "Lithuanian":
                    return GLanguages.lt;
                case "Maltese":
                    return GLanguages.mt;
                case "Norwegian":
                    return GLanguages.no;
                case "Polish":
                    return GLanguages.pl;
                case "Portuguese":
                    return GLanguages.pt;
                case "Romanian":
                    return GLanguages.ro;
                case "Russian":
                    return GLanguages.ru;
                case "Serbian":
                    return GLanguages.sr;
                case "Slovak":
                    return GLanguages.sk;
                case "Slovenian":
                    return GLanguages.sl;
                case "Spanish":
                    return GLanguages.es;
                case "Swedish":
                    return GLanguages.sv;
                case "Thai":
                    return GLanguages.th;
                case "Turkish":
                    return GLanguages.tr;
                case "Ukrainian":
                    return GLanguages.uk;
                case "Vietnamese":
                    return GLanguages.vi;                
            }
            return GLanguages.en;
        }
        public static GWords Translate(GLanguages inlang, GLanguages outlang, string trtext)
        {
            string url = "http://www.google.com/translate_a/t?client=t&sl=" + inlang.ToString() + "&tl=" + outlang.ToString();
            StreamReader streamreader = null;
            try
            {
                byte[] bytearr = Encoding.UTF8.GetBytes("text=" +trtext);
                HttpWebRequest trHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                trHttpWebRequest.UserAgent = "Mozilla/5.0";
                trHttpWebRequest.Method = "POST";
                trHttpWebRequest.ContentLength = bytearr.Length;                
                trHttpWebRequest.Headers.Add("Accept-Encoding", "deflate");
                trHttpWebRequest.AllowAutoRedirect = false;
                trHttpWebRequest.GetRequestStream().Write(bytearr, 0, bytearr.Length);
                HttpWebResponse  trHttpWebResponse = (HttpWebResponse)trHttpWebRequest.GetResponse();
                streamreader = new StreamReader(trHttpWebResponse.GetResponseStream(), Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erorr: can't connect www.google.com");
                Console.WriteLine("Description:");
                Console.WriteLine(ex.Message);
                return null;
            }
            return new GWords(streamreader.ReadToEnd());
        }
        public static GWords Translate(string inlang, string outlang, string trtext)
        {
            GLanguages lang1 = StringToGLanguages(inlang);
            GLanguages lang2 = StringToGLanguages(outlang);
			Console.WriteLine(lang2.ToString());
            return Translate(lang1, lang2, trtext);
        }

    }
}
