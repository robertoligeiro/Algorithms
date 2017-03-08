using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksNormalizeFilePath
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = NormalizePath("foo/bar");
            r = NormalizePath("foo/./bar");
            r = NormalizePath("foo/../bar");
            r = NormalizePath("foo/./../bar");
            r = NormalizePath("foo/.././bar");
            r = NormalizePath("foo/bar/.././barz");
            r = NormalizePath(".././bar/foo/./bar/../");
        }

        public static string NormalizePath(string p)
        {
            var s = new Stack<string>();
            var pArray = p.Split('/');
            foreach (var c in pArray)
            {
                if (c == ".") continue;
                if (c == "..")
                {
                    if (s.Count > 0) s.Pop();
                }
                else s.Push(c);
            }
            if (s.Count == 0) return string.Empty;
            var resp = new List<string>() { s.Pop()};
            while (s.Count > 0)
            {
                resp.Add(s.Pop());
            }
            resp.Reverse();
            return string.Join("/",resp.ToArray());
        }
    }
}
