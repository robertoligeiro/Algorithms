using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingSalaryCap
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = CalcSalaryCap(new List<int>() { 90, 30, 100, 40, 20 }, 210);
        }

        public static int CalcSalaryCap(List<int> salaries, int target)
        {
            salaries.Sort();
            var prevPayRoll = salaries.Sum();
            if (prevPayRoll <= target) return salaries.LastOrDefault();

            var mult = 1;
            var cap = salaries.LastOrDefault();
            salaries.RemoveAt(salaries.Count - 1);
            while (salaries.Count > 0)
            {
                if (cap == salaries.LastOrDefault())
                {
                    mult++;
                    salaries.RemoveAt(salaries.Count - 1);
                }
                cap--;
                prevPayRoll -= mult;
                if (prevPayRoll == target) return cap;
            }

            return -1;
        }
    }
}
