using EmployeeManagement.Data;
using EmployeeManagement.Repository.SQL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.SQL
{
   public class EmployeeRepository : IEmployeeRepository
   {
      private readonly EmployeeContext _context;

      public EmployeeRepository(EmployeeContext context)
      {
         _context = context;
      }

      public async Task<IEnumerable<SQLEmployee>> GetEmployees()
      {
         return await _context.Employees.ToListAsync();
      }

      public async Task<SQLEmployee> GetEmployeeWithDetails(int id)
      {
         return await _context.Employees
                              .Include(e => e.EmployeeType)
                              .FirstOrDefaultAsync(e => e.Id == id);
      }

      public async Task<SQLEmployee> AddEmployee(SQLEmployee employee)
      {
         _context.Employees.Add(employee);
         await _context.SaveChangesAsync();
         return employee;
      }

      public async Task UpdateEmployee(SQLEmployee employee)
      {
         _context.Entry(employee).State = EntityState.Modified;
         await _context.SaveChangesAsync();
      }

      public async Task DeleteEmployee(SQLEmployee employee)
      { 
         _context.Employees.Remove(employee);
         await _context.SaveChangesAsync();
      }

      public async Task<IEnumerable<SQLEmployee>> GetEmployeesByType(int id)
      {
         return await _context.Employees.Where(emp => emp.EmployeeTypeId == id).ToListAsync();
      }
   }
}
