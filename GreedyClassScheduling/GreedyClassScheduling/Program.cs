using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyClassScheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            var art = new Class() { name = "art", start = 900, end = 1000 };
            var eng = new Class() { name = "eng", start = 930, end = 1030 };
            var math = new Class() { name = "math", start = 1000, end = 1100 };
            var cs = new Class() { name = "cs", start = 1030, end = 1130 };
            var music = new Class() { name = "music", start = 1100, end = 1200 };

            var classesList = new List<Class>();
            classesList.Add(music);
            classesList.Add(cs);
            classesList.Add(art);
            classesList.Add(math);
            classesList.Add(eng);
            var classesToTake = MaxClasses.GetMaxClasses(classesList);
        }

        public class Class : IComparable
        {
            public int start { get; set; }
            public int end { get; set; }
            public string name { get; set; }
            public int CompareTo(object obj)
            {
                if (obj == null) return -1;
                var otherClass = obj as Class;
                if (this.end > otherClass.end) return 1;
                return -1;
            }
        }

        public class MaxClasses
        {
            public static List<Class> GetMaxClasses(List<Class> classes)
            {
                var response = new List<Class>();

                classes.Sort();
                response.Add(classes.FirstOrDefault());
                classes.RemoveAt(0);
                while (classes.Count > 0)
                {
                    while (classes.Count > 0)
                    {
                        var curr = classes.FirstOrDefault();
                        classes.RemoveAt(0);
                        if (curr.start >= response.LastOrDefault().end)
                        {
                            response.Add(curr);
                            break;
                        }
                    }
                }

                return response;
            }
        }
    }
}
