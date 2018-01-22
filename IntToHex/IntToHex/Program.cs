using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntToHex
{
	class Program
	{
		static void Main(string[] args)
		{
			var r = ItoHex(100);
		}

		public static string ItoHex(int n)
		{
			var resp = new StringBuilder();
			var m = new Dictionary<int, char>() {
				{ 0,'0'},
				{ 1,'1'},
				{ 2,'2'},
				{ 3,'3'},
				{ 4,'4'},
				{ 5,'5'},
				{ 6,'6'},
				{ 7,'7'},
				{ 8,'8'},
				{ 9,'9'},
				{ 10,'A'},
				{ 11,'B'},
				{ 12,'C'},
				{ 13,'D'},
				{ 14,'E'},
				{ 15,'F'},
			};

			while (n > 0)
			{
				var v = n / 16;
				n %=16;
				if (v > 0)
				{
					resp.Append(v);
				}
				else
				{
					resp.Append(m[n]);
				}
				if (v == 0) break;
			}
			return resp.ToString();
		}
	}
}
