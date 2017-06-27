namespace LeetCode464.CanIWin
{
    //https://leetcode.com/problems/can-i-win/#/description
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.CanIWin(10, 11); //false
            r = s.CanIWin(6, 11); //true
        }

        public class Solution
        {
            public bool CanIWin(int maxChoosableInteger, int desiredTotal)
            {
                if (maxChoosableInteger >= desiredTotal) return true;
                if (maxChoosableInteger + 1 >= desiredTotal) return false;
                if (maxChoosableInteger * (maxChoosableInteger + 1) / 2 < desiredTotal) return false;
                return canWin(desiredTotal);
            }

            private bool canWin(int total)
            {
                for (int i = 20; i >= 1; i--)
                {
                        int totalNext = total - i;
                        if (totalNext <= 0) return true;
                        else if(canWin(totalNext))
                        {
                            return true;
                        }
                }

                return false;
            }
        }
    }
}
