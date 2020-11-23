using EmployeeManagement.Contracts;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{

   public class EmployeeRepositoryFake : IEmployeeRepository
   {
      private readonly List<Employee> _employees;

      public EmployeeRepositoryFake()
      {
         _employees = new List<Employee>()
         {
            new Employee()
            {
               Id=1, FirstName="John", LastName="Smith", Bio=null, DOB=DateTime.Now,
               Email="test@gmail.com", Gender="Male", Phone="66464",EmployeeTypeId=1,EmployeeType=null
            },
            new Employee()
            {
               Id=2, FirstName="Wendy", LastName="Cho", Bio=null, DOB=DateTime.Now,
               Email="wendy@gmail.com", Gender="Female", Phone="6646466",EmployeeTypeId=2,EmployeeType=null
            }
         };
      }

      public Task<IEnumerable<Employee>> GetEmployees()
      {
         return Task.FromResult<IEnumerable<Employee>>(_employees);
      }
      public Task<Employee> GetEmployeeWithDetails(int id)
      {
         var emp = _employees.Where(emp => emp.Id == id).FirstOrDefault();
         return Task.FromResult(emp);
      }

      public Task<Employee> AddEmployee(Employee employee)
      {
         _employees.Add(employee);
         return Task.FromResult(employee);
      }

      public Task DeleteEmployee(Employee employee)
      {
         _employees.Remove(employee);
         return Task.CompletedTask;
      }

      public Task<IEnumerable<Employee>> GetEmployeesByType(int id)
      {
         throw new NotImplementedException();
      }

      public Task UpdateEmployee(Employee employee)
      {
         throw new NotImplementedException();
      }
   }
}
