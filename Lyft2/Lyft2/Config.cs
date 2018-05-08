using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyft2
{
	public class Config
	{
		public List<WordAndID> Words = new List<WordAndID>();
		public List<string> TestCases = new List<string>();

		public Config(string configFilePath)
		{
			try
			{
				ReadConfiguration(configFilePath);
			}
			catch
			{
				throw new ArgumentException("Invalid Input..");
			}
		}

		private void ReadConfiguration(string configFilePath)
		{
			using (var streamReader = new StreamReader(configFilePath))
			{
				var lines = streamReader.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
				if (lines.Any())
				{
					var dictSize = int.Parse(lines[0]);
					var testCasesSize = int.Parse(lines[0]);
					var id = 1;
					int i = 2;
					for (; i <= dictSize + 1; ++i)
					{
						this.Words.Add(new WordAndID() { word = lines[i], id = id++});
					}

					//ToDo check if end is same as testCasesSize
					for (; i < lines.Length; ++i)
					{
						TestCases.Add(lines[i]);
					}
				}
			}
		}
	}
}
