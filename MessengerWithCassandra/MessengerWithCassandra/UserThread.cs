using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerWithCassandra
{
    public class UserThread
    {
        public string userid { get; set; }
        public string threadId { get; set; }
        public string postedTime { get; set; }
        public string threadName { get; set; }
        public string participants { get; set; }
        public string participantsIds { get; set; }
        public bool isActive { get; set; }
    }
}
