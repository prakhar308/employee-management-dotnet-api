using EmployeeManagement.Repository.SQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.SQL
{
   public interface IEmployeeRepository
   {
      Task<IEnumerable<SQLEmployee>> GetEmployees();
      Task<SQLEmployee> GetEmployeeWithDetails(int id);
      Task<SQLEmployee> AddEmployee(SQLEmployee employee);
      Task UpdateEmployee(SQLEmployee employee);
      Task DeleteEmployee(SQLEmployee employee);
   }
}
