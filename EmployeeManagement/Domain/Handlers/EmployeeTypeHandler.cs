using AutoMapper;
using EmployeeManagement.Domain.Models;
using EmployeeManagement.Repository.MongoDB;
using EmployeeManagement.Repository.MongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Handlers
{
   public class EmployeeTypeHandler : IEmployeeTypeHandler
   {
      private readonly IEmployeeTypeRepository _employeeTypeRepository;
      private readonly IMapper _mapper;

      public EmployeeTypeHandler(
         IEmployeeTypeRepository employeeTypeRepository,
         IMapper mapper
      )
      {
         _employeeTypeRepository = employeeTypeRepository;
         _mapper = mapper;
      }

      public async Task<EmployeeType> AddEmployeeType(EmployeeType employeeType)
      {
         var employeeTypeToAdd = _mapper.Map<MongoEmployeeType>(employeeType);
         
         var createdEmployeeType = await _employeeTypeRepository.AddEmployeeType(employeeTypeToAdd);
         
         var employeeTypeResult = _mapper.Map<EmployeeType>(createdEmployeeType);
         
         return employeeTypeResult;
      }

      public async Task<IEnumerable<EmployeeType>> GetEmployeeTypes()
      {
         var employeeTypes = await _employeeTypeRepository.GetEmployeeTypes();
         var employeeTypesResult = _mapper.Map<IEnumerable<EmployeeType>>(employeeTypes);
         return employeeTypesResult;
      }
   }
}
