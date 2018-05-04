using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyftCountVerbUriStatus
{
	public class UriStatusCounter
	{
		public Dictionary<string, StatusCounter> uriStatusCounter = new Dictionary<string, StatusCounter>();

		public void Add(string uri, int status)
		{
			StatusCounter statusCounter = null;
			if (this.uriStatusCounter.TryGetValue(uri, out statusCounter))
			{
				statusCounter.Add(status);
			}
			else
			{
				statusCounter = new StatusCounter();
				statusCounter.Add(status);
				this.uriStatusCounter.Add(uri, statusCounter);
			}
		}

		public List<string> GetUriCounterReport()
		{
			var resp = new List<string>();
			foreach (var t in this.uriStatusCounter)
			{
				foreach (var s in t.Value.GetStatusCounterReport())
				{
					resp.Add(string.Format("uri:{0} {1}", t.Key, s));
				}
			}

			return resp;
		}
	}
}
