using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode381.Insert_Delete_GetRandom
{
	//https://leetcode.com/problems/insert-delete-getrandom-o1-duplicates-allowed/description/
	class Program
	{
		static void Main(string[] args)
		{
			var s = new RandomizedCollection();
			var r = 0;
			s.Insert(1);
			r = s.GetRandom();
			s.Insert(1);
			s.Insert(2);
			r = s.GetRandom();
			var result = s.Remove(1);
			r = s.GetRandom();
			result = s.Remove(1);
			r = s.GetRandom();
			result = s.Remove(1);
			r = s.GetRandom();
		}

		public class RandomizedCollection
		{
			private LinkedList<int> items;
			private Dictionary<int, LinkedListNode<int>> map;
			private Random rand = new Random();
			/** Initialize your data structure here. */
			public RandomizedCollection()
			{
				items = new LinkedList<int>();
				map = new Dictionary<int, LinkedListNode<int>>();
			}

			/** Inserts a value to the collection. Returns true if the collection did not already contain the specified element. */
			public bool Insert(int val)
			{
				LinkedListNode<int> el;
				if (this.map.TryGetValue(val, out el))
				{
					items.AddAfter(el, val);
					return true;
				}
				else
				{
					el = new LinkedListNode<int>(val);
					this.map.Add(val, el);
					this.items.AddLast(el);
				}
				return false;
			}

			/** Removes a value from the collection. Returns true if the collection contained the specified element. */
			public bool Remove(int val)
			{
				LinkedListNode<int> el;
				if (this.map.TryGetValue(val, out el))
				{
					var next = el.Next;
					this.items.Remove(el);
					if (next != null && next.Value == val)
					{
						this.map[val] = next;
					}
					else
					{
						this.map.Remove(val);
					}
					return true;
				}

				return false;
			}

			/** Get a random element from the collection. */
			public int GetRandom()
			{
				return this.items.ElementAt(rand.Next()%this.items.Count);
			}
		}
	}
}
