using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsReverseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "Roberto Foda";
            ReverseWordsRaw(ref s);
            ReverseWordsNutella(ref s);
        }

        public static void ReverseWordsRaw(ref string s)
        {
            var startW = 0;
            var sArray = s.ToArray();
            for (int i = 0; i <= s.Length; ++i)
            {
                if (i < s.Length && sArray[i] != ' ') continue;
                var endW = i - 1;
                while (startW < endW)
                {
                    var t = sArray[startW];
                    sArray[startW] = sArray[endW];
                    sArray[endW] = t;
                    startW++;
                    endW--;
                }

                startW = i + 1;
            }

            s = new string(sArray);
        }

        public static void ReverseWordsNutella(ref string s)
        {
            var sWords = s.Split(' ');

            for(int i = 0; i < sWords.Count(); ++i)
            {
                sWords[i] = new string(sWords[i].Reverse().ToArray());
            }

            s = string.Join(" ", sWords);
        }
    }
}
