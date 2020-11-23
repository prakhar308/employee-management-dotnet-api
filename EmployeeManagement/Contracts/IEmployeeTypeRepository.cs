using EmployeeManagement.Data;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Contracts
{
   public interface IEmployeeTypeRepository
   {
      Task<IEnumerable<EmployeeType>> GetEmployeeTypes();
      Task<EmployeeType> AddEmployeeType(EmployeeType employeeType);
   }
}
