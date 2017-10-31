using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode468.Validate_IP_Address
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.ValidIPAddress("10.0.0.1");
			r = s.ValidIPAddress("256.256.256.256");
			r = s.ValidIPAddress("10.0.0.01");
			r = s.ValidIPAddress("10.");
			r = s.ValidIPAddress("20EE:FFb8:85a3:0:0:8A2E:0370:7334");
		}

		public class Solution
		{
			private static string neither = "Neither";
			private static string ipv4 = "IPv4";
			private static string ipv6 = "IPv6";
			public string ValidIPAddress(string IP)
			{
				if (string.IsNullOrWhiteSpace(IP)) return neither;
				if (IP.IndexOf('.') > 0) return IsValidIpv4(IP);
				if (IP.IndexOf(':') > 0) return IsValidIpv6(IP);
				return neither;
			}

			private string IsValidIpv4(string ip)
			{
				var tokens = ip.Split('.');
				if (tokens.Length != 4) return neither;
				foreach (var t in tokens)
				{
					var val = 0;
					if (!int.TryParse(t, out val)) return neither;
					if (val > 255 || val < 0) return neither;
					if (val < 9 && t.Length > 1) return neither;
					if (t.Length > 1 && t[0] == '0') return neither;
				}
				return ipv4;
			}
			private string IsValidIpv6(string ip)
			{
				var tokens = ip.Split(':');
				if (tokens.Length != 8) return neither;
				foreach (var t in tokens)
				{
					var val = 0;
					if (!int.TryParse(t, System.Globalization.NumberStyles.HexNumber, null, out val)) return neither;
					if (string.IsNullOrWhiteSpace(t)) return neither;
					if (t.Length > 4) return neither;
				}
				return ipv6;
			}
		}
	}
}
