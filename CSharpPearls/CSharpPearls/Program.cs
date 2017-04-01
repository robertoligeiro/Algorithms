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
            Console.ReadKey();
        }

        public class MyType
        {
            public int power;
        }

        public static void SuperPower(MyType t, int i)
        {
            t.power += 1000;
            i += 1000;
        }
    }
}
