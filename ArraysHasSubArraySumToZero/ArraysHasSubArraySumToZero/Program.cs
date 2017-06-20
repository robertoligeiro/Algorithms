using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysHasSubArraySumToZero
{
    //https://www.youtube.com/watch?v=hLcYp67wCcM&t=815s
    class Program
    {
        static void Main(string[] args)
        {
            var a = HasSubArraySumToZero(new List<int>() { 4,1,2,-3,2,-5});
            var b = HasSubArraySumToZero(new List<int>() { 4, 1, 2, -9, 1, 1 });
            var c = HasSubArraySumToZero(new List<int>() { 4, 1, 2, -1, 2, -5 });
        }

        public static Tuple<int, int> HasSubArraySumToZero(List<int> a)
        {
            var acc = 0;
            var m = new Dictionary<int, int>();
            for (int i = 0; i <= a.Count; ++i)
            {
                var index = 0;
                if (m.TryGetValue(acc, out index))
                {
                    return new Tuple<int, int>(index, i - 1);
                }
                else m.Add(acc, i);

                if (i < a.Count)
                {
                    acc += a[i];
                }
            }

            return new Tuple<int, int>(-1,-1);
        }
    }
}
