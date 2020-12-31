using EmployeeManagement.Data;
using EmployeeManagement.Repository.SQL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.SQL
{
   public class EmployeeTypeRepository: IEmployeeTypeRepository
   {
      private readonly EmployeeContext _context;

      public EmployeeTypeRepository(EmployeeContext context)
      {
         _context = context;
      }

      public async Task<IEnumerable<SQLEmployeeType>> GetEmployeeTypes()
      {
         return await _context.EmployeeTypes.ToListAsync();
      }
      public async Task<SQLEmployeeType> AddEmployeeType(SQLEmployeeType employeeType)
      {
         _context.EmployeeTypes.Add(employeeType);
         await _context.SaveChangesAsync();

         return employeeType;
      }
   }
}
