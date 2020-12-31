using EmployeeManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Handlers
{
   public interface IEmployeeTypeHandler
   {
      Task<IEnumerable<EmployeeType>> GetEmployeeTypes();
      Task<EmployeeType> AddEmployeeType(EmployeeType employeeType);
   }
}
