using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode423.ReconstrOriginalDigsfromEnglish
{
    //https://leetcode.com/problems/reconstruct-original-digits-from-english/#/description
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            //var r = s.OriginalDigits("fviefuro");
            var r = s.OriginalDigits("owoztneoer");
        }

        public class Solution
        {
            public string OriginalDigits(string s)
            {
                var counter = new int[10];
                foreach (var c in s)
                {
                    switch (c)
                    {
                        case 'z': //only zero
                            counter[0]++;
                            break;
                        case 'w': //only two
                            counter[2]++;
                            break;
                        case 'u': //only four
                            counter[4]++;
                            break;
                        case 's': //only six/seven
                            counter[7]++;
                            break;
                        case 'x': //only six
                            counter[6]++;
                            break;
                        case 'g': //only eight
                            counter[8]++;
                            break;
                        case 'f': //only five/four
                            counter[5]++;
                            break;
                        case 'h': //only three/eight
                            counter[3]++;
                            break;
                        case 'i': //only five/six/eight/nine
                            counter[9]++;
                            break;
                        case 'o': //only zero/one/two/four
                            counter[1]++;
                            break;
                    }
                }

                counter[7] -= counter[6];
                counter[3] -= counter[8];
                counter[5] -= counter[4];
                counter[1] -= (counter[0] + counter[2] + counter[4]);
                counter[9] -= (counter[5] + counter[6] + counter[8]);

                var resp = new List<int>();
                for (int i = 0; i < counter.Length; ++i)
                {
                    var dig = Enumerable.Repeat(i, counter[i]);
                    resp.AddRange(dig);
                }

                return string.Join("",resp);
            }
        }
    }
}
