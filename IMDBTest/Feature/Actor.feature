Feature: Actor Resource

Scenario: Get Actor All
	Given I am a client
	When I make GET Request '/api/actor'
	Then response code must be '200'
	And response data must look like '[{"id":1,"name":"Mila Kunis","bio":"Americal  Actress","dob":"1986-11-14T00:00:00","gender":"Female"},{"id":2,"name":"George Michael","bio":"A romantic","dob":"1978-11-23T00:00:00","gender":"Male"}]'

Scenario: Get Actor
	Given I am a client
	When I make GET Request '/api/actor/1'
	Then response code must be '200'
	And response data must look like '{"id":1,"name":"Mila Kunis","bio":"Americal  Actress","dob":"1986-11-14T00:00:00","gender":"Female"}'

Scenario:Add an Actor
	Given I am a client
	When  I am making a post request to '/api/actor' with the following Data '{"id":2,"name":"Emma Watson","bio":"Americal  Actress","dob":"1986-10-14T00:00:00","gender":"Female"}'
	Then response code must be '200'

Scenario: Update an Actor
	Given I am a client
	When I make PUT Request '/api/actor/1' with the following Data with the following Data '{ "Name":"Mila Kunis chausi","Gender":"Female","Bio":"Milena Markovna Kunis is an American actress. In 1991, at the age of 7, she moved from Soviet Ukraine to the United States with her family","Dob":"1986-11-14"}'
	Then response code must be '200'

Scenario:Delete a actor record
	Given I am a client
	When I make Delete Request '/api/actor/1'
	Then response code must be '200'