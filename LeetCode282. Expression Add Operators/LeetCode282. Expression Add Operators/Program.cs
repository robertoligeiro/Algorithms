using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode282.Expression_Add_Operators
{
    class Program
    {
        //https://leetcode.com/problems/expression-add-operators/description/
        //not all cases passing
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.AddOperators("123", 6);
            //var r = s.AddOperators("232", 8);
        }

        public class Solution
        {
            public IList<string> AddOperators(string num, int target)
            {
                if (string.IsNullOrWhiteSpace(num)) return new List<string>();
                var ops = new List<char>() { '+', '-', '*' };
                var resp = new List<string>();
                var parc = new List<char>() { num[0] };
                AddOperators(num, target, num[0] - '0', 0, 1, ops, parc, resp);
                return resp;
            }

            private void AddOperators(string num, int target, int acc, int last, int index, List<char> ops, List<char> parc, List<string> resp)
            {
                if (index == num.Length)
                {
                    if (target == acc)
                    {
                        resp.Add(new string(parc.ToArray()));
                    }
                    return;
                }

                foreach (var op in ops)
                {
                    var itAcc = 0;
                    var itLast = 0;
                    switch (op)
                    {
                        case '+':
                            parc.Add('+');
                            itAcc = acc + (num[index] - '0');
                            itLast = num[index] - '0';
                            break;
                        case '-':
                            parc.Add('-');
                            itAcc = acc - (num[index] - '0');
                            itLast = -(num[index] - '0');
                            break;
                        case '*':
                            parc.Add('*');
                            if (index == 1) last = acc;
                            itAcc = acc - last + last * (num[index] - '0');
                            itLast = last * num[index] - '0';
                            break;
                    }
                    parc.Add(num[index]);
                    AddOperators(num, target, itAcc, itLast, index + 1, ops, parc, resp);
                    parc.RemoveAt(parc.Count - 1);
                    parc.RemoveAt(parc.Count - 1);
                }
            }
        }
    }
}
