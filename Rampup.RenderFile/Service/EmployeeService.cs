using System;
using System.Collections.Generic;
using System.IO;
using Rampup.RenderFile.Contracts;
using Rampup.RenderFile.Repository;

namespace Rampup.RenderFile.Service
{
    public class EmployeeService : IFileService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService() : this(new EmployeeRepository()) { }
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        public void EmployeeTextFileToDatabaseMigration(string filePath)
        {
            List<EmployeeContract> employeeList = GetEmployeeFromTextFile(filePath);
            AddEmployeeList(employeeList);
        }
        
        public List<EmployeeContract> GetEmployeeFromTextFile(string filePath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    List<EmployeeContract> employeeList = new List<EmployeeContract>();
                    string line;
                    string[] column;
                    int counter = 0;

                    while ((line = sr.ReadLine()) != null)
                    {
                        column  = line.Split('|');
                        EmployeeContract employee = new EmployeeContract()
                        {
                            ID = Convert.ToInt32(column[0]),
                            Name = column[1],
                            Email = column[2]
                        };

                        employeeList.Add(employee);
                    }

                    return employeeList;
                }
            }
            catch (Exception e)
            {
                throw new Exception("The file could not be read:" + e.Message);
            }
        }
        
        public void AddEmployeeList(List<EmployeeContract> employeeList)
        {
            _employeeRepository.AddEmployeeList(employeeList);
        }
    }
}
