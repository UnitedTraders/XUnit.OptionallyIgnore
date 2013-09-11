Feature: SpecFlowFeature1
	Test ignored tags for xunit

@LongRunningTest
Scenario: Long running test should be ignored
	Given this is a long running test
	And I only want to run this occassionally
	When I remove the tag
	Then this test should be ignored


@OnlyRunOnBuildServer
Scenario: Only run this on the build server
	Given I only run this on the build server
	Then it should be ignored locally


@IgnoreLocally
Scenario: Dont run this locally
	Given I am running this locally
	Then this should be ignored
