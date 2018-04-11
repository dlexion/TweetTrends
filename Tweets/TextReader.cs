using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tweets
{
    class TextReader
    {
        static public Text Read(string str)
        {
            List<char> chars = new List<char>();
            List<Word> words = new List<Word>();
            List<Sentence> sentences = new List<Sentence>();

            using (StringReader sr = new StringReader(str))
            {
                while (sr.Peek() >= 0)
                {
                    char readed = (char)sr.Read();

                    if (Char.IsLetterOrDigit(readed) || readed == '\'' || readed == '-')
                    {
                        chars.Add(readed);
                    }
                    else if (chars.Count > 0)
                    {
                        if (!Char.IsWhiteSpace(readed))
                        {
                            words.Add(new Word(String.Join("", chars), readed));
                        }
                        else
                        {
                            words.Add(new Word(String.Join("", chars)));
                        }
                        chars.Clear();

                        if (readed == '.' || readed == '?' || readed == '!' || readed == ';')
                        {
                            sentences.Add(new Sentence(words));
                            words.Clear();
                        }
                    }
                }
                if (chars.Count > 0)
                {
                    words.Add(new Word(String.Join("", chars)));
                    chars.Clear();
                }
                if (words.Count > 0)
                {
                    sentences.Add(new Sentence(words));
                    words.Clear();
                }

                return new Text(sentences);
            }
        }
    }
}
