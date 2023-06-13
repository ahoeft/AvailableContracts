Feature: SearchContracts

Search contracts to see what is available.

@SearchContracts
Scenario: Search for active music contracts
	Given the supplied reference data
	When user perform search by ITunes 03-01-2012
	Then the output should be
	| Artist | Title | Usages | StartDate | EndDate |
	| Monkey Claw | Black Mountain | digital download | 02-01-2012 | |
	| Monkey Claw | Motor Mouth | digital download | 03-01-2011 | |
	| Tinie Tempah | Frisky (Live from SoHo) | digital download | 02-01-2012 | |
	| Tinie Tempah | Miami 2 Ibiza | digital download | 02-01-2012 | |
