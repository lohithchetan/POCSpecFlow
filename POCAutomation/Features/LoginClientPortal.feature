Feature: LoginClientPortal
	In order to access application
	As a client user
	I want to login application using valid credentials only

@Client
Scenario Outline: Login to portal using valid credentials
	Given User navigated to application using <BaseURL>
	When  User user clicks SignIn Link
	And  User login using credentials <UserName> and <PassWord>
	Then Client should be able to login successfully
	And Test completed succesfully
Examples: 
| BaseURL | UserName   | PassWord|
| Client  |mmulcahy1219|Password12|


@Client
Scenario Outline: Login to portal using invalid credentials
	Given User navigated to application using <BaseURL>
	When  User user clicks SignIn Link
	And User login using credentials <UserName> and <PassWord>
	Then User should get <Error> message
Examples: 
| BaseURL | UserName                    | PassWord    | Error                        |
| Client  | chaturvediankit1993@gmail.com | Test@123456 |Invalid username or password|


