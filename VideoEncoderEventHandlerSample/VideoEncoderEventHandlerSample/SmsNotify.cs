using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoEncoderEventHandlerSample
{
	public class SmsNotify
	{
		public virtual void SmsNotifyHander(object sender, VideoArgs v)
		{
			if (v.id % 2 == 0)
			{
				var encoder = sender as VideoEncoder;
				Console.WriteLine("notifying via SMS, video: {0} id: {1}, sender: {2}", v.name, v.id, encoder.ToString());
			}
		}
	}
}
