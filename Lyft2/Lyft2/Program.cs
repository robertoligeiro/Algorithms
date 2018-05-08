using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyft2
{
	class Program
	{
		static void Main(string[] args)
		{
			var autoCompleteSystem = new AutoCompleteSystem(args[0]);
			autoCompleteSystem.RunTestCases();
		}
	}
}
