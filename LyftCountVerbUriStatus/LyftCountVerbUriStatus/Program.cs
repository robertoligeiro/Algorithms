using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyftCountVerbUriStatus
{
	class Program
	{
		static void Main(string[] args)
		{
			TestReportSystem.TestWithoutLogReader();
			TestReportSystem.TestWithLogReader();
		}

		public class TestReportSystem
		{
			public static void TestWithoutLogReader()
			{
				var report = new VerbUriStatusReport(new List<VerbUriStatus>()
				{
					new VerbUriStatus() { verb="get", uri="g.com", status=200},
					new VerbUriStatus() { verb="get", uri="g.com", status=404},
					new VerbUriStatus() { verb="post", uri="g.com", status=200},
					new VerbUriStatus() { verb="post", uri="g.com", status=404},
					new VerbUriStatus() { verb="post", uri="g.com", status=200},
					new VerbUriStatus() { verb="get", uri="g.com", status=200},
					new VerbUriStatus() { verb="get", uri="y.com", status=200},
				});

				report.PrintReport();
			}

			public static void TestWithLogReader()
			{
				var testLog = "Logs.txt";
				var log = new GetLog(testLog);
				var report = new VerbUriStatusReport(log.Logs);
				report.PrintReport();
			}
		}
	}
}
