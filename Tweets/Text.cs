using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tweets
{
    class Text
    {
        private List<Sentence> sentences;

        public List<Sentence> Sentences { get => sentences; }

        public Text(List<Sentence> list)
        {
            sentences = list;
        }

        public Text()
        {
            sentences = new List<Sentence>();
        }

        public override string ToString()
        {
            String text = String.Empty;
            foreach (Sentence s in sentences)
            {
                text += s.ToString();
            }
            return text;
        }

        public void Sort()
        {
            sentences.Sort();
        }

        public void Add(List<Sentence> list)
        {
            sentences.AddRange(list);
        }
    }
}
