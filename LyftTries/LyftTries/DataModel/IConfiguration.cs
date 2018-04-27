using System.Collections.Generic;

namespace LyftTries.DataModel
{
	public interface IConfiguration
	{
		IList<string> GetWords();
		int MaxWords { get; }
	}
}
