using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace LyftTries.DataModel
{
	public class Configuration : IConfiguration
	{
		private IList<string> words;
		private string configFilePath;
		public Configuration(string filePath)
		{
			this.configFilePath = filePath;
			ReadConfiguration();
		}
		private void ReadConfiguration()
		{
			using (var streamReader = new StreamReader(configFilePath))
			{
				var lines = streamReader.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
				if (lines.Any())
				{
					this.MaxWords = int.Parse(lines[0]);
					this.words = new List<string>();
					for (int i = 2; i < this.MaxWords+1; ++i)
					{
						this.words.Add(lines[i]);
					}
				}
			} 
		}
		public int MaxWords { get; set; }
		public IList<string> GetWords()
		{
			return this.words;
		}
	}
}
