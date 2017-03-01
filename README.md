XUnit Ignore test at runtime  - instead of [Fact] use
```
[OptionallyIgnoreTestFact]
```

For SpecFlow use the tag 
```
@OptionallyIgnore
```

As Xunit has no Assert.Ignore() using the above attribute/tag and setting the following flag will ignore tests at runtime

Sample usage inf simple xUnit tests:
```
using XUnit.OptionallyIgnore.SpecFlowPlugin;

namespace XUnit.OptionallyIgnore.Tester
{
    public class SampleIgnoreTest
    {
        [OptionallyIgnoreTestFact]
        public void SampleTest()
        {
            AssertExtension.Skip("Some ignore reason");
        }
    }
}

```

This project based on this OptionallyIgnore https://github.com/chrismckelt/XUnit.OptionallyIgnore but has different behaviour 

Use Cases include: long running tests that should only run on the build.


Sample usage in SpecFlow:

SpecFlow Scenario:
```
Feature: StepConditionalIgnore
	In order to avoid odd behaviour of OptionallyIgnore tag
	As a simple tag user
	I want check that methods without OptionallyIgnore tag fails when exception occurs
 
@OptionallyIgnore
Scenario: Ignore tests with AssertExtension.Skip and OptionallyIgnore tag
	Given Some conditions
	Then Tests ignored because of AssertExtension.Skip
 ```
 Steps realisation:
 ```
using TechTalk.SpecFlow;
using Xunit;
using XUnit.OptionallyIgnore.SpecFlowPlugin;

namespace XUnit.OptionallyIgnore.Tester
{
    [Binding]
    public class ConditionalIgnoreFlowSteps
    {
        [Given(@"Some conditions")]
        public void GivenSomeConditions()
        {
        }

        [Then(@"Tests ignored because of AssertExtension.Skip")]
        public void ThenTestsIgnored()
        {
            AssertExtension.Skip("We want to skip it right now!");
        }
    }
}
 ```

