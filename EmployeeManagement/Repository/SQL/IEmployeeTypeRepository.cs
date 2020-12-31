using EmployeeManagement.Repository.SQL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.SQL
{
   public interface IEmployeeTypeRepository
   {
      Task<IEnumerable<SQLEmployeeType>> GetEmployeeTypes();
      Task<SQLEmployeeType> AddEmployeeType(SQLEmployeeType employeeType);
   }
}
