using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsGetValidIps
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = GetValidIps("19216811");
        }

        public static List<string> GetValidIps(string s)
        {
            var r = new List<string>();
            for (int i1 = 0; i1 < 3; ++i1)
            {
                for (int i2 = 0; i2 < 3; ++i2)
                {
                    for (int i3 = 0; i3 < 3; ++i3)
                    {
                        string ip = string.Empty;
                        if (IsValidIp(i1, i2, i3, s, ref ip))
                        {
                            r.Add(ip);
                        }
                    }
                }
            }
            return r;
        }

        public static bool IsValidIp(int i1, int i2, int i3, string s, ref string ip)
        {
            s = new string(s.Reverse().ToArray());
            var s4 = s.Substring(0, i3+1);
            s4 = new string(s4.Reverse().ToArray());
            var start = i3 + 1;
            if (Convert.ToInt32(s4) > 255) return false;
            var s3 = s.Substring(start, i2+1);
            s3 = new string(s3.Reverse().ToArray());
            start += i2 + 1;
            if (Convert.ToInt32(s3) > 255) return false;
            var s2 = s.Substring(start, i1+1);
            s2 = new string(s2.Reverse().ToArray());
            start += i1 + 1;
            if (Convert.ToInt32(s2) > 255) return false;
            var s1 = s.Substring(start);
            s1 = new string(s1.Reverse().ToArray());
            if (s1 == string.Empty || Convert.ToInt32(s1) > 255) return false;

            ip = s1 + "." + s2 + "." + s3 + "." + s4;
            return true;
        }
    }
}
