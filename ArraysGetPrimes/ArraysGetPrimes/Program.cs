using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysGetPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = GetPrimes(25);
        }

        public static List<int> GetPrimes(int n)
        {
            var isPrime = Enumerable.Repeat(true, n+1).ToArray();
            var r = new List<int>();
            for (int i = 2; i <= n; ++i)
            {
                if (isPrime[i])
                {
                    r.Add(i);
                    RemoveMultiples(isPrime, i);
                }
            }

            return r;
        }

        public static void RemoveMultiples(bool[] a, int p)
        {
            for (int i = p + p; i < a.Length; i += p)
            {
                a[i] = false;
            }
        }
    }
}
