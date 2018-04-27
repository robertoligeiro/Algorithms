using LyftTries.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyftTries
{
	class Program
	{
		static void Main(string[] args)
		{
			var config = new Configuration(args[0]);
			var trie = new Trie(config.GetWords());
			var r = trie.FindWords("z");
		}
	}
}
