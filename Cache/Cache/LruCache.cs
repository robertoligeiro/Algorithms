using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache
{
	public class LruCacheNode
	{
		public LruCacheNode next { get; set; }
		public LruCacheNode prev { get; set; }
		public int id { get; set; }
		public string value { get; set; }
	}
	public class LruCache
	{
		private LruCacheNode head = null;
		private LruCacheNode tail = null;
		private Dictionary<int, LruCacheNode> cache;
		private int MaxSize;

		public LruCache(int maxSize)
		{
			this.MaxSize = maxSize;
			this.cache = new Dictionary<int, LruCacheNode>();
		}

		public string LookUp(int id)
		{
			LruCacheNode node = null;
			if (!this.cache.TryGetValue(id, out node)) return string.Empty;

			if (node == this.head) return node.value;

			var prev = node.prev;
			var next = node.next;

			prev.next = next;
			if (next != null)
			{
				next.prev = prev;
			}
			else
			{
				tail = prev;
			}

			node.prev = null;
			node.next = head;
			head.prev = node;
			head = node;

			return node.value;
		}

		public void Add(int id, string value)
		{
			if (this.LookUp(id) != string.Empty)
			{
				head.value = value;
				return;
			}

			var node = new LruCacheNode() { id = id, value = value };
			this.cache.Add(id, node);
			if (head == null)
			{
				head = node;
				tail = node;
				return;
			}

			head.prev = node;
			node.next = head;
			head = node;
			if (this.cache.Count > this.MaxSize)
			{
				var toDelete = tail;
				tail = tail.prev;
				tail.next = null;
				toDelete.prev = null;
				this.cache.Remove(toDelete.id);
			}
		}

		public void PrintCacheValue()
		{
			var curr = this.head;
			while (curr != null)
			{
				Console.WriteLine(string.Format("Id:{0}, Value: {1}", curr.id, curr.value));
				curr = curr.next;
			}
			Console.WriteLine();
		}
	}
}
