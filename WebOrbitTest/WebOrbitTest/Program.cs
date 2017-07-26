using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebOrbitTest
{
    class Program
    {
        public static void Main()
        {
            //Test: FindMissing
            int[] ARRAY_1 = new int[] { 3, 5, 4, 9, 1, 8, 6, 2, 10 };
            int[] ARRAY_2 = new int[] { 6, 7, 5, 3, 9, 8, 10, 2, 4 };
            int[] ARRAY_3 = new int[] { 4, 1, 2, 5, 7, 8, 6, 9, 3 };

            int MISSING_1 = 7;
            int MISSING_2 = 1;
            int MISSING_3 = 10;
            var source = GenerateRandomWithOneMissing(40);
            var resp = FindMissing(source);
            Console.WriteLine("Testing FindMissing Function...");
            Console.WriteLine("Array1 Missing " + MISSING_1.ToString() + " FindMissing.Execute returned: " + FindMissing(ARRAY_1).ToString());
            Console.WriteLine("Array2 Missing " + MISSING_2.ToString() + " FindMissing.Execute returned: " + FindMissing(ARRAY_2).ToString());
            Console.WriteLine("Array3 Missing " + MISSING_3.ToString() + " FindMissing.Execute returned: " + FindMissing(ARRAY_3).ToString());
        }

        //Generate a random MaxNumber - 1 length array.  Elements range from 1 to MaxNumber (inclusive), leave a element missing.
        public static int[] GenerateRandomWithOneMissing(int maxNumber)
        {
            var rand = new Random();
            var source = Enumerable.Range(1, maxNumber).ToArray();
            for (int i = 1; i < maxNumber; i++)
            {
                var from = rand.Next(1, maxNumber);
                var to = rand.Next(1, maxNumber);
                var t = source[from];
                source[from] = source[to];
                source[to] = t;
            }

            var ret = new int[maxNumber - 1];
            Array.Copy(source, ret, source.Length - 1);
            return ret;
        }

        // 3,2,1,4
        //Arrays have N elements ranging from 1 to N+1. Return the missing number
        public static int FindMissing(int[] arrayOfInt)
        {
            var h = new HashSet<int>(arrayOfInt);
            for (int i = 1; i <= arrayOfInt.Length + 1; ++i)
            {
                if (h.Add(i)) return i;
            }
            throw new ArgumentException("not missing element..");
        }

        //    public static void Main()
        //    {
        //        Console.WriteLine("Testing GenerateRandomWithOneMissing Function...");

        //        for (int i = 1; i <= 5; i++)
        //        {
        //            Console.WriteLine("Test " + i.ToString() + ": " + GenerateRandomWithOneMissing(10).ToCommaString());
        //        }
        //    }

        //    //Generate a random MaxNumber - 1 length array.  Elements range from 1 to MaxNumber (inclusive), leave a element missing.
        //    public static int[] GenerateRandomWithOneMissing(int maxNumber)
        //    {
        //        var rand = new Random();
        //        var source = Enumerable.Range(1, maxNumber).ToArray();
        //        for (int i = 1; i < maxNumber; i++)
        //        {
        //            var from = rand.Next(1, maxNumber);
        //            var to = rand.Next(1, maxNumber);
        //            var t = source[from];
        //            source[from] = source[to];
        //            source[to] = t;
        //        }

        //        var ret = new int[maxNumber - 1];
        //        Array.Copy(source, ret, source.Length - 1);
        //        return ret;
        //    }

        //}

        //public static class IntArrayHelper
        //{
        //    public static string ToCommaString(this int[] anArray)
        //    {
        //        string output = string.Empty;
        //        foreach (int i in anArray)
        //        {
        //            if (output.Length != 0)
        //            {
        //                output += ", ";
        //            }

        //            output += i.ToString();
        //        }

        //        return output;
        //    }

        //    class DateRange
        //    {
        //        public DateRange(DateTime start, DateTime end)
        //        {
        //            this.Start = start;
        //            this.End = end;
        //        }

        //        public DateTime Start;
        //        public DateTime End;

        //        public static DateRange Parse(string s)
        //        {
        //            var sList = s.Split('-');
        //            Debug.Assert(sList.Count() == 2);

        //            var start = DateTime.Parse(sList[0].Trim());
        //            var end = DateTime.Parse(sList[1].Trim());

        //            return new DateRange(start, end);
        //        }
        //    }

        //    public static void Main()
        //    {
        //        Console.WriteLine("Testing Overlap Function...");

        //        Console.WriteLine("Expect: True  | Result: " + DoesOverlap(DateRange.Parse("1/15/2016 - 2/15/2016"), DateRange.Parse("2/1/2016 - 2/20/2016")));
        //        Console.WriteLine("Expect: False | Result: " + DoesOverlap(DateRange.Parse("1/15/2016 - 2/15/2016"), DateRange.Parse("2/16/2016 - 2/20/2016")));
        //        Console.WriteLine("Expect: False | Result: " + DoesOverlap(DateRange.Parse("3/15/2016 - 4/15/2016"), DateRange.Parse("2/1/2016 - 2/20/2016")));
        //        Console.WriteLine("Expect: True  | Result: " + DoesOverlap(DateRange.Parse("1/20/2016 - 2/5/2016"), DateRange.Parse("1/15/2016 - 2/15/2016")));
        //        Console.WriteLine("Expect: True  | Result: " + DoesOverlap(DateRange.Parse("1/15/2016 - 2/15/2016"), DateRange.Parse("1/5/2016 - 2/20/2016")));
        //        Console.WriteLine("Expect: True  | Result: " + DoesOverlap(DateRange.Parse("1/15/2016 - 3/15/2016"), DateRange.Parse("1/25/2016 - 2/20/2016")));
        //    }

        //    // Returns true if input date ranges overlap
        //    static bool DoesOverlap(DateRange range1, DateRange range2)
        //{
        //    if (range1.Start == range2.Start) return true;
        //    var firstEvent = range1.Start < range2.Start ? range1 : range2;
        //    var secondEvent = range1.Start < range2.Start ? range2 : range1;
        //    return firstEvent.End >= secondEvent.Start;
        //}

    }

}
