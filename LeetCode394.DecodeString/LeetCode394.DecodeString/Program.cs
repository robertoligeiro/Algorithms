using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode394.DecodeString
{
    class Program
    {
        //https://leetcode.com/problems/decode-string/description/
        //not passing all testcases
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = string.Empty;
            //r = s.DecodeString("3[a]2[bc]");
            //r = s.DecodeString("3[a2[c]]");
            r = s.DecodeString("2[abc]3[cd]ef");
            //r = s.DecodeString("sd2[f2[e]g]i");
            //r = s.DecodeString("2[abc]xyc3[z]");
        }

        public class Token
        {
            public string prefix;
            public string postfix;
            public int count;
            public bool hasPrefixSet;
            public List<Token> children = new List<Token>();
        }
        public class Solution
        {
            public string DecodeString(string s)
            {
                var root = new Token();
                var curr = root;
                var q = new Stack<Token>();
                var count = 0;
                var sToken = new StringBuilder();
                for (int i = 0; i < s.Length; ++i)
                {
                    if (char.IsDigit(s[i]))
                    {
                        var sNum = new StringBuilder();
                        while (i < s.Length && char.IsDigit(s[i]))
                        {
                            sNum.Append(s[i++]);
                        }
                        i--;
                        count = int.Parse(sNum.ToString());
                    }
                    if (char.IsLetter(s[i]))
                    {
                        sToken.Clear();
                        while (i < s.Length && char.IsLetter(s[i]))
                        {
                            sToken.Append(s[i++]);
                        }
                        i--;
                    }
                    if (s[i] == '[')
                    {
                        q.Push(curr);
                        if (curr.prefix == null)
                        {
                            curr.prefix = sToken.ToString();
                            curr.hasPrefixSet = true;
                        }
                        else
                        {
                            curr.postfix = sToken.ToString();
                        }
                        sToken.Clear();

                        curr.children.Add(new Token());
                        curr = curr.children.Last();
                        curr.count = count;
                        count = 0;
                    }
                    else if(s[i] == ']')
                    {
                        if (curr.prefix == null)
                        {
                            curr.prefix = sToken.ToString();
                            curr.hasPrefixSet = true;
                        }
                        else
                        {
                            curr.postfix = sToken.ToString();
                        }
                        sToken.Clear();
                        curr = q.Pop();
                    }
                }

                root.postfix = string.IsNullOrEmpty(root.postfix) ? sToken.ToString() : root.postfix;
                var resp = new StringBuilder();
                GetChildren(root, resp);
                return resp.ToString();
            }

            public void GetChildren(Token c, StringBuilder sb)
            {
                sb.Append(c.prefix);
                foreach (var child in c.children)
                {
                    for (int i = 0; i < child.count; ++i)
                    {
                        GetChildren(child, sb);
                    }
                }
                sb.Append(c.postfix);
            }
        }

        public class Solution1
        {
            public string DecodeString(string s)
            {
                var resp = new StringBuilder();
                var sbnum = new StringBuilder();
                var sbchar = new StringBuilder();
                var stackNums = new Stack<int>();
                var stackString = new Stack<string>();
                var prefix = new StringBuilder();
                for (int i = 0; i < s.Length; ++i)
                {
                    if (s[i] >= '0' && s[i] <= '9')
                    {
                        if (sbchar.Length > 0)
                        {
                            stackNums.Push(int.Parse(sbnum.ToString()));
                            stackString.Push(sbchar.ToString());
                            sbnum.Clear();
                            sbchar.Clear();
                        }
                        sbnum.Append(s[i]);
                    }
                    else if(s[i] != ']' && s[i] != '[')
                    {
                        if (sbnum.Length == 0) prefix.Append(s[i]);
                        else
                            sbchar.Append(s[i]);
                    }
                    else if(s[i] == ']' && sbnum.Length > 0)
                    {
                        stackNums.Push(int.Parse(sbnum.ToString()));
                        stackString.Push(sbchar.ToString());
                        sbnum.Clear();
                        sbchar.Clear();

                        var parc = new StringBuilder();
                        while (stackNums.Count > 0)
                        {
                            var n = stackNums.Pop();
                            var c = stackString.Pop();
                            var temp = new StringBuilder();
                            while (n-- > 0)
                            {
                                temp.AppendFormat("{0}{1}", c, parc);
                            }
                            parc = temp;
                        }
                        resp.AppendFormat("{0}{1}", prefix, parc);
                        prefix.Clear();
                    }
                }
                return resp.ToString()+prefix.ToString();
            }
        }
    }
}
