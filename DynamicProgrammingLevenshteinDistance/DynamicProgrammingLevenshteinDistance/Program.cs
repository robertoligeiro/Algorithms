using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://www.youtube.com/watch?v=We3YDTzNXEk
namespace DynamicProgrammingLevenshteinDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            var resp = ComputeLevenshteinDistance("saturday", "sundays");
        }

        public static int ComputeLevenshteinDistance(string a, string b)
        {
            var resp = new int[a.Length+1, b.Length+1];

            for (int i = 1; i < resp.GetLength(0); ++i)
            {
                resp[i,0] = i;
            }
            for (int i = 1; i < resp.GetLength(1); ++i)
            {
                resp[0, i] = i;
            }
            for (int i = 1; i < resp.GetLength(0); ++i)
            {
                for (int j = 1; j < resp.GetLength(1); ++j)
                {
                    if (a[i-1] == b[j-1])
                    {
                        resp[i, j] = resp[i - 1, j - 1];
                    }
                    else
                    {
                        resp[i, j] = Math.Min(resp[i, j - 1], Math.Min(resp[i-1, j-1], resp[i-1,j])) + 1;
                    }
                }
            }

            return resp[a.Length, b.Length];
        }
    }
}
