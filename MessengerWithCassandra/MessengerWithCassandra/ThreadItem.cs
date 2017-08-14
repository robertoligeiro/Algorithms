using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace MessengerWithCassandra
{
    public class ThreadItem
    {
        public string threadId { get; set; }
        public string postedTime { get; set; }
        public string userid { get; set; }
        public string body { get; set; }
        public string senderName { get; set; }
    }
}
