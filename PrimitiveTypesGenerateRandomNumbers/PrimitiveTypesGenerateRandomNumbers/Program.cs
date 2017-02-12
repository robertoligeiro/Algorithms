using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimitiveTypesGenerateRandomNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new List<int>();
            l = Enumerable.Range(1, 10).ToList();
            GenerateRandom(l);
        }

        public static void GenerateRandom(List<int> a)
        {
            int len = a.Count;
            var rand = new Random();
            for (int i = 0; i < len; ++i)
            {
                int r = rand.Next(0, i + 1);
                int t = a[i];
                a[i] = a[r];
                a[r] = t;
            }
        }
    }
}
