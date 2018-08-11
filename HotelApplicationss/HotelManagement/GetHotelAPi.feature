Feature: Add Hotel
	In order to simulate hotel management system
	As an api consumer
	I want to be able to add hotel and get hotel

@AddHotel
Scenario Outline: User adds hotel in database
	Given User provided valid Id '<id>' and '<name>' for hotel
	And User has added required details for hotel
	When User callers AddHotel api
	Then Hotel with id '<id>' should be present in the response

Examples: 
| id | name   |
| 1  | hotel1 |
| 2  | hotel2 |
| 3  | hotel3 |
