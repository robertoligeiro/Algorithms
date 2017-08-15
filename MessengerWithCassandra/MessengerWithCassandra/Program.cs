using Cassandra;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerWithCassandra
{
    class Program
    {
        public static CassandraClient cassandraClient = new CassandraClient();
        static void Main(string[] args)
        {
            //Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            //ISession session = cluster.Connect("myspace");
            ////var r = session.Execute("select json * from UserThreadsTimestampDesc");
            //var r = session.Execute("select json * from user");
            //var cassandraClient = new CassandraClient();
            //RowSet user = cassandraClient.ExecuteQuery("select json * from user where userid = " + args[0]);
            //foreach (var r in user.GetRows())
            //{
            //    Console.WriteLine(r);
            //}
            var userMsgSession = GetUserMsgSession(args[0]);
            var cmd = "threads";
            while((cmd = Console.ReadLine()) != "exit")
            {
                if (cmd == "threads")
                {
                    foreach (var t in userMsgSession.threads)
                    {
                        Console.WriteLine("tId: " + t.threadId + " tName: " + t.threadName + " tPostDate: " + t.postedTime);
                    }
                }
                if (cmd == "readthread")
                {
                    Console.WriteLine("Enter thread id");
                    var id = Console.ReadLine();
                    var messageThread = GetThread(id);
                    foreach (var m in messageThread.items)
                    {
                        Console.WriteLine(m.postedTime + " sender: " + m.senderName + " text: " + m.body);
                    }
                    Console.WriteLine("Send msg: [n]");
                    var msg = Console.ReadLine();
                    if (msg != "n")
                    {
                        SendMessage(id, userMsgSession.userdetails.userid, msg, userMsgSession.userdetails.username);
                    }
                }
            }
        }

        public static void UpdateThreadPostDate(string date, string threadId)
        {
            string query = "UPDATE UserThreadsTimestampDesc SET postedTime='{0}' WHERE threadId = '{1}'";
            query = string.Format(query, date, threadId);
            var resp = cassandraClient.ExecuteQuery(query);
        }
        public static void SendMessage(string threadId, string userid, string msg, string senderName)
        {
            var messageThread = new MessageThread();
            string query = "INSERT INTO Thread (threadId, postedTime, userid, body, senderName) VALUES ({0}, '{1}', {2},'{3}', '{4}');";
            var d = DateTime.UtcNow.ToString("s");
            query = string.Format(query, threadId, d, userid, msg, senderName);
            var resp = cassandraClient.ExecuteQuery(query);
            UpdateThreadPostDate(d, threadId);
        }

        public static MessageThread GetThread(string threadId)
        {
            var messageThread = new MessageThread();
            var resp = cassandraClient.ExecuteQuery("select json * from thread where threadid = " + threadId);
            foreach (var row in resp.GetRows())
            {
                var threadItem = JsonConvert.DeserializeObject<ThreadItem>(row.GetValue<string>(0));
                messageThread.items.Add(threadItem);
            }
            return messageThread;
        }
        public static User GetUser(string userid)
        {
            var resp = cassandraClient.ExecuteQuery("select json * from user where userid = " + userid);
            return JsonConvert.DeserializeObject<User>(resp.GetRows().FirstOrDefault().GetValue<string>(0));
        }

        public static UserMsgSession GetUserMsgSession(string userid)
        {
            var userMsgSession = new UserMsgSession();
            userMsgSession.userdetails = GetUser(userid);
            var resp = cassandraClient.ExecuteQuery("select json * from UserThreadsTimestampDesc where userid = " + userid);
            foreach (var row in resp.GetRows())
            {
                var thread = JsonConvert.DeserializeObject<UserThread>(row.GetValue<string>(0));
                userMsgSession.threads.Add(thread);
            }

            var participantsMap = new Dictionary<string, User>();
            foreach (var thread in userMsgSession.threads)
            {
                var p = thread.participants.Split(',');
                foreach (var id in p)
                {
                    User u;
                    if (participantsMap.TryGetValue(id, out u))
                    {
                    }
                    else
                    {
                        u = GetUser(id);
                        participantsMap.Add(id, u);
                    }
                    thread.participantsDetails.Add(u);
                }
            }
            return userMsgSession;
        }
    }
}
