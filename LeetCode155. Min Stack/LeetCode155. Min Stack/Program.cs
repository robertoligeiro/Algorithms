using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode155.Min_Stack
{
	class Program
	{
		static void Main(string[] args)
		{
		}
		public class MinStack
		{
			private Stack<int> s = new Stack<int>();
			private Stack<int> min = new Stack<int>();
			/** initialize your data structure here. */
			public MinStack()
			{

			}

			public void Push(int x)
			{
				s.Push(x);
				if (min.Count == 0 || min.Peek() >= x) min.Push(x);
			}

			public void Pop()
			{
				if (s.Count > 0)
				{
					if (min.Peek() == s.Peek()) min.Pop();
					s.Pop();
				}
				else throw new ArgumentException("empty");
			}

			public int Top()
			{
				if (s.Count > 0) return s.Peek();
				throw new ArgumentException("empty");
			}

			public int GetMin()
			{
				if (min.Count > 0) return min.Peek();
				throw new ArgumentException("empty");
			}
		}
	}
}
