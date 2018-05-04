using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyftCountVerbUriStatus
{
	public class VerbUriStatusReport
	{
		private VerbCounter data = new VerbCounter();

		public VerbUriStatusReport(List<VerbUriStatus> items)
		{
			if (items == null) throw new ArgumentException("list can't be null");
			foreach (var i in items)
			{
				data.Add(i.verb, i.uri, i.status);
			}
		}

		public List<string> GetReport()
		{
			return data.GetVerbCounterReport();
		}

		public void PrintReport()
		{
			foreach (var r in this.GetReport())
			{
				Console.WriteLine(r);
			}
			Console.WriteLine("END REPORT");
			Console.WriteLine("");
		}
	}
}
