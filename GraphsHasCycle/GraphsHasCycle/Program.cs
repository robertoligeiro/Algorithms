using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsHasCycle
{
    class Program
    {
        static void Main(string[] args)
        {
            var n0 = new Node(0);
            var n1 = new Node(1);
            var n2 = new Node(2);
            var n3 = new Node(3);
            var n4 = new Node(4);
            var n5 = new Node(5);
            var n6 = new Node(6);
            var n7 = new Node(7);
            n0.children.Add(n1);
            n0.children.Add(n2);
            n1.children.Add(n3);
            n1.children.Add(n4);
            n2.children.Add(n5);
            n2.children.Add(n6);
            n6.children.Add(n7);
            n2.children.Add(n1);
            n4.children.Add(n2);

            var b = HasCycle(n0);
        }

        public enum State
        { NotVisited, Visiting, Visited}

        public class Node
        {
            public int val { get; set; }
            public State s { get; set; }
            public List<Node> children = new List<Node>();
            public Node(int v) { val = v; s = State.NotVisited; }
        }

        public static bool HasCycle(Node n)
        {
            if (n.s == State.Visiting)
            {
                return true;
            }

            n.s = State.Visiting;
            foreach (var c in n.children)
            {
                if (c.s != State.Visited)
                {
                    if (HasCycle(c))
                    {
                        return true;
                    }
                }
            }
            n.s = State.Visited;
            return false;
        }
    }
}
