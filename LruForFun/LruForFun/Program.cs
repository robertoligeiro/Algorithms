using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LruForFun
{
    class Program
    {
        static void Main(string[] args)
        {
            var cache = new LruCache(3);
            cache.AddKeyValue(1, "one");
            cache.AddKeyValue(2, "two");
            cache.AddKeyValue(3, "three");
            //result cache: 3->2->1

            var s = cache.Lookup(2); //two
            s = cache.Lookup(1); //three
            //result cache: 1->2->3

            cache.AddKeyValue(4, "four");
            //result cache: 4->1->2

            cache.DeleteKey(5); //no change
            cache.DeleteKey(1); //4->2
            cache.DeleteKey(4); //2
            cache.DeleteKey(2); //empty

            cache.AddKeyValue(1, "one");
            cache.AddKeyValue(2, "two");
            cache.AddKeyValue(3, "three");
            //cache 3->2->1
        }

        public class CacheNode
        {
            public int key { get; set; }
            public string value { get; set; }
            public CacheNode next { get; set; }
            public CacheNode prev { get; set; }
        }
        public class LruCache
        {
            private CacheNode head;
            private CacheNode tail;
            private Dictionary<int, CacheNode> cache;
            private int size;
            public LruCache(int s)
            {
                this.size = s;
                this.cache = new Dictionary<int, CacheNode>();
                head = null;
                tail = null;
            }

            public string Lookup(int key)
            {
                CacheNode cacheNode;
                if (!cache.TryGetValue(key, out cacheNode)) return string.Empty;
                if (cacheNode == head) return cacheNode.value;

                var nodePrev = cacheNode.prev;
                var nodeNext = cacheNode.next;

                nodePrev.next = nodeNext;
                if (nodeNext != null) nodeNext.prev = nodePrev;
                if (cacheNode == tail) tail = nodePrev;

                cacheNode.prev = null;
                cacheNode.next = head;
                head.prev = cacheNode;
                head = cacheNode;
                return cacheNode.value;
            }

            public void AddKeyValue(int key, string value)
            {
                if (this.Lookup(key) != string.Empty)
                {
                    this.cache[key].value = value;
                    return;
                }

                var cacheNode = new CacheNode() { key = key, value = value };
                if (head == null)
                {
                    head = cacheNode;
                    tail = cacheNode;
                    this.cache.Add(key, cacheNode);
                    return;
                }

                head.prev = cacheNode;
                cacheNode.next = head;
                head = cacheNode;
                this.cache.Add(key, cacheNode);
                if (this.cache.Count > size) DeleteKey(tail.key);
            }

            public void DeleteKey(int key)
            {
                if (this.Lookup(key) == string.Empty)
                {
                    return;
                }
                var newhead = head.next;
                head.next = null;
                head = newhead;
                if (head != null) head.prev = null;
                else tail = null;
                this.cache.Remove(key);
            }
        }
    }
}
