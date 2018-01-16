using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode225.Implement_Stack_using_Queues
{
	//https://leetcode.com/problems/implement-stack-using-queues/description/
	class Program
	{
		static void Main(string[] args)
		{
		}
		public class MyStack
		{

			private Queue<int> q = new Queue<int>();
			/** Initialize your data structure here. */
			public MyStack()
			{

			}

			/** Push element x onto stack. */
			public void Push(int x)
			{
				var temp = new Queue<int>();
				temp.Enqueue(x);
				while(q.Count > 0)
				{
					temp.Enqueue(q.Dequeue());
				}
				q = temp;
			}

			/** Removes the element on top of the stack and returns that element. */
			public int Pop()
			{
				return q.Dequeue();
			}

			/** Get the top element. */
			public int Top()
			{
				return q.Peek();
			}

			/** Returns whether the stack is empty. */
			public bool Empty()
			{
				return q.Count == 0;
			}
		}

	}
}
