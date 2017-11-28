using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LruCacheGeneric
{
	class Program
	{
		static void Main(string[] args)
		{
			var cache = new Cache<string>(3);
			cache.Add(1, "one");
			cache.Add(2, "two");
			cache.Add(3, "three");
			cache.Add(4, "four");
			var r = cache.LookUp(3);
			r = cache.LookUp(2);
			r = cache.LookUp(1);
		}

		public class CacheItem<T>
		{
			public int key;
			public T value;
			public CacheItem<T> prev;
			public CacheItem<T> next;
		}
		public class Cache<T>
		{
			private CacheItem<T> head;
			private CacheItem<T> tail;
			private Dictionary<int, CacheItem<T>> map;
			private int maxSize;
			public Cache(int s)
			{
				map = new Dictionary<int, CacheItem<T>>();
				maxSize = s;
			}

			public T LookUp(int key)
			{
				CacheItem<T> item;
				if (!map.TryGetValue(key, out item)) return default(T);
				if (item == head) return item.value;
				if (item == tail) tail = item.prev != null ? item.prev : tail;

				var prev = item.prev;
				var next = item.next;
				prev.next = next;
				if (next != null)
				{
					next.prev = prev;
				}
				item.prev = null;
				item.next = head;
				head.prev = item;
				head = item;
				return item.value;
			}

			public void Add(int key, T value)
			{
				if (LookUp(key) != null) return;
				var item = new CacheItem<T>() { value = value, key = key };
				map.Add(key, item);
				if (head == null)
				{
					head = item;
					tail = head;
					return;
				}

				head.prev = item;
				item.next = head;
				head = item;
				if (map.Count > maxSize)
				{
					Delete(tail.key);
				}
			}

			public void Delete(int key)
			{
				if (LookUp(key) == null) return;
				var newHead = head.next;
				head.next.prev = null;
				head.next = null;
				head = newHead;
				map.Remove(key);
			}
		}
	}
}
