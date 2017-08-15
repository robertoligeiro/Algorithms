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
    }
}
