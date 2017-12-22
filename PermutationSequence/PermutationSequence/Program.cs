using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutationSequence
{
	class Program
	{
		static void Main(string[] args)
		{
			var r = GetPermutSequence(3, 1);
			r = GetPermutSequence(3, 2);
			r = GetPermutSequence(3, 3);
			r = GetPermutSequence(3, 6);
			r = GetPermutSequence(5, 1);
			r = GetPermutSequence(5, 10);
		}

		public static List<int> GetPermutSequence(int n, int k)
		{
			var source = Enumerable.Repeat(1, n).ToList();
			var resp = new List<int>();
			GetPermutSequence(n, ref k, source, resp);
			return resp;
		}

		public static void GetPermutSequence(int n, ref int k, List<int> source, List<int> resp)
		{
			if (resp.Count == n)
			{
				--k;
				return;
			}

			for (int i = 0; i < source.Count; ++i)
			{
				if (source[i] == 1)
				{
					source[i] = 0;
					resp.Add(i+1);
					GetPermutSequence(n, ref k, source, resp);
					source[i] = 1;
					if (k != 0)
					{
						resp.RemoveAt(resp.Count - 1);
					}
					else return;
				}
			}
		}
	}
}
