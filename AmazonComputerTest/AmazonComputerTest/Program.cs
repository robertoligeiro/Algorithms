using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonComputerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            //var r = Solution.totalScore(new string[] { "1", "2", "+", "Z" }, 4);
            var r = Solution.totalScore(new string[] { "5", "-2", "4", "Z", "X", "9", "+", "+" }, 8);
        }

        class Solution
        {
            // METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
            public static int totalScore(string[] blocks, int n)
            {
                // WRITE YOUR CODE HERE
                if (blocks == null || n == 0) return 0;
                var currScore = new Stack<int>();
                var totalScore = new Stack<int>();
                currScore.Push(0);
                totalScore.Push(0);
                for (int i = 0; i < n; ++i)
                {
                    var num = 0;
                    if (int.TryParse(blocks[i], out num))
                    {
                        totalScore.Push(num + totalScore.Peek());
                        currScore.Push(num);
                    }
                    else
                    {
                        if (blocks[i].ToLower() == "z")
                        {
                            if (currScore.Count > 1)
                            {
                                currScore.Pop();
                            }
                            if(totalScore.Count > 1)
                            { 
                                totalScore.Pop();
                            }
                        }
                        else if (blocks[i].ToLower() == "+")
                        {
                            var last = 0;
                            var prev = 0;

                            if(currScore.Count > 1) last = currScore.Pop();
                            if(currScore.Count > 1) prev = currScore.Pop();
                            currScore.Push(prev);
                            currScore.Push(last);
                            var sum = last + prev;
                            currScore.Push(sum);
                            sum += totalScore.Peek();
                            totalScore.Push(sum);
                        }
                        else if (blocks[i].ToLower() == "x")
                        {
                            var mult = currScore.Peek() * 2;
                            currScore.Push(mult);
                            var tot = totalScore.Peek() + mult;
                            totalScore.Push(tot);
                        }
                    }
                }
                return totalScore.Peek();
            }
            // METHOD SIGNATURE ENDS
        }
    }
}
