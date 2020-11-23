using EmployeeManagement.Contracts;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
   [Route("api/employee_types")]
   [ApiController]
   public class EmployeeTypesController: ControllerBase
   {
      private readonly IRepositoryWrapper _repository;

      public EmployeeTypesController(IRepositoryWrapper repository)
      {
         _repository = repository;
      }

      //GET: api/employee_types
      [HttpGet]
      public async Task<ActionResult<IEnumerable<EmployeeType>>> GetEmployeeTypes()
      {
         var employeeTypes = await _repository.EmployeeType.GetEmployeeTypes();
         return Ok(employeeTypes);
      }

      //POST: api/employee_types
      [HttpPost]
      public async Task<ActionResult<EmployeeType>> AddEmployeeType(EmployeeType employeeType)
      {
         await _repository.EmployeeType.AddEmployeeType(employeeType);
         return Ok(employeeType);
      }
   }
}
