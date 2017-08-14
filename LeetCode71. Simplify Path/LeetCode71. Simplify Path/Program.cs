using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode71.Simplify_Path
{
    class Program
    {
        //https://leetcode.com/problems/simplify-path/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.SimplifyPath("/home/foo/.ssh/../.ssh2/authorized_keys/");
        }

        public class Solution
        {
            public string SimplifyPath(string path)
            {
                var p = path.Split('/');
                var sPath = new List<string>();
                foreach (var s in p)
                {
                    if (s == "" || s == ".") continue;
                    else if (s == ".." && sPath.Count > 0) sPath.RemoveAt(sPath.Count - 1);
                    else if (s != "..") sPath.Add(s);
                }

                var resp = new StringBuilder();
                foreach(var s in sPath)
                {
                    resp.Append("/"+s);
                }
                return resp.Length > 0 ? resp.ToString() : "/";
            }
        }
    }
}
