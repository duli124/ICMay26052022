Feature: TMFeature
	As a TurnUp portal Admin 
	I would like to create, edit and delete time and material records
	So I can manage employees' time and material successfully

@mytag
Scenario: 1 Create time and material record with valid details
	Given I logged into TurnUp portal succesfully 
	When I navigate to time and material page
	When I create a time and material record
	Then the record should be created successfully

Scenario Outline: 2 Create time and material record with valid details
	Given I logged into TurnUp portal succesfully 
	When I navigate to time and material page
	When I update '< Description>', '<Code>','<Price>' on an existing time and material record
	Then the record should have the updated '<description>', '<Code>','<Price>'

	Examples: 
	| Description  | Code    | Price    |
	| Pencil		| May2022 | $160.00   |
	| Pen          | Phone   | $80.00 |
	| EditedRecord | Portal  | $3049.00   |
