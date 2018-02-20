using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode418.Sentence_Screen_Fitting
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			//var r = s.WordsTyping(new string[] { "hello","world"}, 2,8);
			var r = s.WordsTyping(new string[] { "a", "bcd", "e" }, 3, 6);
			//var r = s.WordsTyping(new string[] { "I", "had", "apple", "pie" }, 4, 5);
			//var r = s.WordsTyping(new string[] { "ab", "c"}, 2, 4);
			//var r = s.WordsTyping(new string[] { "abc", "de", "f" }, 4, 6);
		}

		public class Solution
		{
			public int WordsTyping(string[] sentence, int rows, int cols)
			{
				int index = 0;
				var h = new HashSet<string>();
				int lines = 0;
				for (int rowsCount = 0; rowsCount < rows; ++rowsCount)
				{
					var freeSpace = cols;
					var line = string.Empty;
					while (true)
					{
						freeSpace -= sentence[index % sentence.Length].Length;
						if (freeSpace < 0) break;
						line += sentence[index % sentence.Length];
						index++;
						freeSpace--;
						if (freeSpace >= 0) line += " ";
					}
					if (!h.Add(line))
					{
						break;
					}
					lines++;
				}
				return rows / lines;
			}
		}

		//public class Solution
		//{
		//	public int WordsTyping(string[] sentence, int rows, int cols)
		//	{
		//		var s = string.Join(" ", sentence) + " ";
		//		int start = 0, l = s.Length;
		//		for (int i = 0; i < rows; i++)
		//		{
		//			start += cols;
		//			if (s[start % l] == ' ')
		//			{
		//				start++;
		//			}
		//			else
		//			{
		//				while (start > 0 && s[(start - 1) % l] != ' ')
		//				{
		//					start--;
		//				}
		//			}
		//		}

		//		return start / s.Length;
		//	}
		//}
	}
}
