using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackWithMax
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new StackMax();
            s.Push(1);
            s.Push(4);
            s.Push(3);
            s.Push(1);
            s.Push(6);
            s.Push(1);
            s.Push(2);
            var r = s.Max();
            r = s.Pop();
            r = s.Max();
            r = s.Pop();
            r = s.Max();
            r = s.Pop();
            r = s.Max();
        }

        public class StackMax
        {
            private Stack<int> s = new Stack<int>();
            private Stack<int> m = new Stack<int>();
            public void Push(int i)
            {
                s.Push(i);
                m.Push(m.Count > 0 && m.Peek() > i ? m.Peek() : i);
            }

            public int Pop()
            {
                m.Pop();
                return s.Pop();
            }

            public int Peek()
            {
                return s.Peek();
            }

            public int Max()
            {
                return m.Peek();
            }
        }
    }
}
