using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysFindExit
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = FindExit(new List<int>(){ 3,3,1,0,2,0,1});
            var c = FindExit(new List<int>() { 3, 2, 0, 0, 2, 0, 1 });
        }

        public static bool FindExit(List<int> a)
        {
            return FindExit(a, 0);
        }
        public static bool FindExit(List<int> a, int index)
        {
            if (index >= a.Count) return false;
            if (index == a.Count - 1) return true;
            int count = a[index];
            while (count >= 1)
            {
                if (FindExit(a, index + count))
                {
                    return true;
                }
                count--;
            }

            return false;
        }
    }
}
