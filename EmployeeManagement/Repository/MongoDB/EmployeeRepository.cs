using EmployeeManagement.Repository.MongoDB.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.MongoDB
{
   public class EmployeeRepository : IEmployeeRepository
   {
      private readonly IMongoCollection<MongoEmployee> _employees;
      private readonly IMongoCollection<MongoEmployeeType> _employeeTypes;

      public EmployeeRepository(IEmployeeDatabaseSettings settings)
      {
         var client = new MongoClient(settings.ConnectionString);
         var database = client.GetDatabase(settings.DatabaseName);

         _employees = database.GetCollection<MongoEmployee>(settings.EmployeesCollectionName);
         _employeeTypes = database.GetCollection<MongoEmployeeType>(settings.EmployeeTypesCollectionName);
      }

      public async Task<IEnumerable<MongoEmployee>> GetEmployees()
      {
         return await _employees.FindAsync(emp => true).Result.ToListAsync();
      }

      public async Task<MongoEmployee> GetEmployeeWithDetails(string id)
      {
         var employee = await _employees.FindAsync(emp => emp.Id == id)
                                       .Result.FirstOrDefaultAsync();

         // get employeeType and attach it to the employee
         var employeeType = await _employeeTypes.FindAsync(empType => empType.Id == employee.EmployeeTypeId)
                                          .Result.FirstOrDefaultAsync();

         employee.MongoEmployeeType = employeeType;

         return employee;
      }

      public async Task<MongoEmployee> AddEmployee(MongoEmployee employee)
      {
         await _employees.InsertOneAsync(employee);
         return employee;
      }

      public async Task UpdateEmployee(MongoEmployee employee)
      {
         await _employees.ReplaceOneAsync(emp => emp.Id == employee.Id, employee);
         return;
      }

      public async Task DeleteEmployee(MongoEmployee employee)
      {
         await _employees.DeleteOneAsync(emp => emp.Id == employee.Id);
         return;
      }
   }
}
