using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectIt
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessEmployeeArray();

            WriteSeparator();

            ProcessEmployeeList();

            WriteSeparator();

            try
            {
                ProcessIntList();
            }
            catch { }

            WriteSeparator();

            ProcessEmployeeQueue();

            WriteSeparator();

            ProcessEmployeeStack();

            Console.ReadLine();
        }

        private static void ProcessEmployeeArray()
        {
            Employee[] employees = new Employee[]
            {
                new Employee { Name = "Scott" },
                new Employee { Name = "Alex" }
            };

            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Name);
            }

            for (int i = 0; i < employees.Length; i++)
            {
                Console.WriteLine(employees[i].Name);
            }

            Array.Resize(ref employees, 10);
        }

        private static void ProcessEmployeeList()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee { Name = "Scott" },
                new Employee { Name = "Alex" }
            };

            employees.Add(new Employee { Name = "Dani" });

            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Name);
            }

            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine(employees[i].Name);
            }
        }

        private static void ProcessIntList()
        {
            var numbers = new List<int>();
            var capacity = -1;

            while (true)
            {
                if (numbers.Capacity != capacity)
                {
                    capacity = numbers.Capacity;
                    Console.WriteLine(capacity);
                }

                numbers.Add(1);
            }
        }

        private static void ProcessEmployeeQueue()
        {
            Queue<Employee> queue = new Queue<Employee>();
            queue.Enqueue(new Employee { Name = "Alex" });
            queue.Enqueue(new Employee { Name = "Dani" });
            queue.Enqueue(new Employee { Name = "Chris" });

            while (queue.Count > 0)
            {
                var employee = queue.Dequeue();
                Console.WriteLine(employee.Name);
            }
        }

        private static void WriteSeparator()
        {
            Console.WriteLine("---");
        }

        private static void ProcessEmployeeStack()
        {
            Stack<Employee> stack = new Stack<Employee>();
            stack.Push(new Employee { Name = "Alex" });
            stack.Push(new Employee { Name = "Dani" });
            stack.Push(new Employee { Name = "Chris" });

            while (stack.Count > 0)
            {
                var employee = stack.Pop();
                Console.WriteLine(employee.Name);
            }
        }
    }
}
