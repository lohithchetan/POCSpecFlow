Feature: AddToCart

@Client
Scenario Outline: User add agile book to Cart
	Given User navigated to application using <BaseURL>
	When  User user clicks SignIn Link
	And  User login using credentials <UserName> and <PassWord>
	Then Client should be able to login successfully
	When User navigate to Agile Books Page
	Then Products should be displayed
	When When used Click on Quick Overview link for <BookName>
	And  User click on Add to Cart button
	Then Item Should get added to Cart

Examples: 
| BaseURL | UserName     | PassWord  | BookName                            |
| Client  | mmulcahy1219 | Password1 | EPAM The Hero with a Thousand Faces |
