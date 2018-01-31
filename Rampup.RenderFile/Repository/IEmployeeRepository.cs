using System.Collections.Generic;
using System.Data.SqlClient;
using Rampup.RenderFile.Contracts;

namespace Rampup.RenderFile.Repository
{
    public interface IEmployeeRepository
    {
        void AddEmployee(SqlCommand context, EmployeeContract employee);
        void AddEmployeeList(List<EmployeeContract> employeeList);
    }
}