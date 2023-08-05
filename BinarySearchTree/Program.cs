namespace BinarySearchTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BuildTree();
        }

        static void BuildTree()
        {            
            Employee root = FillUpTree();
            Console.WriteLine("Выводим имена и зарплаты:");
            TraverseTree(root);
            SearchEmployee(root);
            ChooseNextStep(root);
        }

        static Employee FillUpTree()
        {
            Employee root = null;
            Console.WriteLine("Введите имена сотрудников. Введите пустую строку, чтобы закончить");
            while (true)
            {
                var name = Console.ReadLine();
                if(name == "")
                {
                    break;
                }              

                var rnd = new Random();
                int salary = rnd.Next(5000);

                if(root == null)
                {
                    root = new Employee() { Name = name, Salary = salary };
                }
                else
                {
                    AddEmployee(root, new Employee() { Name = name, Salary = salary });
                }
            }
            return root;
        }

        static void AddEmployee(Employee root, Employee employee)
        {
            if (employee.Salary < root.Salary)
            {
                if (root.Left != null)
                {
                    AddEmployee(root.Left, employee);
                }
                else
                {
                    root.Left = employee;
                }
            }
            else
            {
                if (root.Right != null)
                {
                    AddEmployee(root.Right, employee);
                }
                else
                {
                    root.Right = employee;
                }
            }
        }

        static void TraverseTree(Employee emp)
        {
            if (emp.Left != null)
            {
                TraverseTree(emp.Left);
            }
            Console.WriteLine($"{emp.Name} - {emp.Salary}");

            if (emp.Right != null)
            {
                TraverseTree(emp.Right);
            }
        }        

        static void SearchEmployee(Employee root)
        {
            Console.WriteLine("Введите размер зарплаты, который вас интересует");
            var str = Console.ReadLine();
            if(!int.TryParse(str, out int salaryValue))
            {
                Console.WriteLine("Вы ввели некорректное значение");
            }
            else
            {
                Employee employee = FindEmployee(root, salaryValue);
                if (employee == null)
                {
                    Console.WriteLine("Такой сотрудник не найден");
                }
                else
                {
                    Console.WriteLine($"Найден сотрудник: {employee.Name}, {employee.Salary}");
                }
            }
        }

        static Employee FindEmployee(Employee root, int salaryValue)
        {
            if(salaryValue < root.Salary)
            {
                if (root.Left != null)
                {
                    return FindEmployee(root.Left, salaryValue);
                }
                return null;
            }
            if(salaryValue > root.Salary)
            {
                if (root.Right != null)
                {
                    return FindEmployee(root.Right, salaryValue);
                }
                return null;
            }
            return root;
        }     

        static void ChooseNextStep(Employee root)
        {
            Console.WriteLine("Введите 0, чтобы перейти к началу программы. Введите 1, чтобы снова осуществить поиск сотрудника по зарплате");
            var input = Console.ReadLine();
            if (input == "0")
            {
                BuildTree();
            }
            else if (input == "1")
            {
                SearchEmployee(root);
                ChooseNextStep(root);
            }
            else
            {
                ChooseNextStep(root);
            }
        }
    }    
}