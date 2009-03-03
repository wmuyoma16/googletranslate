// LanguageGT.cs created with MonoDevelop
// User: dark_ai at 11:44 03.03.2009
//
// To change standard headers go to Edit->Preferences->Coding->Standard Headers
//

using System;
using System.Xml;
using GoogleTranslate;

namespace Translate
{
	
	
	public class LanguageGT
	{
		
		public LanguageGT(string path)
		{
			Load(path);
		}
			private string _windowTitle;
			private string[] _languages;
			private string _translateBut;
			
		public void Load(string path)
		{
			XmlDocument doc = new XmlDocument();
			try
			{	
				doc.Load(path);
				this._windowTitle = doc.GetElementsByTagName("WindowTitle")[0].InnerText;
				this._translateBut = doc.GetElementsByTagName("TranslateButton")[0].InnerText;
				this._languages = new String[GTranslate.SupportLanguages.Length];
				int i=0;				
				foreach(string lg in GTranslate.SupportLanguages)
				{
					this._languages[i] = doc.GetElementsByTagName(lg)[0].InnerText;					
					i++;
				}
			}
			catch
			{
					Console.Write("Error: Can't load language file" + path +" . Bad format?");
			}
			
		}
		
		public string WindowTitle
			{
				get
				{
					return _windowTitle;
				}
			}
			public string ButtonText
			{
				get
				{
					return _translateBut;
				}
			}
			public string[] Languages
			{
				get
				{
					return _languages;
				}
		}
		
	}
}
