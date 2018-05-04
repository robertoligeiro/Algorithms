using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyftCountVerbUriStatus
{
	public class VerbCounter
	{
		public Dictionary<string, UriStatusCounter> verbCounter = new Dictionary<string, UriStatusCounter>();

		public void Add(string verb, string uri, int status)
		{
			UriStatusCounter uriStatusCounter = null;
			if (this.verbCounter.TryGetValue(verb, out uriStatusCounter))
			{
				uriStatusCounter.Add(uri, status);
			}
			else
			{
				uriStatusCounter = new UriStatusCounter();
				uriStatusCounter.Add(uri, status);
				this.verbCounter.Add(verb, uriStatusCounter);
			}
		}

		public List<string> GetVerbCounterReport()
		{
			var resp = new List<string>();
			foreach (var t in this.verbCounter)
			{
				foreach (var s in t.Value.GetUriCounterReport())
				{
					resp.Add(string.Format("verb:{0} {1}", t.Key, s));
				}
			}

			return resp;
		}
	}
}
