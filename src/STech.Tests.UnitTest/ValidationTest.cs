using Microsoft.AspNetCore.Mvc;
using Moq;
using STech.Application.Interfaces;
using STech.Application.ViewModels;
using STech.Domain.Interfaces;
using STech.Domain.Models;
using STech.Services.Api.Controllers;
using System;
using System.Collections.Generic;
using Xunit;

namespace STech.Tests.UnitTest
{
    public class ValidationTest 
    {
        private readonly Mock<ICustomerAppService> _mockRepo;
        private readonly CustomerController _controller;

        public ValidationTest()
        {
            _mockRepo = new Mock<ICustomerAppService>();
            _controller = new CustomerController(_mockRepo.Object);
        }

        [Fact]
        public void CreateCustomerValid_ReturnsSuccess()
        {
            // Todo: Refer to readme.md 
        }

        // Please create more tests based on project requirements as per in readme.md



        [Fact]
        public void Get_ActionExecutes_ReturnsExactNumberOfCustmers() 
        {
            _mockRepo.Setup(repo => repo.GetAll())
                .ReturnsAsync(new List<CustomerViewModel>() { 
                    new CustomerViewModel(), 
                    new CustomerViewModel() }
                );



            var result = _controller.Get();
            var viewResult = Assert.IsType<IEnumerable<CustomerViewModel>>(result);
            var cutomers = Assert.IsType<List<CustomerViewModel>>(viewResult);
            Assert.Equal(2, cutomers.Count);
        }


        [Theory]
        [InlineData("AL35202111090000000001234567")]
        [InlineData("BL35202111090000000001234568")]
        public void Create_ActionExecutes_ReturnsViewForCreate(string bankaAccountNumber)
        {
            var result = _controller.Post(new CustomerViewModel() { 
                Id= Guid.NewGuid(), 
                FirstName= "Samer", 
                LastName="Kour", 
                BirthDate= DateTime.UtcNow.AddYears(-30), 
                PhoneNumber="+989100000000",
                Email="koursamer@gmail.com",
                BankAccountNumber= bankaAccountNumber
            });

            Assert.IsType<IActionResult>(result);
        }




        [Fact]
        public void Create_InvalidModelState_ReturnsView()
        {
            _controller.ModelState.AddModelError("Name", "Name is required");

            var customer = new CustomerViewModel() { PhoneNumber="", Email="", BankAccountNumber = "AL35202111090000000001234567" };

            var result = _controller.Post(customer);

            var viewResult = Assert.IsType<ViewResult>(result);
            var testEmployee = Assert.IsType<CustomerViewModel>(viewResult.Model);

            Assert.Equal(customer.BankAccountNumber, testEmployee.BankAccountNumber);
            Assert.Equal(customer.PhoneNumber, testEmployee.PhoneNumber);
            Assert.Equal(customer.Email, testEmployee.Email); 
        }

    }
}