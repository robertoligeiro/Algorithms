using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionToString
{
	class Program
	{
		static void Main(string[] args)
		{
			var r = DivToString(4, 2);
			r = DivToString(1, 2);
			r = DivToString(10, 2);
			r = DivToString(111, 8);
		}

		public static string DivToString(int n, int d)
		{
			var added = false;
			var resp = new StringBuilder();
			while (n > 0)
			{
				var val = n / d;
				var rest = n % d;
				resp.Append(val);
				if (!added && rest > 0)
				{
					resp.Append(",");
				}
				added = true;
				n = rest * 10;
			}
			return resp.ToString();
		}
	}
}
