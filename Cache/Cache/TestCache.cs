using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache
{
	public class TestCache
	{
		public static void TestStaticData()
		{
			var testData = new List<Tuple<int, string>>()
			{
				new Tuple<int, string>(1,"one"),
				new Tuple<int, string>(2,"two"),
				new Tuple<int, string>(3,"three"),
				new Tuple<int, string>(4,"four"),
			};

			var lruCache = new LruCache(3);
			foreach (var t in testData)
			{
				Console.WriteLine(string.Format("adding id: {0}, value: {1}", t.Item1, t.Item2));
				lruCache.Add(t.Item1, t.Item2);
				Console.WriteLine("cache state:");
				lruCache.PrintCacheValue();
			}

			//turn it to 2,3,4
			Console.WriteLine("turn cache to 2,3,4 > lookUp(3), lookUp(2)");
			lruCache.LookUp(3);
			lruCache.LookUp(2);
			Console.WriteLine("cache state:");
			lruCache.PrintCacheValue();
		}
	}
}
