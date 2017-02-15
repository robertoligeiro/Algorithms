using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysMultiplyArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = MultiplyArrays(new List<int>() {1,2,3 }, new List<int>() { 3,2});
        }

        public static List<int> MultiplyArrays(List<int> a, List<int> b)
        {
            var parcials = new List<List<int>>();
            int index = 0;
            a.Reverse();
            b.Reverse();
            foreach (var i in a)
            {
                parcials.Add(new List<int>());
                parcials[index].AddRange(Enumerable.Repeat(0, index));
                int rest = 0;
                foreach (var j in b)
                {
                    var mult = i * j + rest;
                    parcials[index].Add(mult % 10);
                    rest = mult > 10 ? mult / 10 : 0;
                }
                index++;
            }

            int count = parcials.LastOrDefault().Count;
            var result = new List<int>();
            int sum = 0;
            for (int i = 0; i < count; ++i)
            {
                foreach (var l in parcials)
                {
                    if(l.Count > i)
                        sum += l[i];
                }

                result.Add(sum % 10);
                sum = sum > 10 ? sum/10 : 0;
            }

            result.Reverse();
            return result;
        }
    }
}
