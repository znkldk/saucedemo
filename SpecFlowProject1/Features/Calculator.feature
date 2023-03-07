Feature: Login

Scenario: Login Successfull
	Given Enter User Name standard_user
	Given Enter Password secret_sauce
	Given Click Login Button
	Given Check Succesfull Login

Scenario: Login WrongPassword
	Given Enter User Name standard_user
	Given Enter Password wrongPassword
	Given Click Login Button
	Given Check Error Message For Unsuccesfull Login Epic sadface: Username and password do not match any user in this service
	
Scenario: Login Empty UserName
	Given Enter Password wrongPassword
	Given Click Login Button
	Given Check Error Message For Unsuccesfull Login Epic sadface: Username is required

Scenario: Login Empty Password
	Given Enter User Name standard_user
	Given Click Login Button
	Given Check Error Message For Unsuccesfull Login Epic sadface: Password is required
