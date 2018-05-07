using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplyStrings
{
	public class TestMultStrings
	{
		public static void TestWithStatic()
		{
			Console.WriteLine("Mutl: 123 x 34 = " + 123 * 34 +" returned: "+  MultStrings.Mult("123", "34") );
			Console.WriteLine("Mutl: 111 x 11 = " + 111 * 11 + " returned: " + MultStrings.Mult("111", "11"));
			Console.WriteLine("Mutl: 1000 x 1000 = " + 1000 * 1000 + " returned: " + MultStrings.Mult("1000", "1000"));
		}
	}
}
