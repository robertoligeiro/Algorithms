using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyft2
{
	public class AutoCompleteSystem
	{
		private const int MaxWords = 5;
		private Trie trie = new Trie();
		private Config config;
		public AutoCompleteSystem(string path)
		{
			this.config = new Config(path);
			foreach (var w in config.Words)
			{
				trie.AddWord(w.word, w.id);
			}
		}

		public void RunTestCases()
		{
			foreach (var w in config.TestCases)
			{
				var r = trie.FindWord(w);
				var words = GetWords(r);
				DisplayTestCaseResult(w, words);
			}
		}

		private void DisplayTestCaseResult(string testcase, List<WordAndID> wordsAndIds)
		{
			Console.WriteLine(testcase + ":");
			foreach (var wordAndId in wordsAndIds)
			{
				Console.WriteLine(string.Format("{0} ({1})", wordAndId.word, wordAndId.id));
			}
		}

		private List<WordAndID> GetWords(List<Tuple<string, WordRank>> wordsRanked)
		{
			wordsRanked.Sort(SortWords);
			var resp = new List<WordAndID>();
			int i = 0;
			while (i < wordsRanked.Count && resp.Count < MaxWords)
			{
				resp.Add(new WordAndID() { word = wordsRanked[i].Item1, id = wordsRanked[i].Item2.id });
				i++;
			}
			return resp;
		}


		private int SortWords(Tuple<string, WordRank> a, Tuple<string, WordRank> b)
		{
			//if freq diff, return based on freq
			if (a.Item2.frequency.CompareTo(b.Item2.frequency) != 0)
			{
				return b.Item2.frequency.CompareTo(a.Item2.frequency);
			}
			//else, return based on id
			return a.Item2.id.CompareTo(b.Item2.id);
		}
	}
}
