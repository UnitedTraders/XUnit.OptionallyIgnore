using TechTalk.SpecFlow;
using Xunit;

namespace XUnit.OptionallyIgnore.Tester
{
    [Binding]
    [Scope(Feature = "IgnoreThisFeature")]
    public class IgnoreThisFeatureFlow
    {
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {

        }


        [When(@"I press add")]
        public void WhenIPressAdd()
        {

        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Assert.True(false, "IgnoreThisFeatureFlow FAILED to Ignore");
        }
    }
}
