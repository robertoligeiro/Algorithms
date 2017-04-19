using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingPartStudentsByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new List<Tuple<string, int>>()
            {
                new Tuple<string, int>("roberto", 37),
                new Tuple<string, int>("zeca", 17),
                new Tuple<string, int>("maria", 37),
                new Tuple<string, int>("flaviana", 17),
                new Tuple<string, int>("ana", 7),
                new Tuple<string, int>("divino", 37),
            };
            var r = PartStudents(l);
        }

        public static List<Tuple<string, int>> PartStudents(List<Tuple<string, int>> students)
        {
            var response = new List<Tuple<string, int>>();
            var map = new Dictionary<int, List<Tuple<string, int>>>();
            foreach (var s in students)
            {
                List<Tuple<string, int>> l;
                if (map.TryGetValue(s.Item2, out l))
                {
                    l.Add(s);
                }
                else
                {
                    map.Add(s.Item2, new List<Tuple<string, int>>() { s });
                }
            }

            foreach (var l in map.Values)
            {
                response.AddRange(l);
            }
            return response;
        }
    }
}
