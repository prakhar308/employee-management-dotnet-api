using EmployeeManagement.Repository.MongoDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.MongoDB
{
   public interface IEmployeeTypeRepository
   {
      Task<IEnumerable<MongoEmployeeType>> GetEmployeeTypes();
      Task<MongoEmployeeType> AddEmployeeType(MongoEmployeeType employeeType);
   }
}
