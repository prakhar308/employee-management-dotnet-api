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
   public class EmployeeHandler: IEmployeeHandler
   {
      private readonly IEmployeeRepository _employeeRepository;
      private readonly IMapper _mapper;

      public EmployeeHandler(
         IEmployeeRepository employeeRepository,
         IMapper mapper
      )
      {
         _employeeRepository = employeeRepository;
         _mapper = mapper;
      }

      public async Task<IEnumerable<Employee>> GetEmployees()
      {
         var employees = await _employeeRepository.GetEmployees();
         // Map Employee Model from Repo to Domain
         var employeesResult = _mapper.Map<IEnumerable<Employee>>(employees);
         
         return employeesResult;
      }

      public async Task<Employee> GetEmployeeWithDetails(string id)
      {
         var employee = await _employeeRepository.GetEmployeeWithDetails(id);
         var employeeResult = _mapper.Map<Employee>(employee);
         return employeeResult;
      }

      public async Task<Employee> AddEmployee(Employee employee)
      {
         var employeeToCreate = _mapper.Map<MongoEmployee>(employee);
         var createdEmployee = await _employeeRepository.AddEmployee(employeeToCreate);
         var employeeResult = _mapper.Map<Employee>(createdEmployee);
         return employeeResult;
      }

      public async Task UpdateEmployee(Employee employee)
      {
         var employeeToUpdate = _mapper.Map<MongoEmployee>(employee);
         await _employeeRepository.UpdateEmployee(employeeToUpdate);
      }

      public async Task DeleteEmployee(Employee employee)
      {
         var employeeToDelete = _mapper.Map<MongoEmployee>(employee);
         await _employeeRepository.DeleteEmployee(employeeToDelete);
      }

      public Task<IEnumerable<Employee>> GetEmployeesByType(int id)
      {
         throw new NotImplementedException();
      }
   }
}
