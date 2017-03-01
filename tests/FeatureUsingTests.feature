@OptionallyIgnore
Feature: FeatureUsingTests
	In order to avoid odd behaviour of OptionallyIgnore tag
	As a simple tag user
	I want check that OptionallyIgnore tag on Feature changes nothing 

@OptionallyIgnore
Scenario: Ignore tests with AssertExtension.Skip and OptionallyIgnore tag
	Given Some conditions
	Then Tests ignored because of AssertExtension.Skip

@OptionallyIgnore
Scenario: Test success
	Given Some conditions
	Then Success assert

Scenario: Test fails
	Given Some conditions
	Then Failed assert

Scenario: This tests will fails because of OpionallyIgnore tag absence
	Given Some conditions
	Then Tests ignored because of AssertExtension.Skip