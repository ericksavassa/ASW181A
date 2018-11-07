Feature: AlterarStatusFuncionario
	In order to change the status of an employee
	As a user of the app
	I want to be told if the status was changed

@mytag
Scenario: Change status of employee
	Given I have entered 1 into the Id
	And I have entered "S" into the Status
	When I press AlterarStatus
	Then the result should be 1
