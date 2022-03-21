Feature: Login

@login
Scenario: Failed Login
	When user tries to log in with an incorrect email
	Then an error message is displayed