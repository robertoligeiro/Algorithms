using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsCheckPalindromicity
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = IsPalindrome("!AbcdcB@#a");
            b = IsPalindrome("");
            b = IsPalindrome("AAAAAAAAAA");
            b = IsPalindrome("AAAcAAAAAAA");
        }

        public static bool IsPalindrome(string s)
        {
            var left = 0;
            var right = s.Length - 1;
            s = s.ToLower();
            while (left < right)
            {
                while (!Char.IsLetterOrDigit(s[left]))
                { left++; }
                while (!Char.IsLetterOrDigit(s[right]))
                { right--; }

                if (s[left] != s[right]) return false;
                left++;
                right--;
            }

            return true;
        }
    }
}
