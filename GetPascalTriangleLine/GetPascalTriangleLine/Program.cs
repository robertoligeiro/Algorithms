using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetPascalTriangleLine
{
	class Program
	{
		static void Main(string[] args)
		{
			var pascalTriangle = new List<List<int>>();
			for (int i = 0; i < 10; ++i)
			{
				pascalTriangle.Add(Pascal(i));
			}
		}

		public static List<int> Pascal(int n)
		{
			var resp = new List<int>() { 1 };
			for (int i = 0; i < n; ++i)
			{
				resp = Pascal(resp); 
			}
			return resp;
		}

		public static List<int> Pascal(List<int> p)
		{
			var resp = new List<int>();
			for (int i = 0; i <= p.Count; ++i)
			{
				if (i == 0 || i == p.Count) resp.Add(1);
				else resp.Add(p[i] + p[i - 1]);
			}
			return resp;
		}
	}
}
