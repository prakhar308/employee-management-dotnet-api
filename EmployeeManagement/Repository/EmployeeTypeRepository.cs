using EmployeeManagement.Contracts;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
   public class EmployeeTypeRepository: IEmployeeTypeRepository
   {
      private readonly EmployeeContext _context;

      public EmployeeTypeRepository(EmployeeContext context)
      {
         _context = context;
      }

      public async Task<IEnumerable<EmployeeType>> GetEmployeeTypes()
      {
         return await _context.EmployeeTypes.ToListAsync();
      }
      public async Task<EmployeeType> AddEmployeeType(EmployeeType employeeType)
      {
         _context.EmployeeTypes.Add(employeeType);
         await _context.SaveChangesAsync();

         return employeeType;
      }
   }
}
