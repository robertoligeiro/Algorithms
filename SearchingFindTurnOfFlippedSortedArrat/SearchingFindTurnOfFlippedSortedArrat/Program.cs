using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingFindTurnOfFlippedSortedArrat
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = FindTurn(new List<int> { 5,6,7,8,9,1,2,3,4}); //5
            r = FindTurn(new List<int> { 5, 1, 2, 3, 4 }); //1
            r = FindTurn(new List<int> { 5, 6, 7, 8, 9, 1 }); //5
        }

        public static int FindTurn(List<int> a)
        {
            var l = 0;
            var r = a.Count - 1;
            while (l < r)
            {
                var mid = l + (r - l) / 2;
                if (a[mid] > a[r])
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid;
                }
            }
            return r;
        }
    }
}
