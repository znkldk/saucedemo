Feature: Product List

Scenario: Click Add Button
	Given Enter User Name standard_user
	Given Enter Password secret_sauce
	Given Click Login Button
	Given Check Succesfull Login
	Given Click add button 3

Scenario: Click Remove Button
	Given Enter User Name standard_user
	Given Enter Password secret_sauce
	Given Click Login Button
	Given Check Succesfull Login
	Given Click add button 4
	Given Click Remove button 4
	

