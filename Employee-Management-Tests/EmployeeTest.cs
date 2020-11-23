using AutoMapper;
using EmployeeManagement.Contracts;
using EmployeeManagement.Controllers;
using EmployeeManagement.Data;
using EmployeeManagement.DataTransferObjects;
using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management_Tests
{
   public class Tests
   {
      IRepositoryWrapper _repository;
      IMapper _mapper;
      EmployeesController _controller;

      [SetUp]
      public void Setup()
      {
         _repository = new RepositoryWrapperFake();
         var config = new MapperConfiguration(opts =>
         {
            opts.CreateMap<Employee, EmployeeDto>();
            opts.CreateMap<Employee, EmployeeWithDetailsDto>();
         });

         _mapper = config.CreateMapper();
         _controller = new EmployeesController(_repository, _mapper);
      }

      [Test]
      public async Task GetEmployees_WhenCalled_ReturnsOkResult()
      {
         var result = await _controller.GetEmployees();
         Assert.That(result.Result, Is.TypeOf(typeof(OkObjectResult)));
      }

      [Test]
      public async Task GetEmployees_WhenCalled_ReturnsAllEmployees()
      {
         var result = await _controller.GetEmployees();
         var OkResult = result.Result as OkObjectResult;
         Assert.That(OkResult.Value, Is.TypeOf(typeof(List<EmployeeDto>)));
      }

      [Test]
      public async Task GetEmployeeWithDetails_UnknownIdPassed_ReturnsNotFound()
      {
         var result = await _controller.GetEmployeeWithDetails(45);

         Assert.That(result.Result, Is.TypeOf(typeof(NotFoundResult)));
      }

      [Test]
      public async Task GetEmployeeWithDetails_ExistingIdPassed_ReturnsOkResult()
      {
         var result = await _controller.GetEmployeeWithDetails(1);
         Assert.That(result.Result, Is.TypeOf(typeof(OkObjectResult)));
      }

      [Test]
      public async Task GetEmployeeWithDetails_ExistingIdPassed_ReturnsRightEmployee()
      {
         var result = await _controller.GetEmployeeWithDetails(1);
         var okResult = result.Result as OkObjectResult;
         Assert.AreEqual((okResult.Value as EmployeeWithDetailsDto).FirstName, "John");
      }

      [Test]
      public async Task AddEmployee_InvalidEmployeePassed_ReturnsBadRequest()
      {
         var employee = new Employee()
         {
            FirstName = "Jonas",
            LastName = "Mant"
         };

         _controller.ModelState.AddModelError("Gender", "Required");

         var badResponse = await _controller.AddEmployee(employee);

         Assert.That(badResponse.Result, Is.TypeOf(typeof(BadRequestObjectResult)));
      }

      [Test]
      public async Task AddEmployee_ValidEmployeePassed_ReturnsCreatedResponse()
      {
         var employee = new Employee()
         {
            Id = 3,
            FirstName = "Tom",
            LastName = "Hardy",
            Bio = null,
            DOB = DateTime.Now,
            Email = "Tom@gmail.com",
            Gender = "Male",
            Phone = "623466",
            EmployeeTypeId = 1,
            EmployeeType = null
         };

         var createdResponse = await _controller.AddEmployee(employee);

         Assert.That(createdResponse.Result, Is.TypeOf(typeof(CreatedAtActionResult)));
      }

      [Test]
      public async Task DeleteEmployee_InvalidIdPassed_ReturnNotFound()
      {
         var badResponse = await _controller.DeleteEmployee(34);

         Assert.That(badResponse, Is.TypeOf(typeof(NotFoundResult)));
      }

      [Test]
      public async Task DeleteEmployee_ExistingIdPassed_RemovesOneItem()
      {
         await _controller.DeleteEmployee(1);
         var employees = await _controller.GetEmployees();
         var employeesResult = employees.Result as OkObjectResult;
         Assert.AreEqual((employeesResult.Value as IEnumerable<EmployeeDto>).Count(), 1);
      }
   }
}