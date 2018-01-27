using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode271.Encode_and_Decode_Strings
{
	class Program
	{
		//https://leetcode.com/problems/encode-and-decode-strings/description/
		static void Main(string[] args)
		{
			var codec = new Codec();
			var s = codec.encode(new List<string>() { "abc", "def", "ghi" });
			var r = codec.decode(s);
		}
		public class Codec
		{
			// Encodes a list of strings to a single string.
			public string encode(IList<string> strs)
			{
				var sb = new StringBuilder();
				foreach (var s in strs)
				{
					sb.Append(s.Replace("#", "##") + " # ");
				}
				return sb.ToString();
			}

			// Decodes a single string to a list of strings.
			public IList<string> decode(string s)
			{
				var resp = new List<string>();
				if (string.IsNullOrEmpty(s)) return resp;

				var subs = s.Split(new string[] { " # "}, StringSplitOptions.None);
				for (var i = 0; i < subs.Length - 1; ++i)
				{
					resp.Add(subs[i].Replace("##", "#"));
				}
				return resp;
			}
		}
	}
}
