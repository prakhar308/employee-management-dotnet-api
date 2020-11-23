using EmployeeManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
   public class RepositoryWrapperFake : IRepositoryWrapper
   {
      private EmployeeRepositoryFake _employee;
      public IEmployeeRepository Employee 
      {
         get
         {
            if(_employee == null)
            {
               _employee = new EmployeeRepositoryFake();
            }

            return _employee;
         }
      }

      public IEmployeeTypeRepository EmployeeType => throw new NotImplementedException();
   }
}
