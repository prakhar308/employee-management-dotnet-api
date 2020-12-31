using EmployeeManagement.Repository.MongoDB.Models;
using EmployeeManagement.Repository.SQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.MongoDB
{
   public interface IEmployeeRepository
   {
      Task<IEnumerable<MongoEmployee>> GetEmployees();
      Task<MongoEmployee> GetEmployeeWithDetails(string id);
      Task<MongoEmployee> AddEmployee(MongoEmployee employee);
      Task UpdateEmployee(MongoEmployee employee);
      Task DeleteEmployee(MongoEmployee employee);
   }
}
