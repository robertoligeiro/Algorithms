using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysPascalsTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = PascalsTriangle(5);
        }

        public static List<List<int>> PascalsTriangle(int n)
        {
            var r = new List<List<int>>();
            for (int i = 0; i < n; ++i)
            {
                var l = new List<int>();
                for (int j = 0; j <= i; ++j)
                {
                    int v = 1;
                    if (j > 0 && j < i)
                    {
                        v = r[i - 1][j - 1] + r[i - 1][j];
                    } 
                    l.Add(v);
                }
                r.Add(l);
            }

            return r;
        }
    }
}
