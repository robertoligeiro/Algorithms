using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lru
{
    class Program
    {
        static void Main(string[] args)
        {
            bool b;
            var lru = new Lru();
            b = lru.GetVal(1);
            b = lru.GetVal(2);
            b = lru.GetVal(3);
            b = lru.GetVal(2);
            b = lru.GetVal(4);
        }

        public class Lru
        {
            internal class LruNode
            {
                public int val { get; set; }
                public LruNode prev { get; set; }

                public LruNode next { get; set; }
            }

            private const int MaxSize = 3;
            private LruNode head = new LruNode();
            private LruNode tail = new LruNode();
            private Dictionary<int, LruNode> lruHash = new Dictionary<int, LruNode>();

            public bool GetVal(int v)
            {
                LruNode node;
                if (!lruHash.TryGetValue(v, out node))
                {
                    var nNode = new LruNode() { val = v, next = head.next };
                    if(head.next != null) head.next.prev = nNode;
                    head.next = nNode;

                    // delete last node and remove from hash if max has been reached.
                    if (lruHash.Count == MaxSize)
                    {
                        var t = tail.next.val;
                        lruHash.Remove(t);
                        tail.next = tail.next.prev;
                        tail.next.next = null;
                    }
                    else // if first item, set tail
                    if (lruHash.Count == 0)
                    {
                        tail.next = nNode;
                    }

                    lruHash.Add(v, nNode);

                    return false;
                }
                else
                {
                    //trick to know if node is already first position
                    if (node.prev != null)
                    {
                        // if we are promoting tail to head, set new tail
                        if (node == tail.next)
                        {
                            tail.next = tail.next.next;
                        }

                        //arrange list
                        node.prev.next = node.next;
                        if(node.next != null) node.next.prev = node.prev;
                        node.next = head.next;
                        //arrange new head
                        node.prev = null;
                        head.next.prev = node;
                        head.next = node;
                    }

                    return true;
                }
            }
        }
    }
}
