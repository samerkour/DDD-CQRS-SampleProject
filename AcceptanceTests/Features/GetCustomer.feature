Feature: GetCutomer
In order to get customer information from the API
As an API consumer
I want to get the consumer by Id


Scenario: Get customer by Id
	Given that a customer exists in the system
	When i request to get the customer by Id
	Then the customer should be returned in the response
	And the response status code should be '200 OK'


Scenario: Get none-exist customer by Id
	Given that a customer dose not exsits in the system
	When i request to get the customer by Id
	Then no customer should be returned in the response
	And the response status code should be '404 Not Found'
