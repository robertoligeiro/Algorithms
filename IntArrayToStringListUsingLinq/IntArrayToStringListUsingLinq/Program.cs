using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntArrayToStringListUsingLinq
{
	class Program
	{
		static void Main(string[] args)
		{
			var a = new int[] { 1, 2, 3, 4 };
			var s = new List<string>(a.ToList().Select(x => x.ToString()));
			var sjoin = string.Join("", s);
		}
	}
}
