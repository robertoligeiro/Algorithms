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
//            var r = s.RemoveInvalidParentheses("()())()(");
//            var r = s.RemoveInvalidParentheses(")(");
            var r = s.RemoveInvalidParentheses("((");
        }
        public class Solution
        {
            public IList<string> RemoveInvalidParentheses(string s)
            {
                var sPar = new Stack<Tuple<char, int>>();
                for (int i = 0; i < s.Length; ++i)
                {
                    if (s[i] == ')')
                    {
                        if (sPar.Count > 0 && sPar.Peek().Item1 == '(') sPar.Pop();
                        else sPar.Push(new Tuple<char, int>(')', i));
                    }
                    else if (s[i] == '(')
                    {
                        sPar.Push(new Tuple<char, int>('(', i));
                    }
                    else continue;
                }
                if (sPar.Count == 0) return new List<string>() { s };

                var remove = new List<HashSet<int>>();
                foreach(var t in sPar.Reverse())
                {
                    if (t.Item1 == ')') RemoveClose(s, t.Item2, remove);
                    else RemoveOpen(s, t.Item2, remove);
                }
                var resp = new List<string>();

                foreach (var h in remove)
                {
                    var sb = new StringBuilder();
                    for (int i = 0; i < s.Length; ++i)
                    {
                        if (!h.Contains(i)) sb.Append(s[i]);
                    }
                    if(sb.Length % 2 == 0) resp.Add(sb.ToString());
                }
                return resp;
            }

            private void RemoveClose(string s, int pos, List<HashSet<int>> remove)
            {
                int count = 0;
                for (int i = pos - 1; i >= 0; --i)
                {
                    if (s[i] == ')')
                    {
                        if (remove.Count == count)
                        {
                            remove.Add(new HashSet<int>() { i });
                            count++;
                        }
                        else
                        {
                            if (remove[count].Add(i)) count++;
                        }
                    }
                }
                if (count == 0)
                {
                    if (remove.Count == 0)
                    {
                        remove.Add(new HashSet<int>() { pos });
                    }
                    else
                    {
                        foreach (var h in remove)
                        {
                            h.Add(pos);
                        }
                    }
                }
            }

            private void RemoveOpen(string s, int pos, List<HashSet<int>> remove)
            {
                int count = 0;
                for (int i = pos + 1; i < s.Length; ++i)
                {
                    if (s[i] == '(')
                    {
                        if (remove.Count == count)
                        {
                            remove.Add(new HashSet<int>() { i });
                            count++;
                        }
                        else
                        {
                            if (remove[count].Add(i)) count++;
                        }
                    }
                }
                if (count == 0)
                {
                    if (remove.Count == 0)
                    {
                        remove.Add(new HashSet<int>() { pos });
                    }
                    else
                    {
                        foreach (var h in remove)
                        {
                            h.Add(pos);
                        }
                    }
                }
            }
        }
    }
}
