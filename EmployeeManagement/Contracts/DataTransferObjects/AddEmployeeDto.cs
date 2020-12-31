using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Contracts.DataTransferObjects
{
   public class AddEmployeeDto
   {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Gender { get; set; }
      public string Email { get; set; }
      public DateTime DOB { get; set; }
      public string Phone { get; set; }
      public string Bio { get; set; }
      public string EmployeeTypeId { get; set; }
   }
}
