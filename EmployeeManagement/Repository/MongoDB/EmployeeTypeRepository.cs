using EmployeeManagement.Repository.MongoDB.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.MongoDB
{
   public class EmployeeTypeRepository : IEmployeeTypeRepository
   {
      private readonly IMongoCollection<MongoEmployeeType> _employeeTypes;

      public EmployeeTypeRepository(IEmployeeDatabaseSettings settings)
      {
         var client = new MongoClient(settings.ConnectionString);
         var database = client.GetDatabase(settings.DatabaseName);

         _employeeTypes = database.GetCollection<MongoEmployeeType>(settings.EmployeeTypesCollectionName);
      }

      public async Task<IEnumerable<MongoEmployeeType>> GetEmployeeTypes()
      {
         return await _employeeTypes.FindAsync(empType => true).Result.ToListAsync();
      }

      public async Task<MongoEmployeeType> AddEmployeeType(MongoEmployeeType employeeType)
      {
         await _employeeTypes.InsertOneAsync(employeeType);
         return employeeType;
      }
   }
}
