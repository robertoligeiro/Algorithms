using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode749.Contain_Virus
{
	class Program
	{
		static void Main(string[] args)
		{
			//var b = new int[,] { { 0, 1, 0, 1 }, { 0, 1, 0, 1 }, { 0, 0, 0, 1 } };
			var b = new int[,] { { 1, 1, 1 }, { 1, 0, 1 }, { 1, 1, 1 } };
			var s = new Solution();
			var r = s.ContainVirus(b);
		}

		public class Solution
		{
			public int ContainVirus(int[,] grid)
			{
				var walls = 0;
				var resp = 0;
				while ((walls = DoWalls(grid)) > 0)
				{
					resp += walls;
					DoInfection(grid);
				}
				return resp;
			}

			private int DoWalls(int[,] grid)
			{
				var maxWalls = 0;
				Tuple<int, int> startMaxWalls = null;
				var lenRow = grid.GetLength(0);
				var lenCol = grid.GetLength(1);
				var visited = new bool[lenRow, lenCol];
				for (int row = 0; row < lenRow; ++row)
				{
					for (int col = 0; col < lenCol; ++col)
					{
						if (grid[row, col] == 1 && !visited[row, col])
						{
							var countWalls = CountWalls(grid, visited, row, col);
							if (countWalls > maxWalls)
							{
								maxWalls = countWalls;
								startMaxWalls = new Tuple<int, int>(row,col);
							}
						}
					}
				}

				if (maxWalls>0) BuildTheWall(grid, startMaxWalls.Item1, startMaxWalls.Item2);
				return maxWalls;
			}

			private void BuildTheWall(int[,] grid, int row, int col)
			{
				var q = new Queue<Tuple<int, int>>();
				q.Enqueue(new Tuple<int, int>(row, col));
				var lenRow = grid.GetLength(0);
				var lenCol = grid.GetLength(1);
				var visited = new bool[lenRow, lenCol];
				while (q.Count > 0)
				{
					var t = q.Dequeue();
					if (!visited[t.Item1, t.Item2])
					{
						grid[t.Item1, t.Item2] = -1;
						visited[t.Item1, t.Item2] = true;
						row = t.Item1;
						col = t.Item2;

						if (row - 1 >= 0)
						{
							if (grid[row - 1, col] == 1)
							{
								q.Enqueue(new Tuple<int, int>(row - 1, col));
							}
						}
						if (row + 1 < lenRow)
						{
							if (grid[row + 1, col] == 1)
							{
								q.Enqueue(new Tuple<int, int>(row + 1, col));
							}
						}
						if (col - 1 >= 0)
						{
							if (grid[row, col - 1] == 1)
							{
								q.Enqueue(new Tuple<int, int>(row, col - 1));
							}
						}
						if (col + 1 < lenCol)
						{
							if (grid[row, col + 1] == 1)
							{
								q.Enqueue(new Tuple<int, int>(row, col + 1));
							}
						}
					}
				}

			}
			private int CountWalls(int[,] grid, bool[,]visited, int row, int col)
			{
				var q = new Queue<Tuple<int, int>>();
				q.Enqueue(new Tuple<int, int>(row, col));
				var lenRow = grid.GetLength(0);
				var lenCol = grid.GetLength(1);
				var walls = 0;
				while (q.Count > 0)
				{
					var t = q.Dequeue();
					if (!visited[t.Item1, t.Item2])
					{
						visited[t.Item1, t.Item2] = true;
						row = t.Item1;
						col = t.Item2;
						if (row - 1 >= 0)
						{
							if (grid[row - 1, col] == 0)
							{
								walls++;
							}
							else if (grid[row - 1, col] == 1) q.Enqueue(new Tuple<int, int>(row-1, col));
						}
						if (row + 1 < lenRow)
						{
							if (grid[row + 1, col] == 0)
							{
								walls++;
							}
							else if (grid[row + 1, col] == 1) q.Enqueue(new Tuple<int, int>(row+1, col));
						}
						if (col - 1 >= 0)
						{
							if (grid[row, col - 1] == 0)
							{
								walls++;
							}
							else if (grid[row, col - 1] == 1) q.Enqueue(new Tuple<int, int>(row, col - 1));
						}
						if (col + 1 < lenCol)
						{
							if (grid[row, col + 1] == 0)
							{
								walls++;
							}
							else if (grid[row, col + 1] == 1) q.Enqueue(new Tuple<int, int>(row, col + 1));
						}
					}
				}
				return walls;
			}
			private void DoInfection(int[,] grid)
			{
				var lenRow = grid.GetLength(0);
				var lenCol = grid.GetLength(1);
				var visited = new bool[lenRow, lenCol];
				for (int row = 0; row < lenRow; ++row)
				{
					for (int col = 0; col < lenCol; ++col)
					{
						if (grid[row, col] == 1 && !visited[row, col])
						{
							if (row - 1 >= 0)
							{
								if (grid[row - 1, col] == 0)
								{
									grid[row - 1, col] = 1;
									visited[row - 1, col] = true;
								}
							}
							if (row + 1 < lenRow)
							{
								if (grid[row + 1, col] == 0)
								{
									grid[row + 1, col] = 1;
									visited[row + 1, col] = true;
								}
							}
							if (col - 1 >= 0)
							{
								if (grid[row, col - 1] == 0)
								{
									grid[row, col - 1] = 1;
									visited[row, col - 1] = true;
								}
							}
							if (col + 1 < lenCol)
							{
								if (grid[row, col + 1] == 0)
								{
									grid[row, col + 1] = 1;
									visited[row, col + 1] = true;
								}
							}
						}
					}
				}
			}
		}
	}
}
