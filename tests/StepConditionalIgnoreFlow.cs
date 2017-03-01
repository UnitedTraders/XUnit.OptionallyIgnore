using TechTalk.SpecFlow;
using Xunit;
using XUnit.OptionallyIgnore.SpecFlowPlugin;

namespace XUnit.OptionallyIgnore.Tester
{
    [Binding]
    public class StepConditionalIgnoreFlow
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

        [Then(@"Failed assert")]
        public void ThenAssertFalse()
        {
            Assert.True(false);
        }

        [Then(@"Success assert")]
        public void ThenSuccessAssert()
        {
            Assert.True(true);
        }
    }
}
