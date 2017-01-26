using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyHuffmanAlgo
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new List<Tuple<char, int>>();
            a.Add(new Tuple<char, int>('a', 8));
            a.Add(new Tuple<char, int>('b', 2));
            a.Add(new Tuple<char, int>('c', 1));
            a.Add(new Tuple<char, int>('d', 3));
            a.Add(new Tuple<char, int>('e', 7));
            a.Add(new Tuple<char, int>('f', 4));
            a.Add(new Tuple<char, int>('g', 2));

            var r = GetCodeForFrequencies.GetFrequencies(a);
        }

        public class HuffmanNode: IComparable
        {
            public int freq { get; set; }
            public string name { get; set; }
            public HuffmanNode left { get; set; }
            public HuffmanNode right { get; set; }
            public int CompareTo(object obj)
            {
                if (obj == null) return 1;
                var other = obj as HuffmanNode;
                return this.freq < other.freq ? 1 : -1;
            }
        }

        public class GetCodeForFrequencies
        {
            public static List<Tuple<char, string>> GetFrequencies(List<Tuple<char, int>> freq)
            {
                var nodes = new List<HuffmanNode>();
                foreach (var t in freq)
                {
                    var huffNode = new HuffmanNode() { freq = t.Item2, name = t.Item1.ToString() };
                    nodes.Add(huffNode);
                }

                while (nodes.Count > 1)
                {
                    nodes.Sort();
                    var n1 = nodes.LastOrDefault();
                    nodes.RemoveAt(nodes.Count - 1);
                    var n2 = nodes.LastOrDefault();
                    nodes.RemoveAt(nodes.Count - 1);

                    nodes.Add(new HuffmanNode() { name = n1.name + n2.name, freq = n1.freq + n2.freq, left = n1, right = n2 });
                }

                var resp = new List<Tuple<char, string>>();
                GetCodes(nodes[0], resp, string.Empty);
                return resp;
            }

            public static void GetCodes(HuffmanNode r, List<Tuple<char, string>> resp, string code)
            {
                if (r.right == null && r.left == null)
                {
                    resp.Add(new Tuple<char, string>(r.name.ToCharArray()[0], code));
                    return;
                }

                if (r.left != null)
                {
                    GetCodes(r.left, resp, code + "0");
                }
                if (r.right != null)
                {
                    GetCodes(r.right, resp, code + "1");
                }
            }
        }
    }
}
