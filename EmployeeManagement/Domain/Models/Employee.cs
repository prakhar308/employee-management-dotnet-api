using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Models
{
   public class Employee
   {
      public string Id { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Gender { get; set; }
      public string Email { get; set; }
      public DateTime DOB { get; set; }
      public string Phone { get; set; }
      public string Bio { get; set; }
      public string EmployeeTypeId { get; set; }
      public EmployeeType EmployeeType { get; set; }
   }
}
