using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode301.Remove_Invalid_Parentheses
{
    class Program
    {
        //https://leetcode.com/problems/remove-invalid-parentheses/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.RemoveInvalidParentheses("()())()(");
//            var r = s.RemoveInvalidParentheses(")(");
            //var r = s.RemoveInvalidParentheses("((");
        }
        public class Solution
        {
            public IList<string> RemoveInvalidParentheses(string s)
            {
				// count how many left and right par it's needed to remove
				var removeLeft = 0;
				var removeRight = 0;
				foreach (var c in s)
				{
					if (c == '(') removeLeft++;
					else if(c == ')')
					{
						if (removeLeft == 0) removeRight++;
						else removeLeft--;
					}
				}

				// dfs to get the removed using a hash to avoid dups
				var resp = new HashSet<string>();
				DfsRemovePar(s, 0, removeLeft, removeRight, resp, string.Empty, 0);
				return resp.ToList();
            }

			public void DfsRemovePar(string s, int index, int removeLeft, int removeRight, HashSet<string> resp, string parc, int isOpen)
			{
				if (removeLeft < 0 || removeRight < 0 || isOpen < 0) return;
				if (index == s.Length)
				{
					if (removeLeft == 0 && removeRight == 0 && isOpen == 0)
					{
						resp.Add(parc);
					}
					return;
				}
				if (s[index] == '(')
				{
					//add the open par
					DfsRemovePar(s, index + 1, removeLeft, removeRight, resp, parc + "(", isOpen + 1);
					//don't add the open par
					DfsRemovePar(s, index + 1, removeLeft - 1, removeRight, resp, parc, isOpen);
				}else
				if (s[index] == ')')
				{
					//add the open par
					DfsRemovePar(s, index + 1, removeLeft, removeRight, resp, parc + ")", isOpen - 1);
					//don't add the open par
					DfsRemovePar(s, index + 1, removeLeft, removeRight - 1, resp, parc, isOpen);
				}else
					DfsRemovePar(s, index + 1, removeLeft, removeRight, resp, parc + s[index], isOpen);
			}
		}
    }
}
