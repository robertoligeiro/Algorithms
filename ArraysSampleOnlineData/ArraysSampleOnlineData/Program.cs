using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ArraysSampleOnlineData
{
    class Program
    {
        static void Main(string[] args)
        {
            var fs = new FileStream(@"C: \Users\romarque\Pictures\amazom_puma.PNG", FileMode.Open, FileAccess.Read);
            var r = ReadRandomData(fs, 100);

            using (Image image = Image.FromStream(new MemoryStream(r)))
            {
                image.Save("output.jpg", ImageFormat.Jpeg);  // Or Png
            }
        }

        public static byte[] ReadRandomData(FileStream f, int k)
        {
            var bArray = new byte[k+1];
            int byteRead = f.Read(bArray, 0, k);
            var b = new byte[1];
            var rand = new Random();
            while ((byteRead = f.Read(b, 0, 1)) > 0)
            {
                int index = rand.Next(0, k);
                bArray[index] = b[0];
            }

            return bArray;
        }
    }
}
