using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysGenerateRandomPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = GenerateRandomPermutation(10);
        }

        public static List<int> GenerateRandomPermutation(int n)
        {
            var items = Enumerable.Range(0, n).ToList();
            var rand = new Random();
            for (int i = 0; i < n; ++i)
            {
                var index = rand.Next(i, n-1);
                var t = items[i];
                items[i] = items[index];
                items[index] = t;
            }
            return items;
        }
    }
}
