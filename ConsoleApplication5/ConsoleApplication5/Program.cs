using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
	class Program
	{
		static void Main(string[] args)
		{
			var tempAvr = new TemperatureAvr();
			tempAvr.Log(40);
			var r = tempAvr.GetTempAvr();
			Console.WriteLine(r);
			tempAvr.Log(41);
			r = tempAvr.GetTempAvr();
			Console.WriteLine(r);

		}

		public class TemperatureAvr
		{
			private LinkedList<int> tempLog = new LinkedList<int>();
			private List<int> tempMax = new List<int>();
			private long tempAcc = 0;

			public void Log(int temp)
			{
				if (temp >= tempMax.LastOrDefault())
				{
					tempMax.Add(temp);
				}
				else
				{
					var i = 0;
					while (i < tempMax.Count && tempMax[i] > temp) { i++; }
					tempMax.RemoveRange(i, tempMax.Count - i);
					tempMax.Add(temp);
				}
				if (tempLog.Count < 86400)
				{
					tempLog.AddLast(temp);
					tempAcc += temp;
				}
				else
				{
					tempAcc -= tempLog.ElementAt(0);
					tempAcc += temp;
					tempLog.RemoveFirst();
					tempLog.AddLast(temp);
				}
			}

			public int GetTempAvr()
			{
				//if(tempLog.Count == 0) 
				return (int)this.tempAcc / this.tempLog.Count;
			}

			public int Max24h()
			{
				return this.tempMax.FirstOrDefault();
			}
		}
	}
}
