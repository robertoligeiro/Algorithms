using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode535.Encode_and_Decode_TinyURL
{
	class Program
	{
		//https://leetcode.com/problems/encode-and-decode-tinyurl
		static void Main(string[] args)
		{
		}
		public class Codec
		{
			private Dictionary<string, string> map = new Dictionary<string, string>();

			// Encodes a URL to a shortened URL
			public string encode(string longUrl)
			{
				var key = "http://tinyurl.com/" + Base64Encode(longUrl).Substring(0, 6);
				if (!map.ContainsKey(key))
				{
					map.Add(key, longUrl);
				}
				return key;
			}

			// Decodes a shortened URL to its original URL.
			public string decode(string shortUrl)
			{
				if (map.ContainsKey(shortUrl)) return map[shortUrl];
				return string.Empty;
			}

			public static string Base64Encode(string plainText)
			{
				var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
				return System.Convert.ToBase64String(plainTextBytes);
			}
		}

	}
}
