using TechTalk.SpecFlow;

namespace Xunit.SpecFlow.AssertSkip.Tester
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
