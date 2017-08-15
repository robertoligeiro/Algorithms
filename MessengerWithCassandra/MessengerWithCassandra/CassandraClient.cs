using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerWithCassandra
{
    class CassandraClient
    {
        public Cluster cluster;
        public ISession session;
        public CassandraClient()
        {
            this.cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            this.session = cluster.Connect("myspace");
        }
        public RowSet ExecuteQuery(string query)
        {
            //var r = session.Execute("select json * from UserThreadsTimestampDesc");
            return session.Execute(query);
        }
    }
}
