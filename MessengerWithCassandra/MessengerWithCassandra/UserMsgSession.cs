using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerWithCassandra
{
    public class UserMsgSession
    {
        public User userdetails { get; set; }
        public List<UserThread> threads = new List<UserThread>();
        public UserThread GetUserThread(string threadid)
        {
            return threads.Where(x => x.threadId == threadid).First();
        }
    }
}
