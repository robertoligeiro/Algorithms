using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewWideOrbit
{
    class Program
    {
        static void Main(string[] args)
        {
            var o = new List<object>()
            {
                1, 2, 3,
                new List<object>() { 4, 5, new List<object>() { 6 } },
                new List<object>() { 7 }, 8
            }; // [1,2,3,[4,5,[6]],[7],8]
            var r = FlatList(o); //=>1,2,3,4,5,6,7,8
        }

        public static List<int> FlatList(List<object> obj)
        {
            var resp = new List<int>();
            foreach (var o in obj)
            {
                FlatList(o, resp);
            }
            return resp;
        }

        public static void FlatList(object obj, List<int> resp)
        {
            int? value = obj as int?;
            if (value.HasValue)
            {
                resp.Add(value.Value);
                return;
            }
            resp.AddRange(FlatList(obj as List<object>));
        }
    }
}
