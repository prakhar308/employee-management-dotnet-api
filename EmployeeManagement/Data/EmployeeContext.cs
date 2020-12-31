using EmployeeManagement.Repository.SQL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Data
{
   public class EmployeeContext: DbContext
   {
      public EmployeeContext(DbContextOptions<EmployeeContext> options): base(options)
      {

      }

      public DbSet<SQLEmployee> Employees { get; set; }
      public DbSet<SQLEmployeeType> EmployeeTypes { get; set; }
   }
}
