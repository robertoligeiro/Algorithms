using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionGenerateAllWellFormedParens
{
    class Program
    {
        static void Main(string[] args)
        {
            var rBook = BookSolution(5);
        }


        public static List<string> BookSolution(int n_pairs)
        {
            var result = new List<string>();
            BookSolutionRecursion(n_pairs, n_pairs, "", result);
            return result;
        }

        public static void BookSolutionRecursion(int l_needed, int r_needed, string prefix, List<string> r)
        {
            if (l_needed == 0 && r_needed == 0)
            {
                r.Add(prefix);
                return;
            }

            if (l_needed > 0)
            {
                BookSolutionRecursion(l_needed - 1, r_needed, prefix + "(", r);
            }
            if (l_needed < r_needed)
            {
                BookSolutionRecursion(l_needed, r_needed - 1, prefix + ")", r);
            }
        }
    }
}
