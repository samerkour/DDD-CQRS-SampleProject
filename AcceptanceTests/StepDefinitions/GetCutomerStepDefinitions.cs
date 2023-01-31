using Moq;
using STech.Application.Interfaces;
using STech.Application.Services;
using STech.Application.ViewModels;
using STech.Services.Api.Controllers;
using System;
using System.Web.Http;
using System.Web.Http.Results;
using TechTalk.SpecFlow;
using Xunit;

namespace AcceptanceTests.StepDefinitions
{
    [Binding]
    public class GetCutomerStepDefinitions
    {
        IHttpActionResult _httpActionResult;
        private  Mock<ICustomerAppService> _mockRepo;
        private  CustomerController _controller;

        [Given(@"that a customer exists in the system")]
        public void GivenThatACustomerExistsInTheSystem()
        {
            _mockRepo = new Mock<ICustomerAppService>();
            //_mockRepo = new CustomerAppService();
            _controller = new CustomerController(_mockRepo.Object);
        }

        [When(@"i request to get the customer by Id")]
        public async void WhenIRequestToGetTheCustomerById()
        {
           await  _controller.Get(new Guid("7AC91B75-6950-413F-8841-A9C7CFE4653A"));
        }

        [Then(@"the customer should be returned in the response")]
        public void ThenTheCustomerShouldBeReturnedInTheResponse()
        {
           var customer =_httpActionResult as OkNegotiatedContentResult<CustomerViewModel>;
            Assert.NotNull(customer);
            Assert.Equal(customer.Content.Id, new Guid("7AC91B75-6950-413F-8841-A9C7CFE4653A"));
        }

        [Then(@"the response status code should be '([^']*)'")]
        public void ThenTheResponseStatusCodeShouldBe(string p0)
        {

            if (p0 == "200 OK")
            {
                var customer = _httpActionResult as OkNegotiatedContentResult<CustomerViewModel>;
                Assert.NotNull(customer);
            }
            else if (p0 == "404 Not Found")
            {
                var customer = _httpActionResult as NotFoundResult;
                Assert.NotNull(customer);
            }

        }

        [Given(@"that a customer dose not exsits in the system")]
        public void GivenThatACustomerDoseNotExsitsInTheSystem()
        {
            _mockRepo = new Mock<ICustomerAppService>();
            _controller = new CustomerController(_mockRepo.Object);
        }

        [Then(@"no customer should be returned in the response")]
        public void ThenNoCustomerShouldBeReturnedInTheResponse()
        {
            var customer = _httpActionResult as NotFoundResult;
            Assert.NotNull(customer);
        }
    }
}
