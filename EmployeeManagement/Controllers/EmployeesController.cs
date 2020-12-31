using AutoMapper;
using EmployeeManagement.Contracts;
using EmployeeManagement.Contracts.DataTransferObjects;
using EmployeeManagement.Data;
using EmployeeManagement.Domain.Handlers;
using EmployeeManagement.Domain.Models;
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
      private readonly IEmployeeHandler _employeeHandler;
      private readonly IMapper _mapper;

      public EmployeesController(IEmployeeHandler employeeHandler, IMapper mapper)
      {
         _employeeHandler = employeeHandler;
         _mapper = mapper;
      }

      // GET: api/employees
      [HttpGet]
      public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
      {
         try
         {
            var employees = await _employeeHandler.GetEmployees();
            var employeeResponse = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return Ok(employeeResponse);
         }
         catch (Exception e)
         {
            return StatusCode(500, "Internal server error");
         }
      }

      // GET: api/employees/1
      [HttpGet("{id}")]
      public async Task<ActionResult<EmployeeDto>> GetEmployeeWithDetails(string id)
      {
         var employee = await _employeeHandler.GetEmployeeWithDetails(id);

         if (employee == null)
         {
            return NotFound();
         }
         var employeeResponse = _mapper.Map<EmployeeWithDetailsDto>(employee);
         return Ok(employeeResponse);
      }
      
      // POST: api/employees
      [HttpPost]
      public async Task<ActionResult<Employee>> AddEmployee(AddEmployeeDto employee)
      {
         if (!ModelState.IsValid)
         {
            return BadRequest(ModelState);
         }
         var domainEmployee = _mapper.Map<Employee>(employee);
         var addedEmployee = await _employeeHandler.AddEmployee(domainEmployee);
         return CreatedAtAction(nameof(GetEmployeeWithDetails), new { id = addedEmployee.Id}, addedEmployee);
      }
      
      // PUT: api/employees/1
      [HttpPut("{id}")]
      public async Task<ActionResult> UpdateEmployee(string id, Employee employee)
      {
         if (id != employee.Id)
         {
            return BadRequest();
         }

         try
         { 
            await _employeeHandler.UpdateEmployee(employee);
         }
         catch (DbUpdateConcurrencyException)
         {
            if (_employeeHandler.GetEmployeeWithDetails(id) == null)
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
      public async Task<ActionResult> DeleteEmployee(string id)
      {
         var employee = await _employeeHandler.GetEmployeeWithDetails(id);
         if (employee == null)
         {
            return NotFound();
         }
         await _employeeHandler.DeleteEmployee(employee);
         return NoContent();
      }
   }
}
