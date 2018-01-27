using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoEncoderEventHandlerSample
{
	public class EmailNotify
	{
		public virtual void EmailNotifyHander(object sender, VideoArgs v)
		{
			if (v.id % 2 == 1)
			{
				Console.WriteLine("notifying via Email, video: {0} id: {1}", v.name, v.id);
			}
		}
	}
}
