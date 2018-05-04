using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyftCountVerbUriStatus
{
	public class GetLog
	{
		public List<VerbUriStatus> Logs { get; }
		public GetLog(string path)
		{
			Logs = new List<VerbUriStatus>();

			using (var reader = new System.IO.StreamReader(path))
			{
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					var items = line.Split(',');
					var verbUriStatus = new VerbUriStatus() { verb = items[0], uri = items[1], status = int.Parse(items[2]) };
					Logs.Add(verbUriStatus);
				}
			}
		}
	}
}
