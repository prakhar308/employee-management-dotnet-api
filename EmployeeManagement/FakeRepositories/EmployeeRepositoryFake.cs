using EmployeeManagement.Repository;
using EmployeeManagement.Repository.SQL;
using EmployeeManagement.Repository.SQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.FakeRepositories
{

   public class EmployeeRepositoryFake : IEmployeeRepository
   {
      private readonly List<SQLEmployee> _employees;

      public EmployeeRepositoryFake()
      {
         _employees = new List<SQLEmployee>()
         {
            new SQLEmployee()
            {
               Id=1, FirstName="John", LastName="Smith", Bio=null, DOB=DateTime.Now,
               Email="test@gmail.com", Gender="Male", Phone="66464",EmployeeTypeId=1,EmployeeType=null
            },
            new SQLEmployee()
            {
               Id=2, FirstName="Wendy", LastName="Cho", Bio=null, DOB=DateTime.Now,
               Email="wendy@gmail.com", Gender="Female", Phone="6646466",EmployeeTypeId=2,EmployeeType=null
            }
         };
      }

      public Task<IEnumerable<SQLEmployee>> GetEmployees()
      {
         return Task.FromResult<IEnumerable<SQLEmployee>>(_employees);
      }
      public Task<SQLEmployee> GetEmployeeWithDetails(int id)
      {
         var emp = _employees.Where(emp => emp.Id == id).FirstOrDefault();
         return Task.FromResult(emp);
      }

      public Task<SQLEmployee> AddEmployee(SQLEmployee employee)
      {
         _employees.Add(employee);
         return Task.FromResult(employee);
      }

      public Task DeleteEmployee(SQLEmployee employee)
      {
         _employees.Remove(employee);
         return Task.CompletedTask;
      }

      public Task<IEnumerable<SQLEmployee>> GetEmployeesByType(int id)
      {
         throw new NotImplementedException();
      }

      public Task UpdateEmployee(SQLEmployee employee)
      {
         throw new NotImplementedException();
      }
   }
}
