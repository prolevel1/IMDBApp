Feature: Producer Resource

Scenario: Get Producer All
	Given I am a client
	When I make GET Request '/api/producer'
	Then response code must be '200'
	And response data must look like '[{"id":1,"name":"Arjun","bio":"A director","dob":"1962-08-15T00:00:00","gender":"Male"},{"id":2,"name":"Tom","bio":"a directorial","dob":"1987-11-03T00:00:00","gender":"Male"}]'

Scenario: Get Producer
	Given I am a client
	When I make GET Request '/api/producer/1'
	Then response code must be '200'
	And response data must look like '{"id":1,"name":"Arjun","bio":"A director","dob":"1962-08-15T00:00:00","gender":"Male"}'

Scenario:Add an Producer
	Given I am a client
	When  I am making a post request to '/api/producer' with the following Data '{"name":"tom cruise","bio":"a director","dob":"1926-10-14T00:00:00","gender":"Male"}'
	Then response code must be '200'

Scenario: Update an Producer
	Given I am a client
	When I make PUT Request '/api/producer/1' with the following Data with the following Data '{"id":1,"name":"Arun Mehta","bio":"A director","dob":"2014-09-11T00:00:00","gender":"Male"}'
	Then response code must be '200'

Scenario:Delete a Producer record
	Given I am a client
	When I make Delete Request '/api/producer/1'
	Then response code must be '200'