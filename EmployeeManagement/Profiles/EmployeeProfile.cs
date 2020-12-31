using AutoMapper;
using EmployeeManagement.Contracts.DataTransferObjects;
using EmployeeManagement.Domain.Models;
using EmployeeManagement.Repository.MongoDB.Models;
using EmployeeManagement.Repository.SQL.Models;

namespace EmployeeManagement.Profiles
{
   public class EmployeeProfile: Profile
   {
      public EmployeeProfile()
      {
         // DTO to Domain
         CreateMap<AddEmployeeDto, Employee>();

         // Domain Model to SQL Repo Model
         CreateMap<Employee, SQLEmployee>();
         CreateMap<EmployeeType, SQLEmployeeType>();
         // Domain Model to Mongo Repo Model
         CreateMap<Employee, MongoEmployee>();
         CreateMap<EmployeeType, MongoEmployeeType>();

         // SQL Repo Model to Domain Model
         CreateMap<SQLEmployee, Employee>();
         CreateMap<SQLEmployeeType, EmployeeType>();
         // Mongo Repo Model to Domain Model
         CreateMap<MongoEmployee, Employee>();
         CreateMap<MongoEmployeeType, EmployeeType>();

         // Domain to DTO
         CreateMap<Employee, EmployeeDto>();
         CreateMap<Employee, EmployeeWithDetailsDto>();
      }
   }
}
