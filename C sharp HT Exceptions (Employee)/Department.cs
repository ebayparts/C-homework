using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_HT_Exceptions__Employee_
{
    class Department
    {
        Employee[] employees = Array.Empty<Employee>();
        public void AddEmployee(Employee employee)
        {
            try
            {
                if (employees.Length == 255)
                {
                    throw new OverflowException("Department is full (max of 255 is reached)");
                }
                Array.Resize(ref employees, employees.Length + 1);
                employees[^1] = employee;
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void DelEmployee(Employee employee)
        {
            try
            {
                if (employees.Length == 0)
                    throw new Exception("Department is empty");
                else
                {
                    int index;
                    index = Array.FindIndex(employees, x => x.ID == employee.ID);
                    if (index == -1)
                        throw new Exception("No such employee found at this Department");
                    else
                    {
                        for (int i = index; i < employees.Length - 1; i++)
                        {
                            var tmp = employees[i];
                            employees[i] = employees[i + 1];
                            employees[i + 1] = tmp;
                        }
                        Array.Resize(ref employees, employees.Length - 1);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
        }
        public void PrintAll()
        {
            for (int i = 0; i < employees.Length; i++)
                Console.WriteLine($"{i+1}. {employees[i]}");
        }
    }
}
