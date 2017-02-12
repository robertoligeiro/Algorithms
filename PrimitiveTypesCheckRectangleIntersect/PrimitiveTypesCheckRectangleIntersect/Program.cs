using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimitiveTypesCheckRectangleIntersect
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = IntersectRectangle(new Rectangle() { x = 3, y = 2, width = 3, height = 3 }, new Rectangle() { x=1,y=1,width=3,height=2});
        }

        public class Rectangle
        {
            public int x { get; set; }
            public int y { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

        public static Rectangle IntersectRectangle(Rectangle r1, Rectangle r2)
        {
            if (IsIntersect(r1, r2))
            {
                return new Rectangle()
                {
                    x = Math.Max(r1.x, r2.x),
                    y = Math.Max(r1.y, r2.y),
                    width = Math.Min(r1.x + r1.width, r2.x + r2.width) - Math.Max(r1.x, r2.x),
                    height = Math.Min(r1.y + r1.height, r2.y + r2.height) - Math.Max(r1.y, r2.y),
                };
            }
            return null;
        }
        public static bool IsIntersect(Rectangle r1, Rectangle r2)
        {
            return r1.x <= r2.x + r2.width 
                && r1.x + r1.width >= r2.x 
                && r1.y <= r2.y + r2.height 
                && r1.y + r1.height >= r2.y;
        }
    }
}
