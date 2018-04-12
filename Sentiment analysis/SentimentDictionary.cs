using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentiment_analysis
{
    class SentimentDictionary
    {
        private string path;
        private Dictionary<string, double> dictionary;

        public SentimentDictionary(string path)
        {
            this.path = path;
            dictionary = new Dictionary<string, double>();
        }

        public void Read()
        {
            using (var parser = new TextFieldParser(path))
            {
                parser.HasFieldsEnclosedInQuotes = false;
                parser.Delimiters = new[] { "," };
                while (parser.PeekChars(1) != null)
                {
                    string[] fields = parser.ReadFields();
                    dictionary.Add(fields[0], Convert.ToDouble(fields[1].Replace('.', ',')));
                }
            }
        }

        public int Count()
        {
            return dictionary.Count;
        }

        public bool ContainsSubstring(string substring)
        {
            foreach (var keys in dictionary.Keys)
            {
                if (keys.Contains(substring))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContainsKey(string key)
        {
            return dictionary.ContainsKey(key);
        }
    }
}
