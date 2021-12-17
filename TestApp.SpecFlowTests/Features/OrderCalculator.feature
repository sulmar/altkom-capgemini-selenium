Feature: OrderCalculator
	Calculator for calculate tax amount for order

@mytag
Scenario: Calculate tax amount
	Given the total amount net is 100
	And the tax ratio is 23
	When the user click Calculate button
	Then the total amount gross should be 123