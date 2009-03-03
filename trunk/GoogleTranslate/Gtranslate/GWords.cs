using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace GoogleTranslate
{
    public class GWords
    {
        public GWords(string s)
        {
            Create(s);
        }
        private string _translate;
        private StringCollection _noun;
        private StringCollection _adjective;
        private StringCollection _adverb;
		private StringCollection _verb;
		private StringCollection _interjection;

        public void Create(string source)
        {
            this._adjective = new StringCollection();
            this._adverb = new StringCollection();
            this._noun = new StringCollection();
			this._verb = new StringCollection();
			this._interjection = new StringCollection();
			
            Regex r = new Regex("(?'group'\\[([^\\[\\]]*?)\\])");//|(?'word'\\\"([^\\\"]*?)\\\")");
            string result = r.Replace(source, new MatchEvaluator(ReplaceText));
            result = result.Remove(result.LastIndexOf('\"'));
            result = result.Remove(0, result.IndexOf('\"') + 1);
            this._translate = result.Replace("\\n","\n");
        }
        private string ReplaceText(Match m)
        {
            string s = m.Groups["group"].Value;
            SplitWords(s);
            return string.Empty;
        }

        private void SplitWords(string s)
        {
            try
            {
                s = s.Remove(0, 2);
                s = s.Remove(s.Length - 2, 2).Replace("\",\"", ",");
                string[] strs = s.Split(',');
                if (strs.Length > 1)
                {
                    switch (strs[0])
                    {
                        case "noun":
                            this._noun.AddRange(strs);
                            this._noun.RemoveAt(0);
                            break;
                        case "adjective":
                            this._adjective.AddRange(strs);
                            this._adjective.RemoveAt(0);
                            break;
                        case "adverb":
                            this._adverb.AddRange(strs);
                            this._adverb.RemoveAt(0);
                            break;
					    case "verb":
							this._verb.AddRange(strs);
						    this._verb.RemoveAt(0);
						    break;
					    case "interjection":
							this._interjection.AddRange(strs);
						    this._interjection.RemoveAt(0);
						    break;
                        default:
						    Console.WriteLine("Unknow words type - " + strs[0]);
                            throw new ExecutionEngineException("Unknow words type");
						    break;
					}
                }
            }
            catch
            {
                Console.WriteLine("Error in class GWords.cs, function SplitWords");
            }
        }

        public string Translate
        {
            get { return _translate; }
        }
        public StringCollection Noun
        {
            get
            {
                if (_noun == null)
                    _noun = new StringCollection();
                return _noun;
            }
        }
        public StringCollection Adjective
        {
            get
            {
                if (_adjective == null)
                    _adjective = new StringCollection();
                return _adjective;
            }
        }
        public StringCollection Adverb
        {
            get
            {
                if (_adverb == null)
                    _adverb = new StringCollection();
                return _adverb;
            }
        }
		public StringCollection Verb
		{
			get
			{
				if (_verb == null)
					_verb = new StringCollection();
				return _verb;
			}
		}
		public StringCollection Interjection
		{
			get
			{
				if (_interjection == null)
					_interjection = new StringCollection();
				return _interjection;
			}
		}
    }
}
