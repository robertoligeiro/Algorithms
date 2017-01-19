using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramingScoreCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = GetNumberScoreCombinations(12, new List<int>() { 2, 3, 7});
        }

        public static int GetNumberScoreCombinations(int score, List<int> scoreValues)
        {
            var resp = new int[score + 1];
            resp[0] = 1;
            foreach (var val in scoreValues)
            {
                for (int i = val; i <= score; ++i)
                {
                    resp[i] += resp[i - val];
                }
            }

            return resp[score];
        }
    }
}
