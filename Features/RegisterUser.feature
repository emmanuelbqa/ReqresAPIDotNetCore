Feature: RegisterUser
	Make a Post request and assert a response of 201 along with a token


Scenario Outline: Register user
	Given I send request to register a new user with '<Email>' as email and I enter '<Password>' as password and save response as 'responseSave'
	Then response 'responseSave' has code '<Code>' and token '<Token>' and '<Message>'
Examples:
| Email              | Password | Code | Token             | Message          |
| eve.holt@reqres.in | pistol   | 200  | QpwL5tke4Pnpja7X4 | null             |
| sydney@fife        |          | 400  | null              | Missing password |


Scenario: Get List of users
	Given I send a Get request to get the list of users and save response as 'responseSave'
	Then response 'responseSave' has code '200' with a list of users