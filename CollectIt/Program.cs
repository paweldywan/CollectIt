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
            //ProcessEmployeeArray();

            //WriteSeparator();

            //ProcessEmployeeList();

            //WriteSeparator();

            //try
            //{
            //    ProcessIntList();
            //}
            //catch { }

            //WriteSeparator();

            //ProcessEmployeeQueue();

            //WriteSeparator();

            //ProcessEmployeeStack();

            //WriteSeparator();

            //ProcessIntHashSet();

            //WriteSeparator();

            //ProcessEmployeeHashSet();

            //WriteSeparator();

            //ProcessIntLinkedList();

            //WriteSeparator();

            ProcessEmployeeDictionary();

            WriteSeparator();

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

        private static void ProcessIntHashSet()
        {
            HashSet<int> set = new HashSet<int>();
            set.Add(1);
            set.Add(2);
            set.Add(2);

            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
        }

        private static void ProcessEmployeeHashSet()
        {
            HashSet<Employee> set = new HashSet<Employee>();
            set.Add(new Employee { Name = "Scott" }); //Inne referencje
            set.Add(new Employee { Name = "Scott" });
            var employee = new Employee { Name = "Alex" }; //Te same referencje
            set.Add(employee);
            set.Add(employee);

            foreach (var item in set)
            {
                Console.WriteLine(item.Name);
            }
        }

        private static void ProcessIntLinkedList()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(2);
            list.AddFirst(3);

            var first = list.First;
            list.AddAfter(first, 5);
            list.AddBefore(first, 10);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            var node = list.First;
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
        }

        private static void ProcessEmployeeDictionary()
        {
            var employeesByName2 = new Dictionary<string, Employee>();

            employeesByName2.Add("Scott", new Employee { Name = "Scott" });
            employeesByName2.Add("Alex", new Employee { Name = "Alex" });
            employeesByName2.Add("Joy", new Employee { Name = "Joy" });

            var scott = employeesByName2["Scott"];

            foreach (var item in employeesByName2)
            {
                Console.WriteLine("{0}:{1}", item.Key, item.Value.Name);
            }


            var employeesByDepartment = new Dictionary<string, List<Employee>>();

            employeesByDepartment.Add("Engineering", new List<Employee> { new Employee { Name = "Scott" } });

            employeesByDepartment["Engineering"].Add(new Employee { Name = "Scott" });

            foreach (var item in employeesByDepartment)
            {
                foreach (var employee in item.Value)
                {
                    Console.WriteLine(employee.Name);
                }
            }


            var employeesByDepartment2 = new SortedList<string, List<Employee>>();

            employeesByDepartment2.Add("Sales", new List<Employee> { new Employee(), new Employee(), new Employee() });
            employeesByDepartment2.Add("Engineering", new List<Employee> { new Employee(), new Employee() });

            foreach (var item in employeesByDepartment2)
            {
                Console.WriteLine("The count of employees for {0} is {1}", item.Key, item.Value.Count);
            }
        }
    }
}
