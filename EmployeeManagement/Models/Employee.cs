using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
   public class Employee
   {
      [Key]
      public int Id { get; set; }
      
      [Required]
      public string FirstName { get; set; }
      
      [Required]
      public string LastName { get; set; }

      [Required]
      public string Gender { get; set; }

      [Required]
      public string Email { get; set; }

      [Required]
      [Column(TypeName = "date")]
      public DateTime DOB { get; set; }

      [Required]
      public string Phone { get; set; }

      public string Bio { get; set; }

      public int EmployeeTypeId { get; set; }

      public EmployeeType EmployeeType { get; set; }
   }
}
