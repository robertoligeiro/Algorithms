using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyftCountVerbUriStatus
{
	public class StatusCounter
	{
		public Dictionary<int, int> statusCounter = new Dictionary<int, int>();
		public void Add(int status)
		{
			var count = 0;
			if (this.statusCounter.TryGetValue(status, out count))
			{
				this.statusCounter[status] = ++count;
			}
			else
			{
				this.statusCounter.Add(status, 1);
			}
		}

		public List<string> GetStatusCounterReport()
		{
			var resp = new List<string>();
			foreach (var t in statusCounter)
			{
				resp.Add(string.Format("status:{0} count:{1}", t.Key, t.Value));
			}

			return resp;
		}
	}
}
