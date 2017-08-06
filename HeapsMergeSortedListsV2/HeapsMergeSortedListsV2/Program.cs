using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapsMergeSortedListsV2
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new List<List<int>>() { new List<int>() { 3, 5, 7 }, new List<int>() { 0, 6 }, new List<int>() { 0, 6, 28 } };
            var r = MergeLists(l);
        }

        public static List<int> MergeLists(List<List<int>> sortedLists)
        {
            var sortedDictionary = new SortedDictionary<int, List<int>>();
            for (int i = 0; i < sortedLists.Count; ++i)
            {
                List<int> l;
                if (sortedDictionary.TryGetValue(sortedLists[i].FirstOrDefault(), out l))
                {
                    l.Add(i);
                }
                else sortedDictionary.Add(sortedLists[i].FirstOrDefault(), new List<int>() { i });
                if(sortedLists[i].Count > 0) sortedLists[i].RemoveAt(0);
            }

            var resp = new List<int>();
            while (sortedDictionary.Count > 0)
            {
                var t = sortedDictionary.FirstOrDefault();
                sortedDictionary.Remove(t.Key);
                foreach (var lid in t.Value)
                {
                    resp.Add(t.Key);
                    if (sortedLists[lid].Count > 0)
                    {
                        List<int> l;
                        if (sortedDictionary.TryGetValue(sortedLists[lid].FirstOrDefault(), out l))
                        {
                            l.Add(lid);
                        }
                        else sortedDictionary.Add(sortedLists[lid].FirstOrDefault(), new List<int>() { lid });
                        sortedLists[lid].RemoveAt(0);
                    } 
                }
            }
            return resp;
        }
    }
}
