using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode676.Implement_Magic_Dictionary
{
	class Program
	{
		//https://leetcode.com/problems/implement-magic-dictionary/description/
		static void Main(string[] args)
		{
			var m = new MagicDictionary();
			m.BuildDict(new string[] { "hello", "leetcode" });
			var b = m.Search("hello");
			b = m.Search("hello");
			b = m.Search("hhllo");
			b = m.Search("hell");
			b = m.Search("leetcoded");
		}
		public class MagicDictionary
		{
			private HashSet<string> words;
			private HashSet<int> sizes;

			/** Initialize your data structure here. */
			public MagicDictionary()
			{
			}

			/** Build a dictionary through a list of words */
			public void BuildDict(string[] dict)
			{
				words = new HashSet<string>(dict);
				sizes = new HashSet<int>(dict.Select(x => x.Length));
			}

			/** Returns if there is any word in the trie that equals to the given word after modifying exactly one character */
			public bool Search(string word)
			{
				if (!sizes.Contains(word.Length)) return false;

				var wordArray = word.ToArray();
				for (int i = 0; i < wordArray.Length; ++i)
				{
					var prev = wordArray[i];
					for (var c = 'a'; c <= 'z'; ++c)
					{
						if (c != prev)
						{
							wordArray[i] = c;
							if (words.Contains(new string(wordArray))) return true;
						}
					}
					wordArray[i] = prev;
				}
				return false;
			}
		}
	}
}
