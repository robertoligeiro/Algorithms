using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyftKeyStoreProjk
{
	class Program
	{
		static void Main(string[] args)
		{
			var keySotre = new LyftKeyStore();

			// testcases
			var put = keySotre.Put("key1", 5);
			Console.WriteLine(PrintPut(put));
			put = keySotre.Put("key2", 6);
			Console.WriteLine(PrintPut(put));

			var get = keySotre.Get("key1");
			Console.WriteLine(PrintGet(get));

			var getVersion = keySotre.Get("key1", 1);
			Console.WriteLine(PrintGetVesion(getVersion));
			getVersion = keySotre.Get("key2", 2);
			Console.WriteLine(PrintGetVesion(getVersion));

			put = keySotre.Put("key1", 7);
			Console.WriteLine(PrintPut(put));

			getVersion = keySotre.Get("key1", 1);
			Console.WriteLine(PrintGetVesion(getVersion));
			getVersion = keySotre.Get("key1", 2);
			Console.WriteLine(PrintGetVesion(getVersion));
			getVersion = keySotre.Get("key1", 3);
			Console.WriteLine(PrintGetVesion(getVersion));

			get = keySotre.Get("key4");
			Console.WriteLine(PrintGet(get));

			getVersion = keySotre.Get("key1", 4);
			Console.WriteLine(PrintGetVesion(getVersion));
		}

		public static string PrintPut(Tuple<string, Tuple<int, int>> t)
		{
			return "PUT (#" + t.Item2.Item1 + ") " + t.Item1 + " = " + t.Item2.Item2;
		}

		public static string PrintGet(Tuple<string, Tuple<int, int>> t)
		{
			return "Get " + t.Item1 + " = " + t.Item2.Item2;
		}

		public static string PrintGetVesion(Tuple<string, Tuple<int, int>> t)
		{
			return "GET " + t.Item1 + " (#" + t.Item2.Item1 + ") = " + t.Item2.Item2;
		}

		public class LyftKeyStore
		{
			private int GlobalVersion = 1;
			private Dictionary<string, SortedDictionary<int, int>> data = new Dictionary<string, SortedDictionary<int, int>>();


			public Tuple<string, Tuple<int, int>> Put(string key, int val)
			{
				SortedDictionary<int, int> sortedDictionary = null;
				var newVersion = this.GlobalVersion++;
				if (this.data.TryGetValue(key, out sortedDictionary))
				{
					sortedDictionary.Add(newVersion, val);
				}
				else
				{
					sortedDictionary = new SortedDictionary<int, int>();
					sortedDictionary.Add(newVersion, val);
					this.data.Add(key, sortedDictionary);
				}

				return new Tuple<string, Tuple<int,int>>(key, new Tuple<int, int>(newVersion, val));
			}

			public Tuple<string, Tuple<int, int>> Get(string key)
			{
				SortedDictionary<int, int> sortedDictionary = null;
				if (this.data.TryGetValue(key, out sortedDictionary))
				{
					return new Tuple<string, Tuple<int, int>>(key, new Tuple<int, int>(0, sortedDictionary.Last().Value));
				}

				return new Tuple<string, Tuple<int, int>>(string.Empty, new Tuple<int, int>(0,0));
				//return string.Empty;
			}

			public Tuple<string, Tuple<int, int>> Get(string key, int version)
			{
				SortedDictionary<int, int> sortedDictionary = null;
				if (this.data.TryGetValue(key, out sortedDictionary))
				{
					// I've checked with the interviewer and we agreed that if the version is 
					// before the first version for the key, return the most recent one.
					if (sortedDictionary.First().Key > version)
					{
						return new Tuple<string, Tuple<int, int>>(key, new Tuple<int, int>(sortedDictionary.Last().Key, sortedDictionary.Last().Value));
					}

					var val = 0;
					if (sortedDictionary.TryGetValue(version, out val))
					{
						return new Tuple<string, Tuple<int, int>>(key, new Tuple<int, int>(version, val));
					}

					var keys = sortedDictionary.Keys.ToList();
					var l = 0;
					var r = keys.Count() - 1;
					var k = 0;
					while (l <= r)
					{
						var mid = l + (r - l) / 2;
						if (keys[mid] < version)
						{
							k = mid;
							l = mid + 1;
						}
						else
						{
							r = mid - 1;
						}
					}
					return new Tuple<string, Tuple<int, int>>(key, new Tuple<int, int>(version, sortedDictionary[keys[k]]));
				}

				return new Tuple<string, Tuple<int, int>>(string.Empty, new Tuple<int, int>(0, 0));
			}
		}
	}
}
