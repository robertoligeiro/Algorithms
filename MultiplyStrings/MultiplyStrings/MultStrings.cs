using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplyStrings
{
	public class MultStrings
	{
		public static string Mult(string x, string y)
		{
			var resp = new int[x.Length + y.Length];

			for (int i = x.Length-1; i >=0 ; --i)
			{
				for (int j = y.Length-1; j >= 0; --j)
				{
					var p0 = i + j + 1;
					var p1 = i + j;
					var mult = (x[i] - '0') * (y[j] - '0');
					var sum = resp[p0] + mult;
					resp[p0] = sum % 10;
					resp[p1] += (sum / 10);
				}
			}

			var stringResp = string.Join("", resp);
			return stringResp.TrimStart('0');
		}
	}
}
