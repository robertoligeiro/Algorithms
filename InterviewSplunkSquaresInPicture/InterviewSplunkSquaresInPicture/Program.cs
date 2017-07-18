using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewSplunkSquaresInPicture
{
    class Program
    {
        static void Main(string[] args)
        {
            var b0 = new building() { id = "b0", height = 1, start = 1, distance = 0, end = 3 };
            var b1 = new building() { id = "b1", height = 1, start = 2, distance = 1, end = 3 };
            // b0 returned (b0 shadows b1)
            var r = GetSquaresInPicture(new List<building>() { b0, b1 });

            b0 = new building() { id = "b0", height = 1, start = 1, distance = 0, end = 3 };
            b1 = new building() { id = "b1", height = 1, start = 2, distance = 1, end = 4 };
            // b0 and b1 returned (b0 don't completed shadows b1)
            r = GetSquaresInPicture(new List<building>() { b0, b1 });

            b0 = new building() { id = "b0", height = 1, start = 1, distance = 0, end = 3 };
            b1 = new building() { id = "b1", height = 1, start = 2, distance = 2, end = 4 };
            var b2 = new building() { id = "b2", height = 3, start = 3, distance = 1, end = 5 };
            // b0 and b2 returned (b0 and b2 combined shadows b1)
            r = GetSquaresInPicture(new List<building>() { b0, b1, b2 });

            b0 = new building() { id = "b0", height = 1, start = 1, distance = 0, end = 3 };
            b1 = new building() { id = "b1", height = 2, start = 1, distance = 1, end = 3 };
            b2 = new building() { id = "b2", height = 3, start = 1, distance = 2, end = 3 };
            // b0, b1 and b2 returned (b0>b1>b2)
            r = GetSquaresInPicture(new List<building>() { b0, b1, b2 });
        }

        public class building
        {
            public string id;
            public int height;
            public int start;
            public int end;
            public int distance;
        }

        public static List<building> GetSquaresInPicture(List<building> buildings)
        {
            var activeBuilnds = new Stack<building>();
            activeBuilnds.Push(buildings.FirstOrDefault());
            buildings.RemoveAt(0);
            foreach (var b in buildings)
            {
                if (activeBuilnds.Peek().end < b.end && activeBuilnds.Peek().start < b.start)
                {
                    b.start = b.start + (b.end - activeBuilnds.Peek().end);
                    activeBuilnds.Push(b);
                }
                else
                {
                    if (activeBuilnds.Peek().height <= b.height &&
                        activeBuilnds.Peek().distance > b.distance &&
                        activeBuilnds.Peek().start >= b.start)
                    {
                        activeBuilnds.Pop();
                        b.start = b.start + (b.end - activeBuilnds.Peek().end);
                        activeBuilnds.Push(b);
                    }
                    else
                    {
                        if (activeBuilnds.Peek().distance > b.distance ||
                           activeBuilnds.Peek().height < b.height)
                        {
                            b.start = b.start + (b.end - activeBuilnds.Peek().end);
                            activeBuilnds.Push(b);
                        }
                    }
                }
            }
            return activeBuilnds.ToList();
        }
    }
}
