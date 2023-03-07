Feature: Basket


Scenario: Check Basket
	Given Enter User Name standard_user
	Given Enter Password secret_sauce
	Given Click Login Button
	Given Check Succesfull Login
	Given Click add button 2
	Given Click add button 3
	Given Click add button 6
	Given Click Basket
	Given Check Basket Products
	
Scenario: Check Basket Back Button
	Given Enter User Name standard_user
	Given Enter Password secret_sauce
	Given Click Login Button
	Given Check Succesfull Login
	Given Click Basket
	Given Click Back Basket Btn
