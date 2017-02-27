using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsComputePhoneMneumonics
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = ComputeMneumonics(new List<int>() { 2,5,6});
        }

        public static List<string> ComputeMneumonics(List<int> phone)
        {
            var d = new Dictionary<int, string>() { { 2, "abc" }, { 3, "def"}, { 4, "ghi" },
                                                    { 5, "jkl" }, { 6, "mno" }, { 7, "pqrs" },
                                                    { 8, "tuv" }, { 9, "wxyz"}};
            var r = new List<string>();
            Compute(phone, d, r, string.Empty);
            return r;
        }

        public static void Compute(List<int> p, Dictionary<int, string> d, List<string> r, string parc)
        {
            if (p.Count == 0)
            {
                r.Add(new string(parc.ToArray()));
                return;
            }

            var copyP = new List<int>(p);
            var phoneChars = d[copyP[0]];
            copyP.RemoveAt(0);
            foreach (var c in phoneChars)
            {
                parc += c;
                Compute(copyP, d, r, parc);
                parc = parc.Remove(parc.Length - 1, 1);
            }
        }
    }
}
