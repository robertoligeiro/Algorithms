using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VideoEncoderEventHandlerSample
{
	public class VideoArgs : EventArgs
	{
		public string name;
		public int id;
	}
	public class VideoEncoder
	{
		public EventHandler<VideoArgs> VideoEncoderEventHandler;

		public void Encode()
		{
			for(int i = 0; i<10;++i)
			{
				var v = new VideoArgs() { name = "video" + i, id = i };
				OnEncoded(v);
				Thread.Sleep(1000);
			}
		}

		public void RegisterConsumer(EventHandler<VideoArgs> v)
		{
			VideoEncoderEventHandler += v;
		}
		protected virtual void OnEncoded(VideoArgs v)
		{
			VideoEncoderEventHandler(this, v);
		}
	}
}
