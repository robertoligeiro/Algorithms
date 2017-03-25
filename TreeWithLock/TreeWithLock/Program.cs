using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeWithLock
{
    class Program
    {
        public class TreeWithLock
        {
            public int val { get; set; }
            public TreeWithLock left { get; set; }
            public TreeWithLock right { get; set; }
            public TreeWithLock parent { get; set; }
            public bool locked { get; private set; }

            private int nLockedDesc;
            public bool Lock()
            {
                if (this.locked || this.nLockedDesc > 0) return false;
                var curr = this.parent;
                while (curr != null)
                {
                    if (curr.locked) return false;
                    curr = curr.parent;
                }

                this.locked = true;
                this.nLockedDesc++;
                curr = this.parent;
                while (curr != null)
                {
                    curr.nLockedDesc++;
                    curr = curr.parent;
                }
                return true;
            }

            public void Unlock()
            {
                if (this.locked)
                {
                    this.locked = false;
                    var curr = this.parent;
                    while (curr != null)
                    {
                        curr.nLockedDesc--;
                        curr = curr.parent;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            // full tree
            var n0 = new TreeWithLock() { val = 5, };
            var n1 = new TreeWithLock() { val = 3, parent = n0};
            var n2 = new TreeWithLock() { val = 7, parent = n0 };
            var n3 = new TreeWithLock() { val = 1, parent = n1 };
            var n4 = new TreeWithLock() { val = 6, parent = n2 };
            var n5 = new TreeWithLock() { val = 8, parent = n2 };
            n0.left = n1;
            n0.right = n2;
            n1.left = n3;
            n2.left = n4;
            n2.right = n5;

            var b = n1.Lock(); //true
            b = n3.Lock(); //false;
            n1.Unlock();
            b = n3.Lock(); //true;
            b = n4.Lock(); //true
            b = n5.Lock(); //true
            b = n2.Lock(); //false
            n5.Unlock(); 
            b = n2.Lock(); //false
            n4.Unlock();
            b = n2.Lock(); //true

        }
    }
}
