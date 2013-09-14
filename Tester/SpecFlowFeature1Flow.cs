using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace Tester
{
    [Binding()]
    [Scope(Feature = "SpecFlowFeature1")]
    public class SpecFlowFeature1Flow : Steps
    {
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            
        }

        [Given(@"I run some other tag")]
        public void GivenIRunSomeOtherTag()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I only run this on the build server")]
        public void GivenIOnlyRunThisOnTheBuildServer()
        {
         
        }

        [Given(@"I am running this locally")]
        public void GivenIAmRunningThisLocally()
        {
            ScenarioContext.Current.Pending();
        }


        [Given(@"this is a long running test")]
        public void GivenThisIsALongRunningTest()
        {
          
        }


        [Given(@"I only want to run this occassionally")]
        public void GivenIOnlyWantToRunThisOccassionally()
        {
          
        }


        [When(@"I press add")]
        public void WhenIPressAdd()
        {
          
        }

        [When(@"I remove the tag")]
        public void WhenIRemoveTheTag()
        {
     
        }


        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            Assert.True(false, "DOOOOH");
        }


        [Then(@"it should be ignored locally")]
        public void ThenItShouldBeIgnoredLocally()
        {
            Assert.True(false, "DOOOOH");
        }

        [Then(@"it should always run the test")]
        public void ThenItShouldAlwaysRunTheTest()
        {
            Assert.True(false, "DOOOOH");
        }

        [Then(@"this test should be ignored")]
        public void ThenThisTestShouldBeIgnored()
        {
            Assert.True(false, "DOOOOH");
        }

        [Then(@"this should be ignored")]
        public void ThenThisShouldBeIgnored()
        {
            Assert.True(false, "DOOOOH");
        }
    }
}
