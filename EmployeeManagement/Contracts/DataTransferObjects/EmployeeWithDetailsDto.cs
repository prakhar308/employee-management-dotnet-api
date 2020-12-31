using EmployeeManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Contracts.DataTransferObjects
{
   public class EmployeeWithDetailsDto
   {
      public string Id { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Gender { get; set; }
      public string Email { get; set; }
      public DateTime DOB { get; set; }
      public string Phone { get; set; }
      public string Bio { get; set; }
      public EmployeeType EmployeeType { get; set; }
   }
}
