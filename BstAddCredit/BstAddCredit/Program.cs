using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstAddCredit
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public class ClientCredit
        {
            private int extraCredit { get; set; }
            private SortedDictionary<string, int> clients;
            public ClientCredit(int initCreditAll)
            {
                this.extraCredit = initCreditAll;
                clients = new SortedDictionary<string, int>();
            }

            public void AddCreditAll(int v)
            {
                this.extraCredit += v;
            }
            public void AddClient(string id, int c)
            {
                var curr = 0;
                if (clients.TryGetValue(id, out curr))
                {
                    clients[id] = c - this.extraCredit;
                }
                else
                    clients.Add(id, c - this.extraCredit);
            }
            public void AddClientCredit(string id, int c)
            {
                var curr = 0;
                if (clients.TryGetValue(id, out curr))
                {
                    clients[id] += c;
                }
                else
                    clients.Add(id, c - this.extraCredit);
            }

            public KeyValuePair<string, int> GetClient(string id)
            {
                var curr = 0;
                if (clients.TryGetValue(id, out curr))
                {
                    return new KeyValuePair<string, int>(id, curr + this.extraCredit);
                }
                throw new Exception("client is not registered");
            }
            public KeyValuePair<string, int> GetMax()
            {
                return clients.LastOrDefault();
            }
        }
    }
}
