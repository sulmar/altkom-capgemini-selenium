Feature: Login
	Login to Sauce Demo

@mytag
Scenario: Login as standard user
	Given I navigate to homepage		
	When I enter <username> and <password>		
	And I click on Login Button
	Then I am logged
	Then I see Inventory Page.

	Examples: 	
	| username      | password     |
	| standard_user | secret_sauce |

Scenario: Login as locked out user
	Given I navigate to homepage
	When I enter <username> and <password>
	And I click on Login Button	
	Then I see error <message>.
	Examples: 
		| username        | password     | message                                             |
		| locked_out_user | secret_sauce | Epic sadface: Sorry, this user has been locked out. |
