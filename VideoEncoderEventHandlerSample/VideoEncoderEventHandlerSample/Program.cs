using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoEncoderEventHandlerSample
{
	class Program
	{
		static void Main(string[] args)
		{
			var videoEncoder = new VideoEncoder();
			var email = new EmailNotify();
			var sms = new SmsNotify();
			videoEncoder.RegisterConsumer(email.EmailNotifyHander);
			videoEncoder.RegisterConsumer(sms.SmsNotifyHander);
			videoEncoder.Encode();
			Console.ReadKey();
		}
	}
}
