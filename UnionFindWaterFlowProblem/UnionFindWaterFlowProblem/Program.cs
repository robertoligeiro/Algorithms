using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionFindWaterFlowProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[5, 5];
            matrix[0, 3] = 1;
            matrix[1, 4] = 1;
            matrix[2, 3] = 1;
            matrix[3, 4] = 1;
            matrix[4, 3] = 1;

            var r = WaterFlow.CheckFlow(matrix);
        }

        public class WaterFlow
        {
            public static bool CheckFlow(int[,] matrix)
            {
                // +2 is the virtual nodes
                var unionFind = new WeightedQuickUnionUF(matrix.Length + 2);

                // conects virtual nodes to top/bottom borders
                for (int col = 0; col < matrix.GetLength(0); ++col)
                {
                    int q = GetUnionFindIndexForMatrix(0, col, matrix.GetLength(0));
                    unionFind.Union(0, q);
                    q = GetUnionFindIndexForMatrix(matrix.GetLength(0) - 1, col, matrix.GetLength(0));
                    unionFind.Union(matrix.Length + 1, q);
                }

                for (int row = 0; row < matrix.GetLength(0); ++row)
                {
                    for (int col = 0; col < matrix.GetLength(1); ++col)
                    {
                        if (matrix[row, col] == 1)
                        {
                            int p = GetUnionFindIndexForMatrix(row, col, matrix.GetLength(0));
                            int q = -1;
                            //row-1, col+1
                            if (row - 1 >= 0 && col + 1 < matrix.GetLength(1) && matrix[row - 1, col + 1] == 1)
                            {
                                q = GetUnionFindIndexForMatrix(row - 1, col + 1, matrix.GetLength(0));
                                unionFind.Union(p, q);
                            }
                            //row, col + 1
                            if (col + 1 < matrix.GetLength(1) && matrix[row, col + 1] == 1)
                            {
                                q = GetUnionFindIndexForMatrix(row, col + 1, matrix.GetLength(0));
                                unionFind.Union(p, q);
                            }
                            //row+1, col+1
                            if (row + 1 < matrix.GetLength(0) && col + 1 < matrix.GetLength(1) && matrix[row + 1, col + 1] == 1)
                            {
                                q = GetUnionFindIndexForMatrix(row + 1, col + 1, matrix.GetLength(0));
                                unionFind.Union(p, q);
                            }
                            //row+1, col
                            if (row + 1 < matrix.GetLength(0) && matrix[row + 1, col] == 1)
                            {
                                q = GetUnionFindIndexForMatrix(row + 1, col, matrix.GetLength(0));
                                unionFind.Union(p, q);
                            }
                        }
                    }
                }

                return unionFind.Connected(0, matrix.Length + 1);
            }

            public static int GetUnionFindIndexForMatrix(int row, int col, int countRows)
            {
                return (countRows * row) + col + 1;
            }
        }

        public class WeightedQuickUnionUF
        {
            public int[] id;
            public int[] size;
            public WeightedQuickUnionUF(int n)
            {
                id = new int[n];
                size = new int[n];
                for (int i = 0; i < n; ++i)
                {
                    id[i] = i;
                }
            }
            public bool Connected(int p, int q)
            {
                return Root(p) == Root(q);
            }
            public void Union(int p, int q)
            {
                int i = Root(p);
                int j = Root(q);
                if (size[i] < size[j])
                {
                    id[i] = j;
                    size[j] += size[i];
                }
                else
                {
                    id[j] = i;
                    size[i] += size[j];
                }
            }
            private int Root(int i)
            {
                while (i != id[i])
                {
                    id[i] = id[id[i]]; // path compression
                    i = id[i];
                }

                return i;
            }
        }
    }
}
