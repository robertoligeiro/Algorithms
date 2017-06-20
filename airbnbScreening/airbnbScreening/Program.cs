using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airbnbScreening
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new List<List<int>>() { new List<int>(), new List<int>() { 1, 2, 3 }, new List<int>(), new List<int>() { 4, 5 } };
            var myTwoDIterator = new TwoDIterator(data);
            var b = myTwoDIterator.HasNext();
            Console.WriteLine("b returned {0}", b);
            var r = myTwoDIterator.Next();
            Console.WriteLine("r returned {0}", r);
            myTwoDIterator.Delete();
            Console.ReadKey();
        }

        public class TwoDIterator
        {
            private Tuple<int, int> nextValue;
            private Tuple<int, int> prevValue;
            private List<List<int>> data;

            public TwoDIterator(List<List<int>> inputData)
            {
                this.data = inputData;
                this.GrabNext(0, 0);
            }

            public bool HasNext()
            {
                return this.nextValue != null;
            }

            public int Next()
            {
                if (this.nextValue == null) throw new Exception("Not available data...");

                var ret = this.data[this.nextValue.Item1][this.nextValue.Item2];
                this.prevValue = new Tuple<int, int>(this.nextValue.Item1, this.nextValue.Item2);
                GrabNext(this.nextValue.Item1, this.nextValue.Item2);
                return ret;
            }

            public void Delete()
            {
                if (this.prevValue == null) return;
                this.data[prevValue.Item1].RemoveAt(prevValue.Item2);
                if (this.data[prevValue.Item1].Count > 0)
                {
                    this.nextValue = new Tuple<int, int>(this.nextValue.Item1, this.nextValue.Item2 - 1);
                }
            }

            private void GrabNext(int row, int col)
            {
                if (col + 1 < this.data[row].Count)
                {
                    this.nextValue = new Tuple<int, int>(row, col + 1);
                    return;
                }
                for (int r = row + 1; r < this.data.Count; ++r)
                {
                    if (this.data[r].Count > 0)
                    {
                        this.nextValue = new Tuple<int, int>(r, 0);
                        return;
                    }
                }

                this.nextValue = null;
            }
        }
    }
}
