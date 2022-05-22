Feature: Movie Resource

Scenario: Get Movie All
	Given I am a client
	When I make GET Request '/api/movie'
	Then response code must be '200'
	And response data must look like '[{"id":1,"name":"Roc","yor":"1992-09-26T00:00:00","plot":"Hindi","actor":[{"id":1,"name":"Mila Kunis","bio":"Americal  Actress","dob":"1926-10-14T00:00:00","gender":"Female"},{"id":2,"name":"George Michael","bio":"A romantic","dob":"1978-11-23T00:00:00","gender":"Male"}],"genre":[{"id":1,"name":"Action"}],"producer":{"id":1,"name":"Arun","bio":"A director","dob":"2014-09-11T00:00:00","gender":"Male"}}]'  

	Scenario: Get Movie
	Given I am a client
	When I make GET Request '/api/movie/1'
	Then response code must be '200'
	And response data must look like '{"id":1,"name":"Roc","yor":"1992-09-26T00:00:00","plot":"Hindi","actor":[{"id":1,"name":"Mila Kunis","bio":"Americal  Actress","dob":"1926-10-14T00:00:00","gender":"Female"},{"id":2,"name":"George Michael","bio":"A romantic","dob":"1978-11-23T00:00:00","gender":"Male"}],"genre":[{"id":1,"name":"Action"}],"producer":{"id":1,"name":"Arun","bio":"A director","dob":"2014-09-11T00:00:00","gender":"Male"}}'  

Scenario:Add an Movie
	Given I am a client
	When  I am making a post request to '/api/movie' with the following Data '{"name": "spiderman","yor":"1999-09-26T00:00:00","plot":"english hollywood movie ","actor":[1],"genre":[1],"producerId":1}'
	Then response code must be '200'

Scenario: Update an Movie
	Given I am a client
	When I make PUT Request '/api/movie/1' with the following Data with the following Data '{"id":2,"name": "spiderman","yor":"1999-09-26T00:00:00","plot":"english hollywood movie ","actor":[1],"genre":[1],"producerId":1}'
	Then response code must be '200'

Scenario:Delete a actor record
	Given I am a client
	When I make Delete Request '/api/movie/1'
	Then response code must be '200'





