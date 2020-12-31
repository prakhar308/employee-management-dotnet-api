using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.MongoDB
{
   public class EmployeeDatabaseSettings: IEmployeeDatabaseSettings
   {
      public string EmployeesCollectionName { get; set; }
      public string EmployeeTypesCollectionName { get; set; }
      public string ConnectionString { get; set; }
      public string DatabaseName { get; set; }
   }

   public interface IEmployeeDatabaseSettings
   {
      string EmployeesCollectionName { get; set; }
      string EmployeeTypesCollectionName { get; set; }
      string ConnectionString { get; set; }
      string DatabaseName { get; set; }
   }
}
