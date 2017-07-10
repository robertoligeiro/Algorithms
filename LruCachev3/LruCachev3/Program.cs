using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LruCachev3
{
    class Program
    {
        static void Main(string[] args)
        {
            var cache = new Cache(3);
            cache.Add(1, "1");
            cache.Add(2, "2");
            cache.Add(3, "3");
            cache.Add(4, "4");
            var s = cache.Lookup(3);
            s = cache.Lookup(2);
            var b = cache.Delete(4);
            b = cache.Delete(2);
            b = cache.Delete(3);
            b = cache.Delete(1);
        }

        public class CacheNode
        {
            public CacheNode next { get; set; }
            public CacheNode prev { get; set; }
            public int key { get; set; }
            public string value { get; set; }
        }

        public class Cache
        {
            private int size;
            private Dictionary<int, CacheNode> map;
            private CacheNode head;
            private CacheNode tail;
            public Cache(int s)
            {
                size = s;
                map = new Dictionary<int, CacheNode>();
                head = null;
                tail = null;
            }

            public string Lookup(int key)
            {
                CacheNode node;
                if (!map.TryGetValue(key, out node))
                {
                    return string.Empty;
                }

                if (node == head)
                {
                    return node.value;
                }

                var prev = node.prev;
                var next = node.next;

                if(next != null) next.prev = prev;
                prev.next = next;
                node.next = head;
                node.prev = null;
                head.prev = node;
                head = node;
                if (tail == node) tail = prev;

                return node.value;
            }

            public void Add(int key, string value)
            {
                if (Lookup(key) != string.Empty)
                {
                    map[key].value = value;
                    return;
                }

                var node = new CacheNode() { key = key, value = value };
                map.Add(key, node);
                if (head == null)
                {
                    head = node;
                    tail = node;
                    return;
                }

                node.next = head;
                head.prev = node;
                head = node;
                if (map.Count > size)
                {
                    Delete(tail.key);
                }
            }

            public bool Delete(int key)
            {
                if (Lookup(key) != string.Empty)
                {
                    if (head == tail)
                    {
                        head = null;
                        tail = null;
                    }
                    else
                    {
                        head = head.next;
                        head.prev = null;
                    }
                    map.Remove(key);
                    return true;
                }
                return false;
            }
        }
    }
}
