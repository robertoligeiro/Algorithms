using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinternalNm
{
	public class Tinternal
	{
		internal class TinternalInternal
		{
			public int v;
			public TinternalInternal(int v)
			{
				this.v = v;
			}
		}

		private TinternalInternal t = new TinternalInternal(2);
		public void printInternal()
		{
			Console.WriteLine(this.t.v);
		}
	}
}
