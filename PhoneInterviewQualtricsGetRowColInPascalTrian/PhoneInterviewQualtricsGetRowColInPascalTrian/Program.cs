using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*

Pascal's Triangle 

        1
       1 1
      1 2 1
     1 3 3 1
    1 4 6 4 1

Rules:
- elements on the edge are always 1 
- everything else is sum of two elements above 

   0 1 2 3
0: 1
1: 1 1
2: 1 2 1
3: 1 3 3 1
4: 1 4 6 4 1

*/

namespace PhoneInterviewQualtricsGetRowColInPascalTrian
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = GetValueInPascalTriangle(4, 2); // expect: 6
        }

        public static int GetValueInPascalTriangle(int row, int col)
        {
            if (row < 0 || col < 0) return -1;
            var triangle = BuildPascalTriangle(row);
            if (col > triangle[row].Count) return -1;
            return triangle[row][col];
        }

        public static List<List<int>> BuildPascalTriangle(int row)
        {
            var triangle = new List<List<int>>() { new List<int>() { 1 } };
            for (int i = 1; i <= row; ++i)
            {
                var rowTriangle = new List<int>();
                for (int j = 0; j <= triangle[i - 1].Count; ++j)
                {
                    if (j == 0 || j == triangle[i - 1].Count)
                    {
                        rowTriangle.Add(1);
                    }
                    else
                    {
                        rowTriangle.Add(triangle[i - 1][j] + triangle[i - 1][j - 1]);
                    }
                }
                triangle.Add(rowTriangle);
            }
            return triangle;
        }
    }
}
