using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyFindMajorityElement
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = MajorityElement(new List<char>() { 'b', 'a', 'c', 'a', 'a', 'b', 'a', 'a', 'c', 'a' });
        }

        public static char MajorityElement(List<char> a)
        {
            var count = 1;
            char element = a[0];
            for(int i = 1; i < a.Count; ++i)
            {
                if (a[i] == a[i - 1])
                {
                    count++;
                }
                else
                {
                    if (--count == 0)
                    {
                        element = a[i];
                        count = 1;
                    }
                }
            }

            return element;
        }
    }
}
