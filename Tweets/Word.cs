using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tweets
{
    class Word
    {
        public String Wd { get; set; }
        public char? Mark { get; set; }

        public Word(String str, char c)
        {
            Wd = str;
            Mark = c;
        }

        public Word(String str)
        {
            Wd = str;
            Mark = null;
        }

        public override string ToString()
        {
            return Wd + Mark;
        }

        public int Lenght()
        {
            return Wd.Length;
        }
    }
}
