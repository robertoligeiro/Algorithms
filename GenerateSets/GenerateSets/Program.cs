using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateSets
{
	class Program
	{
		static void Main(string[] args)
		{
			var r = Sets.GenerateSets(new int[] { 1,2,3});
		}

		public class Sets
		{
			public static List<List<int>> GenerateSets(int[] a)
			{
				var m = new Dictionary<int, int>();
				foreach (var i in a)
				{
					var count = 0;
					if (m.TryGetValue(i, out count))
					{
						m[i] = ++count;
					}
					else m.Add(i, 1);
				}
				var parc = new List<int>();
				var resp = new List<List<int>>();
				GenerateSets(m, parc, resp, 0);
				return resp;
			}

			private static void GenerateSets(Dictionary<int, int> m, List<int> parc, List<List<int>> resp, int start)
			{
				if (parc.Count > 0) resp.Add(new List<int>(parc));
				if (start >= m.Count) return;
				for (int i = start; i < m.Count; ++i)
				{
					if (m[m.ElementAt(i).Key]-- > 0)
					{
						parc.Add(m.ElementAt(i).Key);
						GenerateSets(m, parc, resp, i);
						parc.RemoveAt(parc.Count - 1);
					}
					m[m.ElementAt(i).Key]++;
				}
			}
		}
	}
}
