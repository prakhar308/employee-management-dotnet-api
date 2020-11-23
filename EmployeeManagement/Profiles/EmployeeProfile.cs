using AutoMapper;
using EmployeeManagement.DataTransferObjects;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Profiles
{
   public class EmployeeProfile: Profile
   {
      public EmployeeProfile()
      {
         CreateMap<Employee, EmployeeDto>();
         CreateMap<Employee, EmployeeWithDetailsDto>();
      }
   }
}
