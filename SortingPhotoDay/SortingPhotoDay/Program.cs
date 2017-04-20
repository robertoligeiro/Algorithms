using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingPhotoDay
{
    class Program
    {
        static void Main(string[] args)
        {
            var l1 = new List<int>() { 4, 3, 5, 6 };
            var l2 = new List<int>() { 7, 8, 10, 9 };
            var b = HasPhoto(l2, l1); //true;

            l1 = new List<int>() { 14, 3, 5, 6 };
            l2 = new List<int>() { 7, 8, 10, 9 };
            b = HasPhoto(l1, l2); //false
        }

        public static bool HasPhoto(List<int> a, List<int> b)
        {
            a.Sort();
            b.Sort();
            var back = a.LastOrDefault() > b.LastOrDefault() ? a : b;
            var front = back == a ? b : a;
            for (int i = back.Count - 1; i >= 0; --i)
            {
                if (back[i] < front[i]) return false;
            }
            return true;
        }
    }
}
