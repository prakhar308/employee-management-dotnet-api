using EmployeeManagement.Contracts;
using EmployeeManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
   public class RepositoryWrapper : IRepositoryWrapper
   {
      private EmployeeContext _context;
      private EmployeeRepository _employee;
      private EmployeeTypeRepository _employeeType;

      public RepositoryWrapper(EmployeeContext context)
      {
         _context = context;
      }

      public IEmployeeRepository Employee
      {
         get
         {
            if(_employee == null)
            {
               _employee = new EmployeeRepository(_context);
            }

            return _employee;
         }
      }

      public IEmployeeTypeRepository EmployeeType
      {
         get
         {
            if(_employeeType == null)
            {
               _employeeType = new EmployeeTypeRepository(_context);
            }

            return _employeeType;
         }
      }
   }
}
