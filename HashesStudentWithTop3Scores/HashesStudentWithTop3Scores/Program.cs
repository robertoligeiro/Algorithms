using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashesStudentWithTop3Scores
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = GetTopStudent(new List<Tuple<string, int>>()
            {
                new Tuple<string, int>("roberto",98),
                new Tuple<string, int>("flav",97),
                new Tuple<string, int>("zeca",97),
                new Tuple<string, int>("roberto",96),
                new Tuple<string, int>("zeca",99),
                new Tuple<string, int>("flav",94),
                new Tuple<string, int>("zeca",98),
                new Tuple<string, int>("roberto",95),
                new Tuple<string, int>("zeca",100),
            });
        }

        public static string GetTopStudent(List<Tuple<string, int>> scores)
        {
            var studentScores = new Dictionary<string, SortedSet<int>>();
            var maxSoFar = 0;
            var topStudent = string.Empty;
            foreach (var s in scores)
            {
                SortedSet<int> sscore;
                if (studentScores.TryGetValue(s.Item1, out sscore))
                {
                    if (sscore.Count > 2)
                    {
                        if (s.Item2 > sscore.Min)
                        {
                            sscore.Remove(sscore.Min);
                            sscore.Add(s.Item2);
                        }
                    }
                    else
                    {
                        sscore.Add(s.Item2);
                    }

                    if (sscore.Count == 3)
                    {
                        var localScore = 0;
                        foreach (int i in sscore)
                        {
                            localScore += i;
                        }
                        localScore /= 3;
                        if (localScore > maxSoFar)
                        {
                            maxSoFar = localScore;
                            topStudent = s.Item1;
                        }
                    }
                }
                else
                    studentScores.Add(s.Item1, new SortedSet<int>() { s.Item2 });
            }

            return topStudent;
        }
    }
}
