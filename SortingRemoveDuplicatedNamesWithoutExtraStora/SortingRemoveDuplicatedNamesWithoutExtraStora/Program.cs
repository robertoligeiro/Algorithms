using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingRemoveDuplicatedNamesWithoutExtraStora
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = RemoveDups(new List<Tuple<string, string>>()
            {
                new Tuple<string, string>("roberto","ligeiro"),
                new Tuple<string, string>("roberto","marques"),
                new Tuple<string, string>("flaviana","nunes"),
                new Tuple<string, string>("ana","martha"),
                new Tuple<string, string>("roberto","celso"),
                new Tuple<string, string>("zeca","ligeiro"),
                new Tuple<string, string>("maria","jose"),
            });
        }

        public static List<Tuple<string, string>> RemoveDups(List<Tuple<string, string>> names)
        {
            names.Sort();
            var prevName = names.FirstOrDefault().Item1;
            var resp = new List<Tuple<string, string>>() { names.FirstOrDefault() };
            for (int i = 1; i < names.Count; ++i)
            {
                if (names[i].Item1 == prevName) continue;
                prevName = names[i].Item1;
                resp.Add(names[i]);
            }
            return resp;
        }
    }
}
