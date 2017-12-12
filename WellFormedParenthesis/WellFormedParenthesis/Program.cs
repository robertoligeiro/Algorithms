using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellFormedParenthesis
{
	class Program
	{
		static void Main(string[] args)
		{
			var r = WellFormed(4);
		}

		public static List<string> WellFormed(int n)
		{
			var resp = new List<string>();
			WellFormed(n, n, resp, string.Empty);
			return resp;
		}
		public static void WellFormed(int left, int right, List<string> resp, string parc)
		{
			if (left == 0 && right == 0)
			{
				resp.Add(parc);
				return;
			}
			if (left > 0) WellFormed(left - 1, right, resp, parc + "(");
			if (right > left) WellFormed(left, right - 1, resp, parc + ")");
		}
	}
}
