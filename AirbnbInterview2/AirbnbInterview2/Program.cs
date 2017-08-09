using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbInterview2
{
    class Program
    {
        static void Main(string[] args)
        {
            var shutBox = new ShutBox();
            var b = shutBox.GamePlay1();
            b = shutBox.GamePlay2();
        }

        public class ShutBox
        {
            private List<int> board;
            private Random rand;
            public ShutBox()
            {
                board = Enumerable.Range(1, 9).ToList();
                rand = new Random();
            }

            private int RollDices()
            {
                return rand.Next(1, 6) + rand.Next(1, 6);
            }

            public bool GamePlay1()
            {
                while (true)
                {
                    var value = this.RollDices();
                    var sum = 0;
                    int index = 0;
                    var itemsRemoved = new HashSet<int>();
                    while(index < this.board.Count)
                    {
                        if (itemsRemoved.Add(this.board[index]))
                        {
                            sum += this.board[index];
                            if (sum == value || sum > value)
                            {
                                break;
                            }
                            index++;
                        }
                    }

                    if (itemsRemoved.Count == board.Count) return true;
                    if (sum != value) return false;
                }
            }

            public bool GamePlay2()
            {
                var removedItems = new HashSet<int>();
                while (true)
                {
                    var value = this.RollDices();
                    var sum = 0;
                    if (!GamePlay2Rec(removedItems, value, 0))
                    {
                        return false;
                    }
                    if (removedItems.Count == this.board.Count) return true;
                }
            }

            public bool GamePlay2Rec(HashSet<int> removedItems, int tgtSum, int sumSoFar)
            {
                if (tgtSum == sumSoFar) return true;
                for (int i = 0; i < this.board.Count; ++i)
                {
                    var v = board[i];
                    if (removedItems.Add(this.board[i]))
                    {
                        sumSoFar += board[i];
                        if (GamePlay2Rec(removedItems, tgtSum, sumSoFar))
                        {
                            return true;
                        }
                        sumSoFar -= v;
                        removedItems.Remove(v);
                    }
                }
                return false;
            }
        }
    }
}
