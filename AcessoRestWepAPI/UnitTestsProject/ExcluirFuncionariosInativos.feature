Feature: ExcluirFuncionariosInativos
	In order to delete inactive employees
	As a user of the app
	I want to be told the amount of employees that was deleted

@mytag
Scenario: Delete inactive employees
	Given I have one inactive employee in database
	When I press ExcluirInativos
	Then the amount should be 1
