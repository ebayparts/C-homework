using System;

namespace C_sharp_HT_Exceptions__Employee_
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new("Aleksandr","Zinkovskyi", 38000);
            Console.WriteLine(employee);
            employee.AddSalary(10000);
            Employee employee2 = new("Oleg", "Polishuk", 28000);
            employee.Name = "Oleksandr";


            Department department = new();
            department.AddEmployee(employee);

            department.PrintAll();
            //department.AddEmployee(employee2);
            Console.WriteLine("all:");
            department.PrintAll();

            department.DelEmployee(employee2);
            Console.WriteLine($"After deleting (ID): {employee2.ID}");

            department.PrintAll();

            for (int i = 0; i < 260; i++)
            {
                department.AddEmployee(employee);
            }
            department.PrintAll();

        }
    }
}











//////////////////////////////////////////
///повторити лямбда функції!
///так щоб можна було з ходу розуміти і коректувати:
///        void checkTextOnly(string enteredText)
///               if (enteredText.All(x => Char.IsLetter(x)))
///                     do something...
