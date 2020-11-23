using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Contracts
{
   public interface IEmployeeRepository
   {
      Task<IEnumerable<Employee>> GetEmployees();
      Task<Employee> GetEmployeeWithDetails(int id);
      Task<Employee> AddEmployee(Employee employee);
      Task UpdateEmployee(Employee employee);
      Task DeleteEmployee(Employee employee);
      Task<IEnumerable<Employee>> GetEmployeesByType(int id);
   }
}
