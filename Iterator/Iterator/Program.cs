using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
	class Program
	{
		static void Main(string[] args)
		{
			var p = new PeekIterator(new List<int>() { 1,2,3});
			var i = p.Peek(); //1
			i = p.Next(); //1
			i = p.Next(); //2
			i = p.Peek(); //3
			i = p.Next(); //3
		}

		public class Iterator
		{
			private List<int> items;
			private int index;
			public Iterator(List<int> a)
			{
				items = a;
			}

			public bool HasNext()
			{
				return index < items.Count;
			}

			protected int GetNext()
			{
				if(HasNext())return items[index++];
				return -1;
			}
		}

		public class PeekIterator : Iterator
		{
			private bool hasNext;
			private int next;
			public PeekIterator(List<int> a) : base(a)
			{
				GetNext();
			}
			public bool HasNext()
			{
				return this.hasNext;
			}

			public int Peek()
			{
				return this.next;
			}
			public int Next()
			{
				var ret = this.next;
				GetNext();
				return ret;
			}
			private void GetNext()
			{
				this.hasNext = base.HasNext();
				if (this.hasNext)
				{
					next = base.GetNext();
				}
			}
		}
	}
}
