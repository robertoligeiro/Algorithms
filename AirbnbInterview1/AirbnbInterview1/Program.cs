using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbInterview1
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = GetCidrRepresentation("128.0.0.5", 4);
        }

        //input: 128.0.0.5 => out {}
        public static List<string> GetCidrRepresentation(string ip, int range)
        {
            // do checks
            var resp = new List<string>();
            var ipArray = ip.Split('.');

            var last = ipArray.Last();
            var ipResp = new List<Tuple<int, int>>();
            var num = int.Parse(last);

            GetCidrRange(GetBits(num), num, ipResp, range);

            foreach (var s in ipResp)
            {
                resp.Add(ip + "/" + s.Item1.ToString() + " " + s.Item2.ToString());
            }
            return resp;
        }

        public static void GetCidrRange(string bits, int num, List<Tuple<int,int>> response, int range)
        {
            if (range == 0) return;
            var usedBits = 32;
            for (int i = bits.Length - 1; i >= 0; --i)
            {
                if (range == 0)
                {
                    return;
                }
                if (bits[i] == '0')
                {
                    usedBits--;
                    range -= 2;
                }
                else
                {
                    response.Add(new Tuple<int, int>(num, usedBits));
                    if(usedBits == 32) range--;
                    num++;
                    var newBits = GetBits(num);
                    GetCidrRange(newBits, num, response, range);
                    return;
                }
            }
        }
        public static string GetBits(int num)
        {
            var sb = new StringBuilder();
            while (num > 0)
            {
                if ((num & 1) == 1)
                {
                    sb.Append("1");
                }
                else
                {
                    sb.Append("0");
                }
                num = num >> 1;
            }
            var response = sb.ToString();
            return new string(response.Reverse().ToArray());
        }
    }
}
