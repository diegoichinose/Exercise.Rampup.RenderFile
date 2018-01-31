
using System;
using System.Collections.Generic;
using Rampup.RenderFile.Contracts;
using Rampup.RenderFile.Controller;

namespace Rampup.RenderFile
{
    public class Program
    {
        private const string EMPLOYEE_LIST_TXT_FILENAME = "EmployeeList.txt";

        public static void Main(string[] args)
        {
            string filePath = GetSystemFilePath();
            EmployeeController employeeController = new EmployeeController();
            List<EmployeeContract> employeeList = employeeController.GetEmployeeFromTextFile(filePath);

            foreach (EmployeeContract employee in employeeList)
            {
                Console.WriteLine("ID: " + employee.ID + " | Name: " + employee.Name + "| Email: " + employee.Email);
            }

            Console.ReadKey();
        }

        private static string GetSystemFilePath()
        {
            return System.IO.Path.GetFullPath(EMPLOYEE_LIST_TXT_FILENAME);
        }
    }
}
