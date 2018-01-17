using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
	class Program
	{
		static void Main(string[] args)
		{
			var s0 = Singleton.GetIntance();
			var r0 = s0.Inc();

			var s1 = Singleton.GetIntance();
			var r1 = s1.Inc();
		}

		public class Singleton
		{
			private int count = 0;
			private static Singleton intance = new Singleton();
			private Singleton()
			{
				count = 10;
			}

			public static Singleton GetIntance()
			{
				return intance;
			}

			public int Inc()
			{
				return ++count;
			}
		}
	}
}
