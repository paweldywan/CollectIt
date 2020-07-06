using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CollectIt
{
    public class EmployeeComparer : IEqualityComparer<Employee>, IComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            return string.Equals(x.Name, y.Name);
        }

        public int GetHashCode(Employee obj)
        {
            return obj.Name.GetHashCode();
        }

        public int Compare(Employee x, Employee y)
        {
            return string.Compare(x.Name, y.Name); // "<0", gdy pierwszy jest większy, ">0" gdy drugi jest większy i 0 gdy są równe
        }
    }

    public class DepartmentCollection : SortedDictionary<string, SortedSet<Employee>>
    {
        public DepartmentCollection Add(string departmentName, Employee employee)
        {
            if (!ContainsKey(departmentName))
            {
                Add(departmentName, new SortedSet<Employee>(new EmployeeComparer()));
            }

            this[departmentName].Add(employee);

            return this;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            _ = args;

            ProcessEmployeeArray();

            WriteSeparator();

            ProcessEmployeeList();

            WriteSeparator();

            try
            {
                ProcessIntList();
            }
            catch 
            { 

            }

            WriteSeparator();

            ProcessEmployeeQueue();

            WriteSeparator();

            ProcessEmployeeStack();

            WriteSeparator();

            ProcessIntHashSet();

            WriteSeparator();

            ProcessEmployeeHashSet();

            WriteSeparator();

            ProcessIntLinkedList();

            WriteSeparator();

            ProcessEmployeeDictionary();

            WriteSeparator();

            ProcessDepartmentCollection();


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

        private static void WriteSeparator()
        {
            Console.WriteLine("---");
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
            HashSet<int> set = new HashSet<int>
            {
                1,
                2,
                2
            };

            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
        }

        private static void ProcessEmployeeHashSet()
        {
            HashSet<Employee> set = new HashSet<Employee>
            {
                new Employee { Name = "Scott" }, //Inne referencje
                new Employee { Name = "Scott" }
            };
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
            var employeesByName2 = new Dictionary<string, Employee>
            {
                { "Scott", new Employee { Name = "Scott" } },
                { "Alex", new Employee { Name = "Alex" } },
                { "Joy", new Employee { Name = "Joy" } }
            };

            _ = employeesByName2["Scott"];

            foreach (var item in employeesByName2)
            {
                Console.WriteLine("{0}:{1}", item.Key, item.Value.Name);
            }


            var employeesByDepartment = new Dictionary<string, List<Employee>>
            {
                { "Engineering", new List<Employee> { new Employee { Name = "Scott" } } }
            };

            employeesByDepartment["Engineering"].Add(new Employee { Name = "Scott" });

            foreach (var item in employeesByDepartment)
            {
                foreach (var employee in item.Value)
                {
                    Console.WriteLine(employee.Name);
                }
            }


            var employeesByDepartment2 = new SortedList<string, List<Employee>>
            {
                { "Sales", new List<Employee> { new Employee(), new Employee(), new Employee() } },
                { "Engineering", new List<Employee> { new Employee(), new Employee() } }
            };

            foreach (var item in employeesByDepartment2)
            {
                Console.WriteLine("The count of employees for {0} is {1}", item.Key, item.Value.Count);
            }
        }

        private static void ProcessDepartmentCollection()
        {
            var departments = new DepartmentCollection();

            departments.Add("Sales", new Employee { Name = "Joy" })
                       .Add("Sales", new Employee { Name = "Dani" })
                       .Add("Sales", new Employee { Name = "Dani" });

            departments.Add("Engineering", new Employee { Name = "Scott" })
                       .Add("Engineering", new Employee { Name = "Alex" })
                       .Add("Engineering", new Employee { Name = "Dani" });

            foreach (var department in departments)
            {
                Console.WriteLine(department.Key);

                foreach (var employee in department.Value)
                {
                    Console.WriteLine("\t" + employee.Name);
                }
            }
        }
    }
}
