using AutoMapper;
using EmployeeManagement.Domain.Handlers;
using EmployeeManagement.Domain.Models;
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
      private readonly IEmployeeTypeHandler _employeeTypeHandler;
      private readonly IMapper _mapper;

      public EmployeeTypesController(IEmployeeTypeHandler employeeTypeHandler, IMapper mapper)
      {
         _employeeTypeHandler = employeeTypeHandler;
         _mapper = mapper;
      }

      //GET: api/employee_types
      [HttpGet]
      public async Task<ActionResult<IEnumerable<EmployeeType>>> GetEmployeeTypes()
      {
         var employeeTypes = await _employeeTypeHandler.GetEmployeeTypes();
         return Ok(employeeTypes);
      }

      //POST: api/employee_types
      [HttpPost]
      public async Task<ActionResult<EmployeeType>> AddEmployeeType(EmployeeType employeeType)
      {
         await _employeeTypeHandler.AddEmployeeType(employeeType);
         return Ok(employeeType);
      }
   }
}
