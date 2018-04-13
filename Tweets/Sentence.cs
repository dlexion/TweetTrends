using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tweets
{
    public class Sentence : IComparable<Sentence>
    {
        private List<Word> words;

        public List<Word> Words { get => words; }

        int IComparable<Sentence>.CompareTo(Sentence obj)
        {
            return this.words.Count.CompareTo(obj.words.Count);
        }

        public Sentence(List<Word> list)
        {
            //words = list;
            words = new List<Word>();
            words.AddRange(list);
        }

        int NumberOfWords()
        {
            return words.Count();
        }

        public void Remove(int index)
        {
            words.RemoveAt(index);
        }

        bool IsCorrectLenght(String s, int lenght)
        {
            return s.Length == lenght ? true : false;
        }

        public override string ToString()
        {
            String sentence = String.Empty;
            foreach (Word w in words)
            {
                sentence += w.ToString() + " ";
            }
            return sentence;
        }
    }
}
