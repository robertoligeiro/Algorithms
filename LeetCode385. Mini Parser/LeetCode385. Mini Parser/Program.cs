using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode385.Mini_Parser
{
    //https://leetcode.com/problems/mini-parser/description/
    //not fully passing.
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            //var r = s.Deserialize("[123,[456,[789]]]");
            //var r = s.Deserialize("123");
            var r = s.Deserialize("[]");
        }

        public class Solution
        {
            public NestedInteger Deserialize(string s)
            {
                var st = new Stack<NestedInteger>();
                st.Push(new NestedInteger());
                var val = new StringBuilder();
                for (int i = 0; i < s.Length; ++i)
                {
                    if (Char.IsDigit(s[i]))
                    {
                        while ( i < s.Length && Char.IsDigit(s[i]))
                        {
                            val.Append(s[i++]);
                        }
                        st.Peek().SetInteger(int.Parse(val.ToString()));
                        i--;
                        val.Clear();
                    }
                    else
                    {
                        if (s[i] == '[')
                        {
                            st.Peek().Add(new NestedInteger());
                            st.Push(st.Peek().GetList().Last());
                        }
                        else if (s[i] == ']')
                        {
                            var removed = st.Pop();
                        }
                    }
                }
                if (val.Length > 0)
                {
                    st.Peek().SetInteger(int.Parse(val.ToString()));
                }
                if (!st.Peek().IsInteger() && st.Peek().GetList().Count == 1 && !st.Peek().GetList().First().IsInteger() && st.Peek().GetList().First().GetList().Count == 0)
                {
                    st.Peek().GetList().RemoveAt(st.Peek().GetList().Count - 1);
                }

                return st.Peek();
            }
        }
        public class NestedInteger
        {
            private List<NestedInteger> nestedList;
            private bool isInt;
            private int val;
            // Constructor initializes an empty nested list.
            public NestedInteger()
            {
                nestedList = new List<NestedInteger>();
            }

            // Constructor initializes a single integer.
            public NestedInteger(int value)
            {
                nestedList = new List<NestedInteger>();
                val = value;
                isInt = true;
            }

            // @return true if this NestedInteger holds a single integer, rather than a nested list.
            public bool IsInteger()
            {
                return isInt;
            }

            // @return the single integer that this NestedInteger holds, if it holds a single integer
            // Return null if this NestedInteger holds a nested list
            public int GetInteger()
            {
                return val;
            }

            // Set this NestedInteger to hold a single integer.
            public void SetInteger(int value)
            {
                isInt = true;
                val = value;
            }

            // Set this NestedInteger to hold a nested list and adds a nested integer to it.
            public void Add(NestedInteger ni)
            {
                nestedList.Add(ni);
            }

            // @return the nested list that this NestedInteger holds, if it holds a nested list
            // Return null if this NestedInteger holds a single integer
            public IList<NestedInteger> GetList()
            {
                return nestedList;
            }
        }
    }
}
