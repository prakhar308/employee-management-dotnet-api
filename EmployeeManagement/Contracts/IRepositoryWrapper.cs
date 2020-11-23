using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Contracts
{
   public interface IRepositoryWrapper
   {
      IEmployeeRepository Employee { get; }
      IEmployeeTypeRepository EmployeeType { get; }
   }
}
