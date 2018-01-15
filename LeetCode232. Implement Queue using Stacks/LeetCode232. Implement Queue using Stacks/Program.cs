using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode232.Implement_Queue_using_Stacks
{
	class Program
	{
		static void Main(string[] args)
		{
		}

		public class MyQueue
		{
			private Stack<int> inStack = new Stack<int>();
			private Stack<int> outStack = new Stack<int>();
			private void FillOutStack()
			{
				if (outStack.Count == 0)
				{
					if (inStack.Count == 0) throw new Exception("empty");
					while (inStack.Count > 0) outStack.Push(inStack.Pop());
				}
			}
			/** Initialize your data structure here. */
			public MyQueue()
			{

			}

			/** Push element x to the back of queue. */
			public void Push(int x)
			{
				inStack.Push(x);
			}

			/** Removes the element from in front of queue and returns that element. */
			public int Pop()
			{
				this.FillOutStack();
				return outStack.Pop();
			}

			/** Get the front element. */
			public int Peek()
			{
				this.FillOutStack();
				return outStack.Peek();
			}

			/** Returns whether the queue is empty. */
			public bool Empty()
			{
				return inStack.Count == 0 && outStack.Count == 0;
			}
		}
	}
}
