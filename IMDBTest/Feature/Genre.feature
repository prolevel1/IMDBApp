Feature: Genre Resource

Scenario: Get Genre All
	Given I am a client
	When I make GET Request '/api/genre'
	Then response code must be '200'
	And response data must look like '[{"id":1,"name":"Action"},{"id":3,"name":"Romance"}]'

Scenario: Get Genre
	Given I am a client
	When I make GET Request '/api/genre/1'
	Then response code must be '200'
	And response data must look like '{"id":1,"name":"Action"}'

Scenario:Add an Genre
	Given I am a client
	When  I am making a post request to '/api/genre' with the following Data '{"name":"Thriller"}'
	Then response code must be '200'

Scenario: Update an Genre
	Given I am a client
	When I make PUT Request '/api/genre/1' with the following Data with the following Data '{"id":1,"name":"Horror"}'
	Then response code must be '200'

Scenario:Delete a Genre record
	Given I am a client
	When I make Delete Request '/api/genre/1'
	Then response code must be '200'