﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode60.PermutationSequence
{
    //https://leetcode.com/problems/permutation-sequence/#/description
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.GetPermutation(8, 20545);
        }

		//same as solution1, but with some small optmizations.
		public class Solution
		{
			public string GetPermutation(int n, int k)
			{
				var values = Enumerable.Repeat(1, n).ToList();
				var parc = new List<int>();
				GetPermutations(values, parc, ref k);
				return string.Join("", parc);
			}

			public void GetPermutations(List<int> values, List<int> parc, ref int k)
			{
				if (parc.Count == values.Count)
				{
					--k;
					return;
				}

				for (int i = 0; i < values.Count; ++i)
				{
					if (values[i] == 1)
					{
						values[i] = 0;
						parc.Add(i + 1);
						GetPermutations(values, parc, ref k);
						if (k == 0) return;
						values[i] = 1;
						parc.RemoveAt(parc.Count - 1);
					}
				}
			}
		}

		public class Solution1
        {
            public string GetPermutation(int n, int k)
            {
                var values = Enumerable.Repeat(1, n).ToList();
                var resp = new List<List<int>>();
                var parc = new List<int>();
                GetPermutations(values, parc, resp, k);
                return string.Join("", resp.Last());
            }

            public void GetPermutations(List<int> values, List<int> parc, List<List<int>> resp, int k)
            {
                if (parc.Count == values.Count)
                {
                    resp.Add(new List<int>(parc));
                    return;
                }

                var lParc = new List<int>(parc);
                for (int i = 0; i < values.Count; ++i)
                {
                    if (values[i] == 1)
                    {
                        values[i] = 0;
                        lParc.Add(i+1);
                        GetPermutations(values, lParc, resp, k);
                        values[i] = 1;
                        lParc.RemoveAt(lParc.Count - 1);
                        if (resp.Count == k) return;
                    }
                }
            }
        }
    }
}
