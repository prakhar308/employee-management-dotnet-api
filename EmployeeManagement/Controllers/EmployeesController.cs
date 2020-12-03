using AutoMapper;
using EmployeeManagement.Contracts;
using EmployeeManagement.Data;
using EmployeeManagement.DataTransferObjects;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
   [Route("api/employees")]
   [ApiController]
   public class EmployeesController : ControllerBase
   {
      private readonly IRepositoryWrapper _repository;
      private readonly IMapper _mapper;

      public EmployeesController(IRepositoryWrapper repository, IMapper mapper)
      {
         _repository = repository;
         _mapper = mapper;
      }

      // GET: api/employees
      [HttpGet]
      public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
      {
         try
         {
            var employees = await _repository.Employee.GetEmployees();
            var employeesResult = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return Ok(employeesResult);
         }
         catch (Exception e)
         {
            return StatusCode(500, "Internal server error");
         }
      }

      // GET: api/employees/1
      [HttpGet("{id}")]
      public async Task<ActionResult<EmployeeDto>> GetEmployeeWithDetails(int id)
      {
         var employee = await _repository.Employee.GetEmployeeWithDetails(id);

         if (employee == null)
         {
            return NotFound();
         }
         var employeeResult = _mapper.Map<EmployeeWithDetailsDto>(employee);
         return Ok(employeeResult);
      }
      
      // POST: api/employees
      [HttpPost]
      public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
      {
         if (!ModelState.IsValid)
         {
            return BadRequest(ModelState);
         }

         await _repository.Employee.AddEmployee(employee);
         return CreatedAtAction(nameof(GetEmployeeWithDetails), new { id = employee.Id}, employee);
      }
      
      // PUT: api/employees/1
      [HttpPut("{id}")]
      public ActionResult UpdateEmployee(int id, Employee employee)
      {
         if (id != employee.Id)
         {
            return BadRequest();
         }

         try
         {
            _repository.Employee.UpdateEmployee(employee);
         }
         catch (DbUpdateConcurrencyException)
         {
            if (_repository.Employee.GetEmployeeWithDetails(id) == null)
            {
               return NotFound();
            }
            else
            {
               throw;
            }
         }

         return NoContent();
      }
      
      //DELETE: api/employees/2
      [HttpDelete("{id}")]
      public async Task<ActionResult> DeleteEmployee(int id)
      {
         var employee = await _repository.Employee.GetEmployeeWithDetails(id);
         if (employee == null)
         {
            return NotFound();
         }
         await _repository.Employee.DeleteEmployee(employee);
         return NoContent();
      }
      
      // GET: api/employees/type/1
      [HttpGet("type/{id}")]
      public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesByType(int id)
      {
         var employees = await _repository.Employee.GetEmployeesByType(id);
         return Ok(employees);
      }
   }
}
