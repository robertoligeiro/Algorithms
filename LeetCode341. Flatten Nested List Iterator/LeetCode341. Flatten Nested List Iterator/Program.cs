using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode341.Flatten_Nested_List_Iterator
{
	class Program
	{
		//https://leetcode.com/problems/flatten-nested-list-iterator/description/
		static void Main(string[] args)
		{
		}
		public class NestedInteger
		{

			// @return true if this NestedInteger holds a single integer, rather than a nested list.
			public bool IsInteger() { return true; }

			// @return the single integer that this NestedInteger holds, if it holds a single integer
			// Return null if this NestedInteger holds a nested list
			public int GetInteger() { return 1; }

			// @return the nested list that this NestedInteger holds, if it holds a nested list
			// Return null if this NestedInteger holds a single integer
			public IList<NestedInteger> GetList() { return new List<NestedInteger>(); }
		}

		public class NestedIterator
		{
			private Stack<NestedInteger> s = new Stack<NestedInteger>();

			public NestedIterator(IList<NestedInteger> nestedList)
			{
				if (nestedList == null) return;
				for (int i = nestedList.Count - 1; i >= 0; --i)
				{
					if(nestedList[i].IsInteger() || nestedList[i].GetList().Count > 0)
						s.Push(nestedList[i]);
				}
				SetNext();
			}

			private void SetNext()
			{
				if (s.Count == 0 || s.Peek().IsInteger()) return;
				var top = s.Pop();
				var i = top.GetList().First();
				top.GetList().RemoveAt(0);
				if (top.GetList().Count > 0) s.Push(top);
				if (i.IsInteger() || i.GetList().Count > 0) s.Push(i);
				SetNext();
			}
			public bool HasNext()
			{
				return s.Count > 0;
			}

			public int Next()
			{
				if (s.Count > 0)
				{
					var ret = s.Peek().GetInteger();
					s.Pop();
					this.SetNext();
					return ret;
				}
				return -1;
			}
		}
	}
}
