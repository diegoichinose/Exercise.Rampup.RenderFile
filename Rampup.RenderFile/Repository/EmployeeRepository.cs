using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Rampup.RenderFile.Contracts;

namespace Rampup.RenderFile.Repository
{
    class EmployeeRepository : IEmployeeRepository
    {
        private const string CONNECTION_STRING = @"Data Source=N077\SQLEXPRESS;Initial Catalog=RAMPUP_DB;Integrated Security=True";


        public void AddEmployee(SqlCommand cmd, EmployeeContract employee)
        {
            cmd.CommandText = "INSERT INTO RampupEmployee (Name, Email) VALUES ('" + employee.Name + "', '" + employee.Email + "')";
            cmd.ExecuteNonQuery();
        }

        public void AddEmployeeList(List<EmployeeContract> employeeList)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                SqlTransaction transaction;
                transaction = conn.BeginTransaction("EmployeeListTransaction");
                cmd.Transaction = transaction;

                try
                {
                    foreach (EmployeeContract employee in employeeList)
                    {
                        AddEmployee(cmd, employee);
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

    }

}
