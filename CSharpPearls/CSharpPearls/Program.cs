using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPearls
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new MyType() { power = 200 };
            var i = 200;
            SuperPower(t, i);
            Console.WriteLine("power: {0}, i: {1}", t.power, i);

            Node n0 = new Node { val = 0 };
            Node n1 = new Node { val = 1 };
            n0.next = n1;
            WalkOnList(n0);
            Console.WriteLine("n0.val: {0}, n1.val: {1}", n0.val, n1.val);

            Console.ReadKey();
        }

        public class Node
        {
            public int val;
            public Node next;
        }

        public static void WalkOnList(Node r)
        {
            while (r != null)
            {
                r = r.next;
            }
        }
        public class MyType
        {
            public int power;
        }

        public static void SuperPower(MyType t, int i)
        {
            t.power += 1000;
            i += 1000;
            var tt = new MyType { power = 20000 };
            t = tt;
        }
    }
}
