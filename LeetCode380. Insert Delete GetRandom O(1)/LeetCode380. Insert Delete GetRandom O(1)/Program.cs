using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode380.Insert_Delete_GetRandom_O_1_
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomizedSet randomSet = new RandomizedSet();
            // Inserts 1 to the set. Returns true as 1 was inserted successfully.
            var b = randomSet.Insert(1);

            // Returns false as 2 does not exist in the set.
            b = randomSet.Remove(2);

            // Inserts 2 to the set, returns true. Set now contains [1,2].
            b = randomSet.Insert(2);

            // getRandom should return either 1 or 2 randomly.
            var r = randomSet.GetRandom();

            // Removes 1 from the set, returns true. Set now contains [2].
            b = randomSet.Remove(1);

            // 2 was already in the set, so return false.
            b = randomSet.Insert(2);

            // Since 2 is the only number in the set, getRandom always return 2.
            r = randomSet.GetRandom();
        }
        public class RandomizedSet
        {
            private HashSet<int> elements;

            private Random rand;
            /** Initialize your data structure here. */
            public RandomizedSet()
            {
                elements = new HashSet<int>();
                rand = new Random();
            }

            /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
            public bool Insert(int val)
            {
                return elements.Add(val);
            }

            /** Removes a value from the set. Returns true if the set contained the specified element. */
            public bool Remove(int val)
            {
                return elements.Remove(val);
            }

            /** Get a random element from the set. */
            public int GetRandom()
            {
                var index = rand.Next(0, elements.Count);
                return elements.ElementAt(index);
            }
        }
    }
}
