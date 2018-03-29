using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode735.Asteroid_Collision
{
	class Program
	{
		//https://leetcode.com/problems/asteroid-collision/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.AsteroidCollision(new int[] { 5,10,-5});
		}

		public class Solution
		{
			public int[] AsteroidCollision(int[] asteroids)
			{
				var s = new Stack<int>();
				foreach (var ast in asteroids)
				{
					var addAst = true;
					while (s.Count > 0 && ast < 0 && s.Peek() > 0)
					{
						if (s.Peek() < Math.Abs(ast))
						{
							s.Pop();
						}
						else if (s.Peek() == Math.Abs(ast))
						{
							addAst = false;
							s.Pop();
							break;
						}
						else
						{
							addAst = false;
							break;
						}
					}
					if(addAst) s.Push(ast);
				}
				var resp = new int[s.Count];
				for(int i = s.Count-1; i >=0;--i)
				{
					resp[s.Count-1 - i] = s.ElementAt(i);
				}
				return resp;
			}
		}
	}
}
