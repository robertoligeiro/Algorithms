using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashesIsbnCache
{
    class Program
    {
        static void Main(string[] args)
        {
            var cache = new IsbnCache();
            cache.Insert("1");
            cache.Insert("2");
            cache.Insert("3");
            cache.Insert("4");
            cache.Insert("5"); // remove 1 from cache, tail goes to 2, 5 is head.
            cache.Remove("5"); // head goes to 4
            cache.LookUp("3"); // head goes to 3
            cache.LookUp("2"); // head goes to 2, ordering now: 2,3,4 :)
            cache.LookUp("1"); // nothing changes, 1 was removed.
            cache.Insert("1"); // head goes to 1, ordering 1,2,3,4 :)
        }

        public class CacheItem
        {
            public string isbn { get; set; }
            public CacheItem next { get; set; }
            public CacheItem prev { get; set; }
            public CacheItem(string isbn)
            {
                this.isbn = isbn;
            }
        }

        public class IsbnCache
        {
            public int size = 4;
            private CacheItem head = new CacheItem(string.Empty);
            private CacheItem tail = new CacheItem(string.Empty);
            private Dictionary<string, CacheItem> cacheMap = new Dictionary<string, CacheItem>();

            public CacheItem LookUp(string isbn)
            {
                CacheItem item = null;
                if (cacheMap.TryGetValue(isbn, out item))
                {
                    if (item == head.next) return item;
                    if (item == tail.next)
                    {
                        tail.next = item.prev;
                    }
                    item.prev.next = item.next;
                    if(item.next != null) item.next.prev = item.prev;
                    item.next = head.next;
                    item.prev = null;
                    head.next = item;
                }
                return item;
            }

            public void Insert(string isbn)
            {
                var item = this.LookUp(isbn);
                if (item != null) return;
                if (cacheMap.Count == size)
                {
                    var t = tail.next;
                    cacheMap.Remove(t.isbn);
                    tail.next = t.prev;
                    tail.next.next = null;
                    t.prev = null;
                }
                item = new CacheItem(isbn);
                item.next = head.next;
                if(head.next != null) head.next.prev = item;
                if (tail.next == null) tail.next = item;
                head.next = item;
                cacheMap.Add(isbn, item);
            }

            public bool Remove(string isbn)
            {
                var item = this.LookUp(isbn);
                if (item == null) return false;
                head.next = item.next;
                cacheMap.Remove(item.isbn);
                if (item == tail.next) tail.next = null;
                return true;
            }
        }
    }
}
