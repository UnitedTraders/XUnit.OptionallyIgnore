Feature: StepConditionalIgnore
	In order to avoid odd behaviour of OptionallyIgnore tag
	As a simple tag user
	I want check that methods without OptionallyIgnore tag fails when exception occurs

@OptionallyIgnore
Scenario: Ignore tests with AssertExtension.Skip and OptionallyIgnore tag
	Given Some conditions
	Then Tests ignored because of AssertExtension.Skip

@optionallyignore
Scenario: This test also will be ignored beacuse tag using is case insensitive
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

@OpitionallyInoredddddddd
Scenario: This tests will fails because of mistake in tag name
	Given Some conditions
	Then Tests ignored because of AssertExtension.Skip

@SomeOtherTag
@OptionallyIgnore
Scenario: This test must be ignored correctly even with two tags
	Given Some conditions
	Then Tests ignored because of AssertExtension.Skip