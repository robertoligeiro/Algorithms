using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode421.MaximumXORofTwoNumbersinArray
{
	//https://leetcode.com/problems/maximum-xor-of-two-numbers-in-an-array/tabs/description
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.findMaximumXOR(new int[] { 3, 5, 7 });
			//var r = s.findMaximumXOR(new int[] { 3, 10, 5, 25, 2, 8 });
		}

		public class Solution
		{
			public class TrieNode
			{
				public TrieNode[] children = new TrieNode[2];
			}

			public class Trie
			{
				private TrieNode root = new TrieNode();
				public void AddNum(int n)
				{
					var curr = this.root;
					for (int i = 31; i >=0; --i)
					{
						long bit = 1;
						bit <<= i;
						int currBit = n & (int)bit;						currBit = currBit != 0 ? 1 : 0;						if (curr.children[currBit] == null)
						{
							curr.children[currBit] = new TrieNode();
						}
						curr = curr.children[currBit];
					}
				}

				public int GetXor(int n)
				{
					var curr = this.root;
					var result = 0;
					for (int i = 31; i >= 0; --i)
					{
						long bit = 1;
						bit <<= i;
						int currBit = n & (int)bit;						var child= currBit != 0 ? 1 : 0;						if (curr.children[child^1] != null)
						{
							result += (int)bit;
							curr = curr.children[child^1];
						}
						else 	curr = curr.children[child];
					}
					return result;
				}
			}

			public int findMaximumXOR(int[] nums)
			{
				var t = new Trie();
				foreach (var i in nums)
				{
					t.AddNum(i);
				}
				var max = 0;
				foreach (var i in nums)
				{
					max = Math.Max(t.GetXor(i), max);
				}
				return max;
			}
		}
	}
}
