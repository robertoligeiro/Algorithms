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

		public class NestedCounter
		{
			public NestedInteger nestedInt;
			public int index;
		}
		public class NestedIterator
		{
			private Stack<NestedCounter> s = new Stack<NestedCounter>();
			private int indexList = 0;
			private IList<NestedInteger> nestedList;

			private void AddNext()
			{
				NestedCounter curr = null;
				if (s.Count > 0 && s.Peek().index == -1) return;
				if (s.Count > 0)
				{
					while (s.Count > 0 && !s.Peek().nestedInt.IsInteger() && s.Peek().index == s.Peek().nestedInt.GetList().Count)
					{
						s.Pop();
					}
					if (s.Count > 0)
					{
						if (s.Peek().nestedInt.IsInteger()) return;

						do
						{
							if (s.Count == 0) break;
							if (s.Peek().index >= s.Peek().nestedInt.GetList().Count)
							{
								curr = s.Pop();
								continue;
							}

							curr = new NestedCounter() { nestedInt = s.Peek().nestedInt.GetList()[s.Peek().index++] };
							if (curr.nestedInt.IsInteger())
							{
								curr.index = -1;
							}

							s.Push(curr);
						}
						while (curr.index != -1);
					}
				}
				if (s.Count == 0 && this.indexList < this.nestedList.Count)
				{
					curr = new NestedCounter() { nestedInt = nestedList[this.indexList++] };
					if (curr.nestedInt.IsInteger()) curr.index = -1;
					s.Push(curr);
					this.AddNext();
				}
			}
			public NestedIterator(IList<NestedInteger> nestedList)
			{
				if (nestedList == null || nestedList.Count == 0)
				{
					this.nestedList = new List<NestedInteger>();
					return;
				}

				this.nestedList = nestedList;
				AddNext();
			}

			public bool HasNext()
			{
				return s.Count > 0;
			}

			public int Next()
			{
				var ret = s.Peek().nestedInt.GetInteger();
				s.Pop();
				AddNext();
				return ret;
			}
		}
	}
}
