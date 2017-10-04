using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode609.Find_Duplicate_File_in_System
{
    class Program
    {
        //https://leetcode.com/problems/find-duplicate-file-in-system/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.FindDuplicate(new string[] { "root/a 1.txt(abcd) 2.txt(efgh)", "root/c 3.txt(abcd)", "root/c/d 4.txt(efgh)", "root 4.txt(efgh)" });
        }

        public class Solution
        {
            public IList<IList<string>> FindDuplicate(string[] paths)
            {
                var map = new Dictionary<string, List<Tuple<string, string>>>();
                //"root/a 1.txt(abcd) 2.txt(efgh)"
                //tokens: [root/a], [1.txt(abcd)],[2.txt(efgh)]
                foreach (var path in paths)
                {
                    var tokens = path.Split(' ');
                    var directory = tokens[0];
                    for (int i = 1; i < tokens.Length; ++i)
                    {
                        var indexContentStart = tokens[i].IndexOf('(');
                        var indexContentEnd = tokens[i].IndexOf(')');
                        var fileName = tokens[i].Substring(0, indexContentStart);
                        var fileContent = tokens[i].Substring(indexContentStart + 1, indexContentEnd - indexContentStart);

                        List<Tuple<string, string>> l;
                        var t = new Tuple<string, string>(directory, fileName);
                        if (map.TryGetValue(fileContent, out l))
                        {
                            l.Add(t);
                        }
                        else map.Add(fileContent, new List<Tuple<string, string>>() { t });
                        //map: {{abcd}, {root/a, 1.txt}}
                    }
                }
                var resp = new List<IList<string>>();
                foreach (var kvp in map)
                {
                    if (kvp.Value.Count > 1)
                    {
                        var item = new List<string>();
                        foreach (var t in kvp.Value)
                        {
                            var s = t.Item1 + '/' + t.Item2;
                            item.Add(s);
                        }
                        resp.Add(item);
                    }
                }
                return resp;
            }
        }
    }
}
