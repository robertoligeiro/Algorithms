using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode690.Employee_Importance
{
    class Program
    {
        //https://leetcode.com/problems/employee-importance/description/
        //leetcode doesn't have c# option.
        static void Main(string[] args)
        {
            var e1 = new Employee() { id = 1, importance = 5 };
            var e2 = new Employee() { id = 2, importance = 3 };
            var e3 = new Employee() { id = 3, importance = 3 };
            var e4 = new Employee() { id = 4, importance = 1 };
            e1.subordinates.Add(e2);
            e1.subordinates.Add(e3);
            e3.subordinates.Add(e4);
            var s = new Solution();
            var r = s.GetImportance(new List<Employee>() { e1, e2, e3, e4 }, 1);
        }

        public class Employee
        {
            public int id { get; set; }
            public int importance { get; set; }
            public List<Employee> subordinates = new List<Employee>();
        }

        public class Solution
        {
            public int GetImportance(List<Employee> employees, int id)
            {
                foreach (var e in employees)
                {
                    if (e.id == id)
                    {
                        return GetTotImportance(e);
                    }
                }
                throw new ArgumentException("not found");
            }
            private int GetTotImportance(Employee e)
            {
                var q = new Queue<Employee>();
                var acc = 0;
                q.Enqueue(e);
                while (q.Count > 0)
                {
                    var curr = q.Dequeue();
                    acc += curr.importance;
                    foreach (var s in curr.subordinates)
                    {
                        q.Enqueue(s);
                    }
                }
                return acc;
            }
        }
    }
}
