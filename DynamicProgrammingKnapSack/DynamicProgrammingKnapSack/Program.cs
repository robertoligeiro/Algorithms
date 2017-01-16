using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgrammingKnapSack
{
    class Program
    {
        public const int NumberOfItems = 5;
        public const int maxWeight = 10;
        public const int maxValue = 100;

        static void Main(string[] args)
        {
            var items = new List<Item>();
            var rand = new Random();

            //for (var i = 0; i < NumberOfItems; i++)
            //{
            //    items.Add(new Item { weight = rand.Next(1, maxWeight), value = rand.Next(1, maxValue) });
            //}
            items.Add(new Item() { weight = 5, value = 90 });
            items.Add(new Item() { weight = 9, value = 100 });
            items.Add(new Item() { weight = 1, value = 10 });
            items.Add(new Item() { weight = 3, value = 7 });
            int maxRob = KnapSackProblem.FindItemsToPack(items);
        }


        class Item
        {
            private static int _counter;
            public int Id { get; private set; }
            public int value { get; set; } // value
            public int weight { get; set; } // weight
            public Item()
            {
                Id = ++_counter;
            }

            public override string ToString()
            {
                return string.Format("Id: {0}  v: {1}  w: {2}",
                                     Id, value, weight);
            }
        }

        class KnapSackProblem
        {

            public static int FindItemsToPack(List<Item> items)
            {

                int[,] price = new int[items.Count + 1, maxWeight];
                var response = new List<Item>();

                for (int i = 1; i <= items.Count; ++i)
                {
                    var currItem = items[i - 1];
                    for (int space = 1; space < maxWeight; ++space)
                    {
                        if (space >= currItem.weight)
                        {
                            int remainingSpace = maxWeight - currItem.weight;
                            int remainingSpaceValue = 0;
                            if (remainingSpace > 0)
                            {
                                remainingSpaceValue = price[i - 1, space - currItem.weight];
                            }

                            int currentItemTotalValue = currItem.value + remainingSpaceValue;

                            if (currentItemTotalValue > price[i - 1, space])
                            {
                                price[i, space] = currentItemTotalValue;
                            }
                            else
                            {
                                price[i, space] = price[i - 1, space];
                            }
                        }
                        else
                        {
                            price[i, space] = price[i - 1, space];
                        }
                    }
                }

                int totalValue = price[items.Count, maxWeight - 1];


                return totalValue;
            }
        }
    }
}
