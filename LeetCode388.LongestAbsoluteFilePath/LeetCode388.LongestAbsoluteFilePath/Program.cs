using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode388.LongestAbsoluteFilePath
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            //var r = s.LengthLongestPath("dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext");
            var r = s.LengthLongestPath("a.txt");
        }
        public class Solution
        {
            public int LengthLongestPath(string input)
            {
                input = input.Replace("    ", "\t");
                var chuncks = input.Split('\n');
                var levels = new Stack<int>();
                levels.Push(chuncks[0].Length);
                int acc = levels.Peek();
                var maxSoFar = chuncks[0].IndexOf('.') > 0 ? acc : 0;
                for (int i = 1; i < chuncks.Length; ++i)
                {
                    var chunck = chuncks[i];
                    int localLevel = chunck.LastIndexOf('\t') +  1;
                    chunck = chuncks[i].Substring(localLevel);
                    int file = chunck.IndexOf('.');
                    if ( file > 0)
                    {
                        var localLen = chunck.Length + 1;
                        while (levels.Count > localLevel) levels.Pop();
                        localLen += levels.Peek();
                        if (localLen > maxSoFar) maxSoFar = localLen;
                    }
                    else
                    {
                        while (levels.Count > localLevel) levels.Pop();
                        acc = levels.Count > 0 ? levels.Peek() : 0;
                        levels.Push(chunck.Length +  acc + 1);
                    }
                }

                return maxSoFar;
            }
        }
    }
}
