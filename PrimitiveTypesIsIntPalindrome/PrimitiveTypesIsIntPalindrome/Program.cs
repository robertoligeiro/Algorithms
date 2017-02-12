using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimitiveTypesIsIntPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            bool b = IsPalindrome(-1);
            b = IsPalindrome(0);
            b = IsPalindrome(11);
            b = IsPalindrome(121);
            b = IsPalindrome(2112);
            b = IsPalindrome(123);
            b = IsPalindrome(21112);
            b = IsPalindrome(21122);
        }

        static bool IsPalindrome(int a)
        {
            if (a < 0) return false;
            if (a == 0) return true;
            var l = new List<char>();
            while (a > 0)
            {
                var dig = a % 10;
                l.Add(Convert.ToChar(dig));
                a /= 10;
            }
            int i = 0;
            int j = l.Count-1;
            while (i <= j)
            {
                if (l[i++] != l[j--]) return false;
            }

            return true;
        }
    }
}
