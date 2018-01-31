using Rampup.RenderFile.Contracts;
using System.Collections.Generic;

namespace Rampup.RenderFile
{
    public interface IFileService
    {
        List<EmployeeContract> GetEmployeeFromTextFile(string filePath);
        void EmployeeTextFileToDatabaseMigration(string filePath);
        void AddEmployeeList(List<EmployeeContract> employeeList);
    }
}