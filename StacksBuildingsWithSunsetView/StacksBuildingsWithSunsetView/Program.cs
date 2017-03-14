using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksBuildingsWithSunsetView
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = BuildingsWithSunset(new List<int>() { 2, 1, 7, 3, 6, 5, 1 });
        }

        public static List<int> BuildingsWithSunset(List<int> a)
        {
            var s = new Stack<int>();
            foreach (var i in a)
            {
                while (s.Count > 0 && s.Peek() < i)
                {
                    s.Pop();
                }
                s.Push(i);
            }

            return s.ToList();
        }
    }
}
