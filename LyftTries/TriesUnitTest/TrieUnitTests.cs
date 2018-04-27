using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LyftTries;
using LyftTries.DataModel;

namespace TriesUnitTest
{
	[TestClass]
	public class TrieUnitTests
	{
		private readonly string inputFile = @"C:\Users\romarque\Desktop\trieInput.txt";

		[TestMethod]
		public void TestTries()
		{
			var config = new Configuration(inputFile);
			var trie = new Trie(config.GetWords());

			var resp = trie.FindWords("z");
			Assert.AreEqual(resp.Count, 4);
			Assert.IsTrue(resp.Contains("zone"));
			Assert.IsTrue(resp.Contains("zip"));
			Assert.IsTrue(resp.Contains("z"));
			Assert.IsTrue(resp.Contains("zoom"));
		}
	}
}
