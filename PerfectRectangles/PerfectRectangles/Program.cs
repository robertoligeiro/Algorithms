using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectRectangles
{
    class Program
    {
        //public bool RectIntersect(Rectangle R1, Rectangle R2)
        //{
        //    if ((R1.TopLeft.x > R2.BottomRight.x) || (R1.BottomRight.x < R2.TopLeft.x) || (R1.TopLeft.y > R2.BottomRight.y) ||
        //         (R1.BottomRight.y < R2.TopLeft.y))
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
        static void Main(string[] args)
        {
            var s = new Solution();
            int[,] a = new int[,] { { 1, 1, 3, 3 } , { 3, 1, 4, 2 }, { 3, 2, 4, 4 } , { 1, 3, 2, 4 }, { 2, 3, 3, 4 } };
            var b = s.IsRectangleCover(a);
        }

        public class Solution
        {
            public bool IsRectangleCover(int[,] rectangles)
            {
                var rectanglesList = new List<Rectangle>();
                for (int i = 0; i < rectangles.Length / 4; ++i)
                {
                    var bottonLeft = new Tuple<int, int>(rectangles[i, 0], rectangles[i, 1]);
                    var topRight = new Tuple<int, int>(rectangles[i, 2], rectangles[i, 3]);
                    rectanglesList.Add(new Rectangle(bottonLeft, topRight));
                }

                var coverRectange = FindCoverRectangle(rectanglesList);
                var pointsDictionary = new HashSet<Tuple<int, int>>();
                int totArea = 0;
                foreach (var r in rectanglesList)
                {
                    totArea += r.Area();
                    foreach (var p in r.GetCoords())
                    {
                        if (pointsDictionary.Contains(p))
                        {
                            pointsDictionary.Remove(p);
                        }
                        else
                        {
                            pointsDictionary.Add(p);
                        }
                    }
                }

                if (pointsDictionary.Count != 4) return false;
                foreach (var point in pointsDictionary)
                {
                    if (!coverRectange.HasPoint(point)) return false;
                }

                return totArea == coverRectange.Area();
            }
            public class Rectangle
            {
                public Tuple<int, int> TopLeft { get; set; }
                public Tuple<int, int> TopRight { get; set; }
                public Tuple<int, int> BottomLeft { get; set; }
                public Tuple<int, int> BottomRight { get; set; }

                public List<Tuple<int, int>> GetCoords()
                {
                    return new List<Tuple<int, int>>() { this.TopLeft, this.TopRight, this.BottomLeft, this.BottomRight };
                }
                public Rectangle(Tuple<int, int> bottonLeft, Tuple<int, int> topRight)
                {
                    this.BottomLeft = bottonLeft;
                    this.TopRight = topRight;
                    this.TopLeft = new Tuple<int, int> (this.BottomLeft.Item1, this.TopRight.Item2);
                    this.BottomRight = new Tuple<int, int> (this.TopRight.Item1, this.BottomLeft.Item2);
                }

                public bool HasPoint(Tuple<int, int> p)
                {
                    if (this.BottomLeft.Equals(p)) return true;
                    if (this.BottomRight.Equals(p)) return true;
                    if (this.TopLeft.Equals(p)) return true;
                    if (this.TopRight.Equals(p)) return true;
                    return false;
                }

                public int Area()
                {
                    return (this.BottomRight.Item1 - this.BottomLeft.Item1) * (this.TopLeft.Item2 - this.BottomLeft.Item2);
                }
            }

            public Rectangle FindCoverRectangle(List<Rectangle> retangles)
            {
                int minX = int.MaxValue;
                int maxX = int.MinValue;
                int minY = int.MaxValue;
                int maxY = int.MinValue;

                foreach (var r in retangles)
                {
                    minX = Math.Min(minX, r.BottomLeft.Item1);
                    maxX = Math.Max(maxX, r.BottomRight.Item1);
                    minY = Math.Min(minY, r.BottomLeft.Item2);
                    maxY = Math.Max(maxY, r.TopRight.Item2);
                }

                return new Rectangle(new Tuple<int, int> (minX, minY ), new Tuple<int, int>(maxX, maxY ));
            }
        }
    }
}
