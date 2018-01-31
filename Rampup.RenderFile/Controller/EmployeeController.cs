using System.Collections.Generic;
using Rampup.RenderFile.Contracts;
using Rampup.RenderFile.Service;

namespace Rampup.RenderFile.Controller
{
    public class EmployeeController
    {
        private readonly IFileService _fileService;

        public EmployeeController()
            : this(
                new EmployeeService()
            )
        { }

        public EmployeeController(
            IFileService fileService
        )
        {
            _fileService = fileService;
        }

        public List<EmployeeContract> GetEmployeeFromTextFile(string filePath)
        {
            List<EmployeeContract> employeeList = _fileService.GetEmployeeFromTextFile(filePath);
            return employeeList;
        }


        public void TextToDatabaseMigration(string filePath)
        {
            _fileService.EmployeeTextFileToDatabaseMigration(filePath);
        }


    }
}
