using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctciUrlify
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = Urlify("roberto and flaviana    ", 19);
        }

        public static string Urlify(string s, int len)
        {
            var a = s.ToCharArray();
            var countSpaces = 0;
            for (int i = 0; i <= len; ++i)
            {
                if (a[i] == ' ') countSpaces++;
            }

            for (int i = a.Length - 1; i >= 0; --i)
            {
                if (a[len] != ' ') a[i] = a[len];
                else
                {
                    a[i] = '0';
                    a[--i] = '2';
                    a[--i] = '%';
                }
                len--;
            }

            return new string(a);
        }
    }
}
