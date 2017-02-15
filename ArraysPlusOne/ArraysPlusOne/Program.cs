using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysPlusOne
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = PlusOne(new List<int>() { 9, 9, 9 });
            var b = PlusOne(new List<int>() { 0,9});
        }

        public static List<int> PlusOne(List<int> a)
        {
            int sum = 1;
            for (int i = a.Count - 1; i >= 0; --i)
            {
                sum += a[i];
                if (sum % 10 == 0)
                {
                    a[i] = 0;
                    sum = 1;
                }
                else
                {
                    a[i] = sum;
                    sum = 0;
                    break;
                }
            }

            if (sum == 1)
            {
                var r = new List<int>();
                r.Add(1);
                r.AddRange(a);
                return r;
            }
            return a;
        }
    }
}
