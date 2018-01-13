using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode146.LRU_Cache
{
	//https://leetcode.com/problems/lru-cache/description/
	class Program
	{
		static void Main(string[] args)
		{
			var cache = new LRUCache(1);
			cache.Put(2,1);
			var r = cache.Get(2);
			cache.Put(3, 2);
			r = cache.Get(2);
			r = cache.Get(3);
		}

		public class LRUCache
		{
			private class Node
			{
				public int key;
				public int val;
				public Node next;
				public Node prev;
			}

			private Dictionary<int, Node> cache = new Dictionary<int, Node>();
			private Node head;
			private Node tail;
			private int capacity;
			public LRUCache(int capacity)
			{
				this.capacity = capacity;
			}

			public int Get(int key)
			{
				Node n = null;
				if (!this.cache.TryGetValue(key, out n)) return -1;

				if (n == this.head) return n.val;
				if (n == tail)
				{
					tail = tail.prev;
					tail.next = null;
				}
				else
				{
					n.prev.next = n.next;
					n.next.prev = n.prev;
				}
				n.prev = null;
				n.next = this.head;
				this.head.prev = n;
				this.head = n;
				return this.head.val;
			}

			public void Put(int key, int value)
			{
				Node n = null;
				if (this.Get(key) != -1)
				{
					this.head.val = value;
					return;
				}

				if (this.cache.Count == this.capacity)
				{
					if (this.capacity == 1)
					{
						this.cache.Remove(this.tail.key);
						this.tail = null;
						this.head = null;
					}
					else
					{
						var d = this.tail;
						this.tail = d.prev;
						this.tail.next = null;
						this.cache.Remove(d.key);
					}
				}

				n = new Node() { val = value, key = key };
				this.cache.Add(key, n);
				if (this.head == null)
				{
					this.head = n;
					this.tail = n;
					return;
				}

				this.head.prev = n;
				n.next = this.head;
				this.head = n;
			}
		}
	}
}
