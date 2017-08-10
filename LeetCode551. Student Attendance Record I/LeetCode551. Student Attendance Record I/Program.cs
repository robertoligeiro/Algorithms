using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode551.Student_Attendance_Record_I
{
    class Program
    {
        //https://leetcode.com/submissions/detail/113318002/    
        static void Main(string[] args)
        {
            var s = new Solution();
            var b = s.CheckRecord("PPALLP");
            b = s.CheckRecord("PPALLL");
        }

        public class Solution
        {
            public bool CheckRecord(string s)
            {
                var countA = 0;
                var countL = 0;
                foreach (var c in s)
                {
                    if (c == 'A') countA++;
                    if (c == 'L') countL++;
                    else countL = 0;
                    if (countA >= 2 || countL > 2) return false;
                }

                return true;
            }
        }
    }
}
