using EmployeeManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Handlers
{
   public interface IEmployeeHandler
   {
      Task<IEnumerable<Employee>> GetEmployees();
      Task<Employee> GetEmployeeWithDetails(string id);
      Task<Employee> AddEmployee(Employee employee);
      Task UpdateEmployee(Employee employee);
      Task DeleteEmployee(Employee employee);
      Task<IEnumerable<Employee>> GetEmployeesByType(int id);
   }
}
