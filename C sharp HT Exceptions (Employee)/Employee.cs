using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_HT_Exceptions__Employee_
{
    class Employee
    {
        public readonly byte ID; 
        string name;
        string surname;
        ushort salary;
        public static uint lastID = 0;
        public Employee(string name = "Unspecified", string surname = "Unspecified", ushort salary = 4500)
        {
            Name = name;
            Surname = surname;
            Salary = salary;
            ++lastID;
            ID = Convert.ToByte(lastID);
        }

        static void CheckTextOnly(string enteredText)
        {
            if (string.IsNullOrWhiteSpace(enteredText))
                throw new Exception("This can not be empty or whitespace");
            if (!enteredText.All(x => Char.IsLetter(x)))
            {
                var ex = new Exception("Employee designation consist of non letter symbols!");
                throw ex;
            }
        }
        public string Name
        {
            get => name;
            set
            {
                CheckTextOnly(value);
                name = value;
            }
        }
        public string Surname
        {
            get => surname;
            set
            {
                CheckTextOnly(value);
                surname = value;
            }
        }
        public ushort Salary
        {
            get => salary;
            set
            {
                try
                {
                    salary = checked(value);
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void AddSalary(ushort increase)
        {
            if (increase > (salary * 0.5))
            {
                Console.WriteLine("Looks you got a mistake, increase is too much, try again!\nEnter increase value:");
                ushort newIncrease = ushort.Parse(Console.ReadLine());
                AddSalary(newIncrease);
                return;
            }
            try
            {
                Salary = checked((ushort)(Salary + increase));
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public override string ToString()
        {
            return $"Employee ID: {ID}, \tName: {Name}, \tSurname: {Surname}, \tSalary: {Salary}";
        }

    }
}
