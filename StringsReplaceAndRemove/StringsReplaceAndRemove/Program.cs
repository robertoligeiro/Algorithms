using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsReplaceAndRemove
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new char[] { 'a', 'f', 'c', 'd', 'a', 'c', 'b', 'c', 'd'};
            var r = ReplaceRemove(c);
        }

        public static char[] ReplaceRemove(char[] s)
        {
            var nextWrite = 0;
            var countA = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] != 'b')
                {
                    s[nextWrite++] = s[i];
                }

                if (s[i] == 'a')
                {
                    countA++;
                }
            }

            nextWrite--;
            var newSize = nextWrite + countA;
            Array.Resize(ref s, newSize + 1);
            while (nextWrite >= 0)
            {
                if (s[nextWrite] != 'a')
                {
                    s[newSize--] = s[nextWrite];
                }
                else
                {
                    s[newSize--] = 'd';
                    s[newSize--] = 'd';
                }

                nextWrite--;
            }

            return s;
        }
    }
}
