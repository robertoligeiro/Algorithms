using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LruClean
{
    class Program
    {
        static void Main(string[] args)
        {
            var cache = new Cache();

            cache.AddItem(1);
            cache.AddItem(2);
            cache.AddItem(3);
            cache.AddItem(4);
            cache.Lookup(3);
            cache.Lookup(2);
            cache.Lookup(1);
        }

        public class CacheItem
        {
            public int key;
            public CacheItem next;
            public CacheItem prev;
        }

        public class Cache
        {
            private CacheItem head = null;
            private CacheItem tail = null;
            private Dictionary<int, CacheItem> map = new Dictionary<int, CacheItem>();
            private int size = 3;
            private void RemoveTail()
            {
                if (tail != null)
                {
                    var t = tail;
                    tail = t.prev;
                    t.prev = null;
                    tail.next = null;
                    map.Remove(t.key);
                }
            }

            public CacheItem Lookup(int v)
            {
                CacheItem item = null;
                if (map.TryGetValue(v, out item))
                {
                    if (item == tail) tail = item.prev;
                    if (item.prev != null)
                    {
                        item.prev.next = item.next;
                        if(item.next != null) item.next.prev = item.prev;
                        item.prev = null;
                        item.next = head;
                        head.prev = item;
                        head = item;
                    }
                }
                return item;
            }

            public void AddItem(int v)
            {
                var item = Lookup(v);
                if (item != null) return;
                if (map.Count == size)
                {
                    RemoveTail();
                }

                item = new CacheItem() { key = v };
                item.next = head;
                if (head != null)
                {
                    head.prev = item;
                }
                head = item;
                if (tail == null) tail = item;
                map.Add(v, item);
            }
        }
    }
}
